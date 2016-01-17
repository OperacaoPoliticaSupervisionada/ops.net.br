using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Net;

namespace AuditoriaParlamentar.Classes
{
    public class DadosSenadores
    {
        internal Int32 MenorAno { get; set; }
        internal DateTime UltimaAtualizacao { get; set; }
        internal String DirFiguras { get; set; }
        internal String MsgErro { get; set; }

        internal Boolean CarregaDados(String file, Boolean diferenca, GridView grid)
        {
            using (Banco banco = new Banco())
            {
                if (CarregaSenadores(banco) == false)
                    return false;
                
                if (CarregaDadosTmpProcessa(file, banco) == false)
                {
                    return false;
                }

                PreviaDados(grid, banco);

                //DownaloadFotosProcessa(banco);
            }

            return true;
        }


        private void PreviaDados(GridView grid, Banco banco)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT DISTINCT");
            sql.Append("       lancamentos_senadores_tmp.Senador");
            sql.Append("  FROM lancamentos_senadores_tmp");
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

        private Boolean CarregaSenadores(Banco banco)
        {
            //StringBuilder email = new StringBuilder();

            try
            {
                banco.ExecuteNonQuery("UPDATE senadores SET Ativo = 'N'");

                using (DataSet senado = new DataSet())
                {
                    senado.ReadXml("http://legis.senado.gov.br/dadosabertos/senador/lista/atual");

                    using (DataTable senadores = senado.Tables["IdentificacaoParlamentar"])
                    {
                        foreach (DataRow senador in senadores.Rows)
                        {
                            //email.Append(Convert.ToString(senador["EnderecoEletronico"]) + ";");

                            try
                            {
                                banco.AddParameter("CodigoParlamentar", Convert.ToInt32(senador["CodigoParlamentar"]));
                                banco.AddParameter("NomeParlamentar", Convert.ToString(senador["NomeParlamentar"]).ToUpper());
                                banco.AddParameter("Url", Convert.ToString(senador["UrlPaginaParlamentar"]));
                                banco.AddParameter("Foto", Convert.ToString(senador["UrlFotoParlamentar"]));
                                banco.AddParameter("SiglaPartido", Convert.ToString(senador["SiglaPartidoParlamentar"]));
                                banco.AddParameter("SiglaUf", Convert.ToString(senador["UfParlamentar"]));
                                // Ao invés de gravar o fim do mandato grava o início
                                //banco.AddParameter("MandatoAtual", Convert.ToDateTime(senador["MandatoAtual"]).AddYears(-9).ToString("yyyyMM"));
                                banco.ExecuteNonQuery("INSERT INTO senadores (CodigoParlamentar, NomeParlamentar, Url, Foto, SiglaPartido, SiglaUf, Ativo) VALUES (@CodigoParlamentar, @NomeParlamentar, @Url, @Foto, @SiglaPartido, @SiglaUf, 'S')");
                            }
                            catch
                            {
                                banco.AddParameter("Url", Convert.ToString(senador["UrlPaginaParlamentar"]));
                                banco.AddParameter("Foto", Convert.ToString(senador["UrlFotoParlamentar"]));
                                banco.AddParameter("SiglaPartido", Convert.ToString(senador["SiglaPartidoParlamentar"]));
                                banco.AddParameter("SiglaUf", Convert.ToString(senador["UfParlamentar"]));
                                banco.AddParameter("CodigoParlamentar", Convert.ToInt32(senador["CodigoParlamentar"]));
                                // Ao invés de gravar o fim do mandato grava o início
                                //banco.AddParameter("MandatoAtual", Convert.ToDateTime(senador["MandatoAtual"]).AddYears(-9).ToString("yyyyMM"));
                                banco.ExecuteNonQuery("UPDATE senadores SET Url = @Url, Foto = @Foto, SiglaPartido = @SiglaPartido, SiglaUf = @SiglaUf, Ativo = 'S' WHERE CodigoParlamentar = @CodigoParlamentar");
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

        private Boolean CarregaDadosTmpProcessa(String file, Banco banco)
        {
            banco.ExecuteNonQuery("TRUNCATE lancamentos_senadores_tmp");

            if (CarregaDadosCsv(file, banco, "lancamentos_senadores_tmp") == false)
                return false;

            //----------------- Ajustes -----------------
            banco.ExecuteNonQuery("UPDATE lancamentos_senadores_tmp SET TipoDespesa = 'Aquisição de material de consumo para uso no escritório político' WHERE TipoDespesa LIKE 'Aquisição de material de consumo para uso no escritório político%'", 0);
            banco.ExecuteNonQuery("UPDATE lancamentos_senadores_tmp SET TipoDespesa = 'Contratação de consultorias, assessorias, pesquisas, trabalhos técnicos e outros serviços' WHERE TipoDespesa LIKE 'Contratação de consultorias, assessorias, pesquisas, trabalhos técnicos e outros serviços%'", 0);


            if (AtualizaSenadores(banco, "lancamentos_senadores_tmp") == false)
                return false;

            return true;
        }

        private Boolean AtualizaSenadores(Banco banco, String tabela)
        {
            try
            {
                banco.ExecuteNonQuery("UPDATE " + tabela + " SET CodigoParlamentar = (SELECT CodigoParlamentar FROM senadores WHERE NomeParlamentar = Senador)");

                Object retorno = banco.ExecuteScalar("SELECT COUNT(*) FROM " + tabela + " WHERE CodigoParlamentar IS NULL");

                if (Convert.ToInt32(retorno) > 0)
                {
                    MsgErro = "Não foi possível atualizar todos os senadores.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                MsgErro = ex.Message;
                return false;
            }

            return true;
        }

        private void CarregaDadosProcessa(Banco banco)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT ano,");
            sql.Append("          mes,");
            sql.Append("          CodigoParlamentar");
            sql.Append("     FROM lancamentos_senadores_tmp");
            sql.Append(" GROUP BY 1,2,3");
            sql.Append("   HAVING SUM(valor) <> IFNULL((SELECT SUM(valor)");
            sql.Append("                                  FROM lancamentos_senadores");
            sql.Append("                                 WHERE lancamentos_senadores.ano               = lancamentos_senadores_tmp.ano");
            sql.Append("                                   AND lancamentos_senadores.mes               = lancamentos_senadores_tmp.mes");
            sql.Append("                                   AND lancamentos_senadores.CodigoParlamentar = lancamentos_senadores_tmp.CodigoParlamentar), 0)");

            using (DataTable table = banco.GetTable(sql.ToString(), 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    banco.AddParameter("ano", row["ano"]);
                    banco.AddParameter("mes", row["mes"]);
                    banco.AddParameter("CodigoParlamentar", row["CodigoParlamentar"]);
                    banco.ExecuteNonQuery("DELETE FROM lancamentos_senadores WHERE ano = @ano AND mes = @mes AND CodigoParlamentar = @CodigoParlamentar", 0);

                    sql.Clear();
                    sql.Append("INSERT INTO lancamentos_senadores (Ano, Mes, CodigoParlamentar, Senador, TipoDespesa, CnpjCpf, Fornecedor, Documento, DataDoc, Detalhamento, Valor)");
                    sql.Append("SELECT Ano, Mes, CodigoParlamentar, Senador, TipoDespesa, CnpjCpf, UPPER(Fornecedor), Documento, DataDoc, Detalhamento, Valor");
                    sql.Append("  FROM lancamentos_senadores_tmp");
                    sql.Append(" WHERE lancamentos_senadores_tmp.ano               = @ano");
                    sql.Append("   AND lancamentos_senadores_tmp.mes               = @mes");
                    sql.Append("   AND lancamentos_senadores_tmp.CodigoParlamentar = @CodigoParlamentar");

                    banco.AddParameter("ano", row["ano"]);
                    banco.AddParameter("mes", row["mes"]);
                    banco.AddParameter("CodigoParlamentar", row["CodigoParlamentar"]);
                    banco.ExecuteNonQuery(sql.ToString(), 0);
                }
            }
        }

        private Boolean CarregaDadosCsv(String file, Banco banco, String tabela)
        {
            try
            {
                using (StreamReader reader = new StreamReader(file, Encoding.GetEncoding("ISO-8859-1")))
                {
                    Int16 count = 0;

                    while (!reader.EndOfStream)
                    {
                        count++;

                        String line = reader.ReadLine();

                        List<String> values = ParseRowToList(line);
                        
                        if (count == 1) //Pula primeira linha
                            continue;

                        if (count == 2)
                        {
                            if (values[0] != "ANO" ||
                                values[1] != "MES" ||
                                values[2] != "SENADOR" ||
                                values[3] != "TIPO_DESPESA" ||
                                values[4] != "CNPJ_CPF" ||
                                values[5] != "FORNECEDOR" ||
                                values[6] != "DOCUMENTO" ||
                                values[7] != "DATA" ||
                                values[8] != "DETALHAMENTO" ||
                                values[9] != "VALOR_REEMBOLSADO")
                            {
                                return false;
                            }

                            continue;
                        }

                        String cnpj;

                        banco.AddParameter("Ano", Convert.ToInt32(values[0]));
                        banco.AddParameter("Mes", Convert.ToInt32(values[1]));
                        banco.AddParameter("Senador", values[2]);
                        banco.AddParameter("TipoDespesa", values[3]);
                        banco.AddParameter("Fornecedor", values[5]);
                        banco.AddParameter("Documento", values[6]);
                        banco.AddParameter("Detalhamento", values[8]);
                        banco.AddParameter("Valor", Convert.ToDouble(values[9]));

                        try { banco.AddParameter("DataDoc", Convert.ToDateTime(values[7])); }
                        catch { banco.AddParameter("DataDoc", DBNull.Value); }

                        try
                        {
                            if (values[4].IndexOf("/") > 0)
                                cnpj = Convert.ToInt64(values[4].Replace(".", "").Replace("-", "").Replace("/", "")).ToString("00000000000000");
                            else
                                cnpj = Convert.ToInt64(values[4].Replace(".", "").Replace("-", "")).ToString("00000000000");
                        }
                        catch
                        {
                            cnpj = "";
                        }

                        banco.AddParameter("CnpjCpf", cnpj);

                        banco.ExecuteNonQuery("INSERT INTO lancamentos_senadores_tmp (Ano, Mes, Senador, TipoDespesa, CnpjCpf, Fornecedor, Documento, DataDoc, Detalhamento, Valor) VALUES (@Ano, @Mes, @Senador, @TipoDespesa, @CnpjCpf, @Fornecedor, @Documento, @DataDoc, @Detalhamento, @Valor)");
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

        private List<String> ParseRowToList(String row)
        {
            List<String> returnValue = new List<String>();

            if (row.IndexOf("\";") > -1)
            {// There are more columns
                returnValue = ParseRowToList(row.Substring(row.IndexOf("\";") + 2));
                returnValue.Insert(0, row.Substring(1, row.IndexOf("\";") - 1));
            }
            else
            {// This is the last column
                returnValue.Add(row.Substring(1, row.Length - 2));
            }

            return returnValue;
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
                using (DataTable table = banco.GetTable("SELECT * FROM senadores", 0))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (!File.Exists(DirFiguras + @"\Parlamentares\SENADOR\" + row["CodigoParlamentar"].ToString() + ".jpg"))
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.Headers.Add("User-Agent: Other");
                                client.DownloadFile(row["Foto"].ToString(), DirFiguras + @"\Parlamentares\SENADOR\" + row["CodigoParlamentar"].ToString() + ".jpg");
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

            //----------------- Fornecedor -----------------
            sql.Clear();
            sql.Append(" INSERT INTO fornecedores (");
            sql.Append("        txtCNPJCPF)");
            sql.Append(" SELECT DISTINCT");
            sql.Append("        lancamentos_senadores.CnpjCpf");
            sql.Append("   FROM lancamentos_senadores");
            sql.Append("  WHERE lancamentos_senadores.anomes IS NULL");
            sql.Append("    AND lancamentos_senadores.CnpjCpf <> ''");
            sql.Append("    AND NOT EXISTS (SELECT 1");
            sql.Append("                      FROM fornecedores");
            sql.Append("                     WHERE fornecedores.txtCNPJCPF = lancamentos_senadores.CnpjCpf)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            sql.Clear();
            sql.Append(" UPDATE fornecedores");
            sql.Append("    SET txtBeneficiario = (SELECT lancamentos_senadores.Fornecedor");
            sql.Append("                             FROM lancamentos_senadores");
            sql.Append("                            WHERE lancamentos_senadores.anomes     IS NULL");
            sql.Append("                              AND lancamentos_senadores.CnpjCpf = fornecedores.txtCNPJCPF LIMIT 1)");
            sql.Append("  WHERE txtBeneficiario IS NULL");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            sql.Clear();
            sql.Append(" UPDATE lancamentos_senadores");
            sql.Append("    SET Fornecedor = (SELECT fornecedores.txtBeneficiario");
            sql.Append("                        FROM fornecedores");
            sql.Append("                       WHERE fornecedores.txtCNPJCPF = lancamentos_senadores.CnpjCpf)");
            sql.Append("  WHERE lancamentos_senadores.anomes IS NULL");
            sql.Append("    AND lancamentos_senadores.CnpjCpf <> ''");

            banco.ExecuteNonQuery(sql.ToString(), 0);
                    
            //----------------- Despesas -----------------

            sql.Clear();
            sql.Append(" INSERT INTO despesas_senadores (");
            sql.Append("        TipoDespesa)");
            sql.Append(" SELECT DISTINCT");
            sql.Append("        lancamentos_senadores.TipoDespesa");
            sql.Append("   FROM lancamentos_senadores");
            sql.Append("  WHERE lancamentos_senadores.anomes IS NULL");
            sql.Append("    AND NOT EXISTS (SELECT 1");
            sql.Append("                      FROM despesas_senadores");
            sql.Append("                     WHERE despesas_senadores.TipoDespesa = lancamentos_senadores.TipoDespesa)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            sql.Clear();
            sql.Append(" UPDATE lancamentos_senadores");
            sql.Append("    SET CodigoDespesa = (SELECT despesas_senadores.CodigoDespesa");
            sql.Append("                           FROM despesas_senadores");
            sql.Append("                          WHERE despesas_senadores.TipoDespesa = lancamentos_senadores.TipoDespesa)");
            sql.Append("  WHERE lancamentos_senadores.anomes        IS NULL");
            sql.Append("    AND lancamentos_senadores.CodigoDespesa IS NULL");

            banco.ExecuteNonQuery(sql.ToString(), 0);
                    
            //----------------- Partidos -----------------

            sql.Clear();
            sql.Append(" INSERT INTO partidos_senadores (");
            sql.Append("        SiglaPartido)");
            sql.Append(" SELECT DISTINCT");
            sql.Append("        senadores.SiglaPartido");
            sql.Append("   FROM senadores");
            sql.Append("  WHERE NOT EXISTS (SELECT 1");
            sql.Append("                      FROM partidos_senadores");
            sql.Append("                     WHERE partidos_senadores.SiglaPartido = senadores.SiglaPartido)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Id  -----------------

            sql.Clear();
            sql.Append(" UPDATE lancamentos_senadores");
            sql.Append("    SET lancamentos_senadores.anomes = concat(ano, lpad(mes, 2, '0'))");
            sql.Append("  WHERE lancamentos_senadores.anomes IS NULL");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Parametros -----------------

            sql.Clear();
            sql.Append(" UPDATE parametros");
            sql.Append("    SET ultimaAtualizacaoSenadores = NOW(),");
            sql.Append("        menorAnoSenadores          = (SELECT MIN(ano) FROM lancamentos_senadores)");

            banco.ExecuteNonQuery(sql.ToString(), 0);

            //----------------- Despesas Mandato -----------------
            //sql.Clear();
            //sql.Append(" UPDATE senadores");
            //sql.Append("    SET DespesasMandato = (SELECT SUM(lancamentos_senadores.Valor)");
            //sql.Append("                             FROM lancamentos_senadores");
            //sql.Append("                            WHERE lancamentos_senadores.CodigoParlamentar  = senadores.CodigoParlamentar");
            //sql.Append("                              AND lancamentos_senadores.anoMes            >= senadores.MandatoAtual)");

            //banco.ExecuteNonQuery(sql.ToString(), 0);

            AtualizaFornecedorUltimaNotaFiscal(banco);
        }

        internal void CarregaValores(System.Web.Caching.Cache cache, ListBox listParlamentar, ListBox listDespesas, ListBox listPartidos)
        {
            MenorAno = DateTime.Today.Year;

            try
            {
                using (Banco banco = new Banco())
                {
                    if (cache["menorAnoSenadores"] == null)
                    {
                        using (MySqlDataReader reader = banco.ExecuteReader("SELECT * FROM parametros"))
                        {
                            if (reader.Read())
                            {
                                try { MenorAno = Convert.ToInt32(reader["menorAnoSenadores"]); }
                                catch { MenorAno = DateTime.Today.Year; }

                                try { UltimaAtualizacao = Convert.ToDateTime(reader["ultimaAtualizacaoSenadores"]); }
                                catch { }
                            }

                            reader.Close();
                        }

                        try
                        {
                            cache.Add("menorAnoSenadores", MenorAno, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            cache.Add("ultimaAtualizacaoSenadores", UltimaAtualizacao, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        MenorAno = Convert.ToInt32(cache["menorAnoSenadores"]);
                        UltimaAtualizacao = Convert.ToDateTime(cache["ultimaAtualizacaoSenadores"]);
                    }

                    if (cache["tableSenadores"] == null)
                    {
                        using (DataTable table = banco.GetTable("SELECT CodigoParlamentar, NomeParlamentar FROM senadores ORDER BY NomeParlamentar"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                listParlamentar.Items.Add(new ListItem(Convert.ToString(row["NomeParlamentar"]), Convert.ToString(row["CodigoParlamentar"])));
                            }

                            try
                            {
                                cache.Add("tableSenadores", table, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {
                        DataTable table = (DataTable)cache["tableSenadores"];

                        foreach (DataRow row in table.Rows)
                        {
                            listParlamentar.Items.Add(new ListItem(Convert.ToString(row["NomeParlamentar"]), Convert.ToString(row["CodigoParlamentar"])));
                        }
                    }

                    if (cache["tableDespesaSenadores"] == null)
                    {
                        using (DataTable table = banco.GetTable("SELECT CodigoDespesa, TipoDespesa FROM despesas_senadores ORDER BY TipoDespesa"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                listDespesas.Items.Add(new ListItem(Convert.ToString(row["TipoDespesa"]), Convert.ToString(row["CodigoDespesa"])));
                            }

                            try
                            {
                                cache.Add("tableDespesaSenadores", table, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {
                        DataTable table = (DataTable)cache["tableDespesaSenadores"];

                        foreach (DataRow row in table.Rows)
                        {
                            listDespesas.Items.Add(new ListItem(Convert.ToString(row["TipoDespesa"]), Convert.ToString(row["CodigoDespesa"])));
                        }
                    }

                    if (cache["tablePartidoSenadores"] == null)
                    {
                        using (DataTable table = banco.GetTable("SELECT SiglaPartido, SiglaPartido FROM partidos_senadores ORDER BY SiglaPartido"))
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                listPartidos.Items.Add(new ListItem(Convert.ToString(row["SiglaPartido"]), Convert.ToString(row["SiglaPartido"])));
                            }

                            try
                            {
                                cache.Add("tablePartidoSenadores", table, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {
                        DataTable table = (DataTable)cache["tablePartidoSenadores"];

                        foreach (DataRow row in table.Rows)
                        {
                            listPartidos.Items.Add(new ListItem(Convert.ToString(row["SiglaPartido"]), Convert.ToString(row["SiglaPartido"])));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgErro = ex.Message;
            }
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
            sql.Append("  WHERE F.txtCNPJCPF IN (SELECT CnpjCpf FROM lancamentos_senadores_tmp)");

            banco.ExecuteNonQuery(sql.ToString(), 0);
        }
    }
}