using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Net;

namespace AuditoriaParlamentar
{
    internal class Dados
    {
        internal String MsgErro { get; set; }

        internal Int32 MenorAno { get; set; }
        internal DateTime UltimaAtualizacao { get; set; }
        internal String DirFiguras { get; set; }

        internal Boolean CarregaDados(String file, Boolean diferenca, GridView grid, GridView gridAcerto)
        {
            using(Banco banco = new Banco())
            {
                ApagaDadosFornecedorAtu(banco);

                if (diferenca == true)
                {
                    if (CarregaDadosTmpProcessa(file, banco) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    //if (CarregaDadosXml(file, banco, "lancamentos") == false)
                    //{
                        return false;
                    //}
                }

                PreviaDados(grid, banco);
                AcertoDados(gridAcerto, banco);

                //DownaloadFotosProcessa(banco);
            }

            return true;
        }

        private void PreviaDados(GridView grid, Banco banco)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT DISTINCT");
            sql.Append("       lancamentos_tmp.txNomeParlamentar");
            sql.Append("  FROM lancamentos_tmp");
            sql.Append(" LIMIT 100");

            using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
            {
                DataTable table = new DataTable("denuncias");
                table.Load(reader);

                table.Columns[0].ColumnName = "Parlamentar";

                grid.DataSource = table;
                grid.DataBind();
            }
        }

        private void AcertoDados(GridView grid, Banco banco)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT DISTINCT");
            sql.Append("       lancamentos_tmp.txNomeParlamentar");
            sql.Append("  FROM lancamentos_tmp");
            sql.Append(" WHERE NOT EXISTS (SELECT ideCadastro FROM parlamentares WHERE lancamentos_tmp.txNomeParlamentar = parlamentares.txNomeParlamentar)");

            using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
            {
                DataTable table = new DataTable("denuncias");
                table.Load(reader);

                table.Columns[0].ColumnName = "Parlamentar sem ide";

                grid.DataSource = table;
                grid.DataBind();
            }
        }

        internal Boolean EfetivaDados()
        {
            using (Banco banco = new Banco())
            {
                try
                {
                    banco.BeginTransaction();
                    CarregaDadosProcessa(banco);
                    NormalizaTabelas(banco);
                    banco.CommitTransaction();
                }
                catch (Exception ex)
                {
                    banco.RollBackTransaction();
                    MsgErro = ex.Message;
                    return false;
                }
            }

            return true;
        }

        private void ApagaDadosFornecedorAtu(Banco banco)
        {
            banco.ExecuteNonQuery("DELETE FROM fornecedores_atu WHERE Date < DATE_ADD(NOW(), INTERVAL -1 DAY)");
        }

        private Boolean CarregaDadosTmpProcessa(String file, Banco banco)
        {
            banco.ExecuteNonQuery("TRUNCATE lancamentos_tmp");

            return CarregaDadosXml(file, banco, "lancamentos_tmp");
        }

        private Boolean CarregaDadosXml(String file, Banco banco, String tabela)
        {
            StreamReader stream = null;

            try
            {
                if (file.EndsWith("AnoAnterior.xml"))
                    stream = new StreamReader(file, Encoding.GetEncoding(850)); //"ISO-8859-1"
                else
                    stream = new StreamReader(file, Encoding.GetEncoding("ISO-8859-1"));
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);
                XmlNodeList projectsGroup = doc.SelectNodes("//DESPESAS/DESPESA");

                StringBuilder sqlFields = new StringBuilder();
                StringBuilder sqlValues = new StringBuilder();
                String nodeName;

                foreach (XmlNode projectNode in projectsGroup)
                {
                    XmlNodeList files = projectNode.SelectNodes("*");

                    sqlFields.Clear();
                    sqlValues.Clear();

                    foreach (XmlNode fileNode in files)
                    {
                        if (sqlFields.Length > 0)
                        {
                            sqlFields.Append(",");
                            sqlValues.Append(",");
                        }

                        nodeName = fileNode.Name;

                        if (nodeName == "txtFornecedor")
                            nodeName = "txtBeneficiario";

                        sqlFields.Append(nodeName);
                        sqlValues.Append("@" + nodeName);

                        banco.AddParameter(nodeName, fileNode.InnerText.ToUpper());
                    }

                    banco.ExecuteNonQuery("INSERT INTO " + tabela + " (" + sqlFields.ToString() + ") VALUES (" + sqlValues.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MsgErro = ex.Message;
                return false;
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }

            return true;
        }

        internal void CarregaDadosProcessa(Banco banco)
        {
            //Para contornar a retirada do campo ideCadastro pelo câmara mas últimas alterações do xml
            //Para contornar o problema dos valores virem aleatoriamente com sinal negativo
            banco.ExecuteNonQuery("UPDATE lancamentos_tmp SET ideCadastro = (SELECT ideCadastro FROM parlamentares WHERE lancamentos_tmp.txNomeParlamentar = parlamentares.txNomeParlamentar), vlrLiquido = ABS(vlrLiquido)", 300);

            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT numano,");
            sql.Append("          nummes,");
            sql.Append("          ideCadastro");
            sql.Append("     FROM lancamentos_tmp");
            sql.Append(" GROUP BY 1,2,3");
            sql.Append("   HAVING SUM(vlrdocumento) <> IFNULL((SELECT SUM(vlrdocumento)");
            sql.Append("                                         FROM lancamentos");
            sql.Append("                                        WHERE lancamentos.numano      = lancamentos_tmp.numano");
            sql.Append("                                          AND lancamentos.nummes      = lancamentos_tmp.nummes");
            sql.Append("                                          AND lancamentos.ideCadastro = lancamentos_tmp.ideCadastro), 0);");

            using (DataTable table = banco.GetTable(sql.ToString(), 0))
            {
                foreach(DataRow row in table.Rows)
                {
                    banco.AddParameter("numano", row["numano"]);
                    banco.AddParameter("nummes", row["nummes"]);
                    banco.AddParameter("ideCadastro", row["ideCadastro"]);
                    banco.ExecuteNonQuery("DELETE FROM lancamentos WHERE numano = @numano AND nummes = @nummes AND ideCadastro = @ideCadastro", 0);

                    sql.Clear();
                    sql.Append("INSERT INTO lancamentos (ideCadastro, txNomeParlamentar, nuCarteiraParlamentar, nuLegislatura, sgUF, sgPartido, codLegislatura, numSubCota, txtDescricao, numEspecificacaoSubCota, txtDescricaoEspecificacao, txtBeneficiario, txtCNPJCPF, txtNumero, indTipoDocumento, datEmissao, vlrDocumento, vlrGlosa, vlrLiquido, numMes, numAno, numParcela, txtPassageiro, txtTrecho, numLote, numRessarcimento, ide_documento_fiscal, vlrRestituicao)");
                    sql.Append("SELECT ideCadastro, txNomeParlamentar, nuCarteiraParlamentar, nuLegislatura, sgUF, sgPartido, codLegislatura, numSubCota, txtDescricao, numEspecificacaoSubCota, txtDescricaoEspecificacao, txtBeneficiario, txtCNPJCPF, txtNumero, indTipoDocumento, datEmissao, vlrDocumento, vlrGlosa, vlrLiquido, numMes, numAno, numParcela, txtPassageiro, txtTrecho, numLote, numRessarcimento, ide_documento_fiscal, vlrRestituicao");
                    sql.Append("  FROM lancamentos_tmp");
                    sql.Append(" WHERE lancamentos_tmp.numano      = @numano");
                    sql.Append("   AND lancamentos_tmp.nummes      = @nummes");
                    sql.Append("   AND lancamentos_tmp.ideCadastro = @ideCadastro");

                    banco.AddParameter("numano", row["numano"]);
                    banco.AddParameter("nummes", row["nummes"]);
                    banco.AddParameter("ideCadastro", row["ideCadastro"]);
                    banco.ExecuteNonQuery(sql.ToString(), 0);
                }
            }
        }

        internal void DownaloadFotos()
        {
            using (Banco banco = new Banco())
            {
                DownaloadFotosProcessa(banco);
            }
        }

        internal void DownaloadFotosProcessa(Banco banco)
        {
            try
            {
                using (DataTable table = banco.GetTable("SELECT * FROM parlamentares", 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (!File.Exists(DirFiguras + @"\Parlamentares\DEPFEDERAL\" + row["ideCadastro"].ToString() + ".jpg"))
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.Headers.Add("User-Agent: Other");
                                client.DownloadFile("http://www.camara.gov.br/internet/deputado/bandep/" + row["ideCadastro"].ToString() + ".jpg", DirFiguras + @"\Parlamentares\DEPFEDERAL\" + row["ideCadastro"].ToString() + ".jpg");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgErro = ex.Message;
            }
        }

        internal void NormalizaTabelas(Banco banco)
        {
            StringBuilder sql = new StringBuilder();

            //----------------- Apaga registros desnecessários -----------------

            //banco.ExecuteNonQuery("DELETE FROM lancamentos WHERE nuCarteiraParlamentar = 0", 0);

            //-------------------- Ajustes --------------------

            // Joga dados da subcota 15 LOCAÇÃO DE VEÍCULOS AUTOMOTORES OU FRETAMENTO DE EMBARCAÇÕES 
            // para subcota 120LOCAÇÃO OU FRETAMENTO DE VEÍCULOS AUTOMOTORES para unificar os dados.
            banco.ExecuteNonQuery("UPDATE lancamentos SET numSubCota = 120, txtDescricao = 'LOCAÇÃO OU FRETAMENTO DE VEÍCULOS AUTOMOTORES' WHERE numSubCota = 15", 0);

            // Joga dados da subcota 9 PASSAGENS AÉREAS E FRETAMENTO DE AERONAVES
            // para subcota 119 LOCAÇÃO OU FRETAMENTO DE AERONAVES para unificar os dados.
            banco.ExecuteNonQuery("UPDATE lancamentos SET numSubCota = 119, txtDescricao = 'LOCAÇÃO OU FRETAMENTO DE AERONAVES' WHERE numSubCota = 9", 0);


            //----------------- Parlamentares -----------------

            sql.Clear();
            sql.Append(" INSERT INTO parlamentares (");
            sql.Append("        ideCadastro,");
            sql.Append("        txNomeParlamentar)");
            sql.Append(" SELECT DISTINCT");
            sql.Append("        lancamentos.ideCadastro,");
            sql.Append("        lancamentos.txNomeParlamentar");
            sql.Append("   FROM lancamentos");
            sql.Append("  WHERE lancamentos.anomes IS NULL");
            sql.Append("    AND lancamentos.txNomeParlamentar <> ''");
            sql.Append("    AND lancamentos.ideCadastro        > 0");
            sql.Append("    AND NOT EXISTS (SELECT 1");
            sql.Append("                      FROM parlamentares");
            sql.Append("                     WHERE parlamentares.txNomeParlamentar = lancamentos.txNomeParlamentar)");
            
            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Fornecedor -----------------

            sql.Clear();
            sql.Append(" INSERT INTO fornecedores ("); //Insere apenas o CNPJ porque pode ter várias descrições diferentes.
            sql.Append("        txtCNPJCPF)");
            sql.Append(" SELECT DISTINCT");
            sql.Append("        lancamentos.txtCNPJCPF");
            sql.Append("   FROM lancamentos");
            sql.Append("  WHERE lancamentos.anomes IS NULL");
            sql.Append("    AND lancamentos.txtCNPJCPF <> ''");
            sql.Append("    AND lancamentos.ideCadastro > 0");
            sql.Append("    AND NOT EXISTS (SELECT 1");
            sql.Append("                      FROM fornecedores");
            sql.Append("                     WHERE fornecedores.txtCNPJCPF = lancamentos.txtCNPJCPF)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            sql.Clear();
            sql.Append(" UPDATE fornecedores");
            sql.Append("    SET txtBeneficiario = (SELECT lancamentos.txtBeneficiario");
            sql.Append("                             FROM lancamentos");
            sql.Append("                            WHERE lancamentos.anomes     IS NULL");
            sql.Append("                              AND lancamentos.txtCNPJCPF = fornecedores.txtCNPJCPF LIMIT 1)");
            sql.Append("  WHERE txtBeneficiario IS NULL");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            sql.Clear();
            sql.Append(" UPDATE lancamentos");
            sql.Append("    SET txtBeneficiario = (SELECT fornecedores.txtBeneficiario");
            sql.Append("                             FROM fornecedores");
            sql.Append("                            WHERE fornecedores.txtCNPJCPF = lancamentos.txtCNPJCPF)");
            sql.Append("  WHERE lancamentos.anomes IS NULL");                
            sql.Append("    AND lancamentos.txtCNPJCPF <> ''");
            sql.Append("    AND lancamentos.ideCadastro > 0");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Despesas -----------------

            sql.Clear();
            sql.Append(" INSERT INTO despesas (");
            sql.Append("        numSubCota,");
            sql.Append("        txtDescricao)");
            sql.Append(" SELECT DISTINCT");
            sql.Append("        lancamentos.numSubCota,");
            sql.Append("        lancamentos.txtDescricao");
            sql.Append("   FROM lancamentos");
            sql.Append("  WHERE lancamentos.anomes IS NULL");
            sql.Append("    AND lancamentos.ideCadastro > 0");
            sql.Append("    AND NOT EXISTS (SELECT 1");
            sql.Append("                      FROM despesas");
            sql.Append("                     WHERE despesas.numSubCota = lancamentos.numSubCota)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Partidos -----------------

            sql.Clear();
            sql.Append(" INSERT INTO partidos (");
            sql.Append("        sgPartido)");
            sql.Append(" SELECT DISTINCT");
            sql.Append("        lancamentos.sgPartido");
            sql.Append("   FROM lancamentos");
            sql.Append("  WHERE lancamentos.anomes IS NULL");
            sql.Append("    AND lancamentos.ideCadastro > 0");
            sql.Append("    AND NOT EXISTS (SELECT 1");
            sql.Append("                      FROM partidos");
            sql.Append("                     WHERE partidos.sgPartido = lancamentos.sgPartido)");

            banco.ExecuteNonQuery(sql.ToString(), 0);


            //----------------- Id  -----------------

            sql.Clear();
            sql.Append(" UPDATE lancamentos");
            sql.Append("    SET anomes        = concat(numano, lpad(nummes, 2, '0'))");
            //sql.Append("        idParlamentar = (SELECT idParlamentar");
            //sql.Append("                           FROM parlamentares");
            //sql.Append("                          WHERE parlamentares.txNomeParlamentar = lancamentos.txNomeParlamentar)");
            sql.Append("  WHERE lancamentos.anomes IS NULL");
            sql.Append("    AND lancamentos.ideCadastro > 0");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Parametros -----------------

            sql.Clear();
            sql.Append(" UPDATE parametros");
            sql.Append("    SET ultima_atualizacao = NOW(),");
            sql.Append("        menorAno           = (SELECT MIN(numAno)");
            sql.Append("                                FROM lancamentos");
            sql.Append("                               WHERE lancamentos.ideCadastro > 0)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Valor  ---------------

            sql.Clear();
            sql.Append(" UPDATE lancamentos");
            sql.Append("    SET lancamentos.vlrLiquido = vlrDocumento");
            sql.Append("  WHERE lancamentos.vlrLiquido IS NULL");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            AtualizaFornecedorDoador(banco);

            AtualizaFornecedorUltimaNotaFiscal(banco);
        }

        internal void CarregaValores(System.Web.Caching.Cache cache, ListBox listParlamentar, ListBox listDespesas, ListBox listPartidos)
        {
            MenorAno = DateTime.Today.Year;

            try
            {
                using (Banco banco = new Banco())
                {
                    if (cache["menorAno"] == null)
                    {
                        using (MySqlDataReader reader = banco.ExecuteReader("SELECT * FROM parametros"))
                        {
                            if (reader.Read())
                            {
                                try { MenorAno = Convert.ToInt32(reader["menorAno"]); }
                                catch { MenorAno = DateTime.Today.Year; }

                                try { UltimaAtualizacao = Convert.ToDateTime(reader["ultima_atualizacao"]); }
                                catch { }
                            }

                            reader.Close();
                        }

                        try
                        {
                            cache.Add("menorAno", MenorAno, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            cache.Add("ultima_atualizacao", UltimaAtualizacao, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        MenorAno = Convert.ToInt32(cache["menorAno"]);
                        UltimaAtualizacao = Convert.ToDateTime(cache["ultima_atualizacao"]);
                    }

                    if (cache["tableParlamentar"] == null)
                    {
                        using (DataTable table = banco.GetTable("SELECT ideCadastro, txNomeParlamentar FROM parlamentares ORDER BY txNomeParlamentar"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                listParlamentar.Items.Add(new ListItem(Convert.ToString(row["txNomeParlamentar"]), Convert.ToString(row["ideCadastro"])));
                            }

                            try
                            {
                                cache.Add("tableParlamentar", table, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            }
                            catch(Exception ex)
                            { 
                            }
                        }
                    }
                    else
                    {
                        DataTable table = (DataTable)cache["tableParlamentar"];

                        foreach (DataRow row in table.Rows)
                        {
                            listParlamentar.Items.Add(new ListItem(Convert.ToString(row["txNomeParlamentar"]), Convert.ToString(row["ideCadastro"])));
                        }
                    }

                    if (cache["tableDespesa"] == null)
                    {
                        using (DataTable table = banco.GetTable("SELECT numSubCota, txtDescricao FROM despesas ORDER BY txtDescricao"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                listDespesas.Items.Add(new ListItem(Convert.ToString(row["txtDescricao"]), Convert.ToString(row["numSubCota"])));
                            }

                            try
                            {
                                cache.Add("tableDespesa", table, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {
                        DataTable table = (DataTable)cache["tableDespesa"];

                        foreach (DataRow row in table.Rows)
                        {
                            listDespesas.Items.Add(new ListItem(Convert.ToString(row["txtDescricao"]), Convert.ToString(row["numSubCota"])));
                        }
                    }

                    if (cache["tablePartido"] == null)
                    {
                        using (DataTable table = banco.GetTable("SELECT sgPartido, sgPartido FROM partidos ORDER BY sgPartido"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                listPartidos.Items.Add(new ListItem(Convert.ToString(row["sgPartido"]), Convert.ToString(row["sgPartido"])));
                            }

                            try
                            {
                                cache.Add("tablePartido", table, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {
                        DataTable table = (DataTable)cache["tablePartido"];

                        foreach (DataRow row in table.Rows)
                        {
                            listPartidos.Items.Add(new ListItem(Convert.ToString(row["sgPartido"]), Convert.ToString(row["sgPartido"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgErro = ex.Message;
            }
        }

        internal Boolean CarregaDadosReceitaEleicao(String atualDir, String ano)
        {
            using (Banco banco = new Banco())
            {
                DirectoryInfo dir = new DirectoryInfo(atualDir);

                foreach (FileInfo fileZip in dir.GetFiles("*.zip"))
                {
                    ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                    zip.ExtractZip(fileZip.FullName, fileZip.DirectoryName, null);

                    File.Delete(fileZip.FullName);

                    foreach (FileInfo fileTxt in dir.GetFiles("*.txt", SearchOption.AllDirectories))
                    {
                        if (ProcessaDadosReceitaEleicao(fileTxt.FullName, banco, ano) == false)
                        {
                            return false;
                        }

                        File.Delete(fileTxt.FullName);
                    }
                }

                AtualizaFornecedorDoador(banco);
            }

            return true;
        }

        private Boolean ProcessaDadosReceitaEleicao(String strFileName, Banco banco, String ano)
        {
            try
            {
                using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + ";Extended Properties = \"Text;HDR=YES;FORMAT=Delimited(;)\""))
                {
                    conn.Open();

                    String strQuery = "SELECT * FROM [" + System.IO.Path.GetFileName(strFileName) + "]";
                    String cnpjCpf = "";

                    using (System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn))
                    {
                        using (System.Data.DataSet ds = new System.Data.DataSet("CSV File"))
                        {
                            adapter.Fill(ds);
                            conn.Close();

                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                cnpjCpf = Convert.ToString(row["CPF/CNPJ do doador"]);

                                banco.AddParameter("cargo", Convert.ToString(row["Cargo"]).ToUpper());
                                banco.AddParameter("nomeCandidato", Convert.ToString(row["Nome candidato"]).ToUpper());
                                banco.AddParameter("cpfCandidato", row["CPF do candidato"]);
                                banco.AddParameter("numDocumento", row["Número do documento"]);
                                banco.AddParameter("cnpjCpfDoador", cnpjCpf);
                                banco.AddParameter("dataReceita", Convert.ToDateTime(row["Data da receita"]));
                                banco.AddParameter("valorReceita", Convert.ToDouble(row["Valor receita"]));

                                if (cnpjCpf.Length == 14)
                                    cnpjCpf = cnpjCpf.Substring(0, 8);

                                banco.AddParameter("raizCnpjCpfDoador", cnpjCpf);

                                if (banco.ExecuteNonQuery("INSERT INTO receitas_eleicao (anoEleicao, nomeCandidato, cpfCandidato, cargo, numDocumento, cnpjCpfDoador, raizCnpjCpfDoador, dataReceita, valorReceita) VALUES (" + ano + ", @nomeCandidato, @cpfCandidato, @cargo, @numDocumento, @cnpjCpfDoador, @raizCnpjCpfDoador, @dataReceita, @valorReceita)", 0) == false)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgErro = ex.Message;
                return false;
            }

            return true;
        }

        private void AtualizaFornecedorDoador(Banco banco)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE fornecedores");
            sql.Append("    SET Doador =  EXISTS (SELECT 1");
            sql.Append("                            FROM receitas_eleicao");
            sql.Append("                           WHERE receitas_eleicao.raizCnpjCpfDoador = fornecedores.txtCNPJCPF)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            sql.Clear();
            sql.Append(" UPDATE fornecedores");
            sql.Append("    SET Doador =  EXISTS (SELECT 1");
            sql.Append("                            FROM receitas_eleicao");
            sql.Append("                           WHERE receitas_eleicao.raizCnpjCpfDoador = substring(fornecedores.txtCNPJCPF, 1, 8))");

            banco.ExecuteNonQuery(sql.ToString(), 0);
        }

        private void AtualizaFornecedorUltimaNotaFiscal(Banco banco)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE fornecedores AS F");
            sql.Append("   JOIN (SELECT lancamentos.txtCNPJCPF, MAX(datEmissao) AS datEmissao");
            sql.Append("           FROM lancamentos");
            sql.Append("       GROUP BY lancamentos.txtCNPJCPF");
            sql.Append("          UNION");
            sql.Append("         SELECT lancamentos_senadores.CnpjCpf, MAX(DataDoc)");
            sql.Append("           FROM lancamentos_senadores");
            sql.Append("       GROUP BY lancamentos_senadores.CnpjCpf) AS D");
            sql.Append("     ON F.txtCNPJCPF           = D.txtCNPJCPF");
            sql.Append("    SET F.DataUltimaNotaFiscal = D.datEmissao");
            sql.Append("  WHERE F.txtCNPJCPF IN (SELECT txtCNPJCPF FROM lancamentos_tmp)");

            banco.ExecuteNonQuery(sql.ToString(), 0);
        }
    }
}