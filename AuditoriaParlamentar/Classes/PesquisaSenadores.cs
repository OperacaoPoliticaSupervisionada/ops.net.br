using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace AuditoriaParlamentar.Classes
{
    public class PesquisaSenadores
    {
        public static String AnoMesIni { get; set; }
        public static String AnoMesFim { get; set; }

        internal void Carregar(GridView grid, String userName, String documento, String periodo, String agrupamento, Boolean separarMes, String anoIni, String mesIni, String anoFim, String mesFim, ListItemCollection ItemsParlamentar, ListItemCollection ItemsDespesa, ListItemCollection ItemsFornecedor, ListItemCollection ItemsUF, ListItemCollection ItemsPartidos, string ChavePesquisa)
        {
            using (Banco banco = new Banco())
            {
                Boolean tabSenadores = false;
                StringBuilder sqlCmd = new StringBuilder();
                StringBuilder sqlCampos = new StringBuilder();
                StringBuilder sqlFrom = new StringBuilder();
                StringBuilder sqlWhere = new StringBuilder();

                sqlFrom.Append("   FROM lancamentos_senadores");
                sqlWhere.Append(" WHERE 1 = 1");

                switch (agrupamento)
                {
                    case Pesquisa.AGRUPAMENTO_PARLAMENTAR:
                        sqlCampos.Append("   SELECT senadores.CodigoParlamentar AS codigo,");
                        sqlCampos.Append("          senadores.NomeParlamentar AS agrupamento,");
                        sqlCampos.Append("          senadores.SiglaUF,");
                        sqlCampos.Append("          senadores.SiglaPartido,");
                        sqlCampos.Append("          senadores.url,");

                        sqlWhere.Append(" AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar");
                        sqlFrom.Append(", senadores "); 
                        tabSenadores = true;

                        break;

                    case Pesquisa.AGRUPAMENTO_DESPESA:
                        sqlCampos.Append("   SELECT despesas_senadores.CodigoDespesa AS codigo,");
                        sqlCampos.Append("          despesas_senadores.TipoDespesa AS agrupamento,");

                        sqlFrom.Append(", despesas_senadores");
                        sqlWhere.Append(" AND lancamentos_senadores.CodigoDespesa = despesas_senadores.CodigoDespesa");

                        break;

                    case Pesquisa.AGRUPAMENTO_FORNECEDOR:
                        sqlCampos.Append("   SELECT lancamentos_senadores.CnpjCpf AS codigo,");
                        sqlCampos.Append("          SUBSTRING(IFNULL(fornecedores.txtbeneficiario, lancamentos_senadores.Fornecedor), 1, 50) AS txtbeneficiario,");
                        sqlCampos.Append("          lancamentos_senadores.CnpjCpf AS agrupamento,");
                        sqlCampos.Append("          CASE WHEN UserName IS NULL THEN '' ELSE 'Sim' END AS auditei,");
                        sqlCampos.Append("          fornecedores.DataUltimaNotaFiscal,");
                        sqlCampos.Append("          CASE WHEN doador = 1 THEN 'Sim' ELSE '' END AS doador,");

                        sqlFrom.Append(" LEFT JOIN fornecedores");
                        sqlFrom.Append("        ON fornecedores.txtCNPJCPF = lancamentos_senadores.CnpjCpf");
                        sqlFrom.Append(" LEFT JOIN fornecedores_visitado");
                        sqlFrom.Append("        ON fornecedores_visitado.txtCNPJCPF = lancamentos_senadores.CnpjCpf");
                        sqlFrom.Append("       AND fornecedores_visitado.UserName   = @UserName");

                        banco.AddParameter("UserName", System.Web.HttpContext.Current.User.Identity.Name);

                        break;

                    case Pesquisa.AGRUPAMENTO_PARTIDO:
                        sqlCampos.Append("   SELECT senadores.SiglaPartido AS codigo,");
                        sqlCampos.Append("          senadores.SiglaPartido AS agrupamento,");

                        sqlWhere.Append(" AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar");
                        sqlFrom.Append(", senadores "); 
                        tabSenadores = true;

                        break;

                    case Pesquisa.AGRUPAMENTO_UF:
                        sqlCampos.Append("   SELECT senadores.SiglaUf AS codigo,");
                        sqlCampos.Append("          senadores.SiglaUf AS agrupamento,");

                        sqlWhere.Append(" AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar");
                        sqlFrom.Append(", senadores "); 
                        tabSenadores = true;

                        break;

                    case Pesquisa.AGRUPAMENTO_DOCUMENTO:
                        sqlCampos.Append("   SELECT CONCAT(lancamentos_senadores.Documento, '|', lancamentos_senadores.CnpjCpf) AS codigo,");
                        sqlCampos.Append("          lancamentos_senadores.Documento,");
                        sqlCampos.Append("          lancamentos_senadores.DataDoc,");
                        sqlCampos.Append("          lancamentos_senadores.CnpjCpf AS agrupamento,");
                        sqlCampos.Append("          SUBSTRING(IFNULL(fornecedores.txtbeneficiario, lancamentos_senadores.Fornecedor), 1, 50) AS txtbeneficiario,");
                        sqlCampos.Append("          0, 0, 0,");

                        sqlFrom.Append(" LEFT JOIN fornecedores");
                        sqlFrom.Append("        ON fornecedores.txtCNPJCPF = lancamentos_senadores.CnpjCpf");

                        separarMes = false;

                        break;

                }

                DateTime dataIni = DateTime.Today;
                DateTime dataFim = DateTime.Today;

                switch (periodo)
                {
                    case Pesquisa.PERIODO_MES_ATUAL:
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes = @anoMes");
                        banco.AddParameter("anoMes", dataIni.ToString("yyyyMM"));
                        break;

                    case Pesquisa.PERIODO_MES_ANTERIOR:
                        dataIni = dataIni.AddMonths(-1);
                        dataFim = dataIni.AddMonths(-1);
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes = @anoMes");
                        banco.AddParameter("anoMes", dataIni.ToString("yyyyMM"));
                        break;

                    case Pesquisa.PERIODO_MES_ULT_4:
                        dataIni = dataIni.AddMonths(-3);
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes >= @anoMes");
                        banco.AddParameter("anoMes", dataIni.ToString("yyyyMM"));
                        break;

                    case Pesquisa.PERIODO_ANO_ATUAL:
                        dataIni = new DateTime(dataIni.Year, 1, 1);
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes >= @anoMes");
                        banco.AddParameter("anoMes", dataIni.ToString("yyyyMM"));
                        break;

                    case Pesquisa.PERIODO_MANDATO_53:
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes BETWEEN 200702 AND 201101");
                        break;

                    case Pesquisa.PERIODO_MANDATO_54:
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes BETWEEN 201102 AND 201501");
                        break;

                    case Pesquisa.PERIODO_MANDATO_55:
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes BETWEEN 201502 AND 201901");
                        break;

                    case Pesquisa.PERIODO_ANO_ANTERIOR:
                        dataIni = new DateTime(dataIni.Year, 1, 1).AddYears(-1);
                        dataFim = new DateTime(dataIni.Year, 12, 31);
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes BETWEEN @anoMesIni AND @anoMesFim");
                        banco.AddParameter("anoMesIni", dataIni.ToString("yyyyMM"));
                        banco.AddParameter("anoMesFim", dataFim.ToString("yyyyMM"));
                        break;

                    case Pesquisa.PERIODO_INFORMAR:
                        dataIni = new DateTime(Convert.ToInt32(anoIni), Convert.ToInt32(mesIni), 1);
                        dataFim = new DateTime(Convert.ToInt32(anoFim), Convert.ToInt32(mesFim), 1);
                        sqlWhere.Append(" AND lancamentos_senadores.anoMes BETWEEN @anoMesIni AND @anoMesFim");
                        banco.AddParameter("anoMesIni", dataIni.ToString("yyyyMM"));
                        banco.AddParameter("anoMesFim", dataFim.ToString("yyyyMM"));
                        break;
                }

                Int32 numMes = 0;

                if (separarMes == true)
                {
                    numMes = ((dataFim.Year - dataIni.Year) * 12) + dataFim.Month - dataIni.Month + 1;
                    DateTime dataIniTemp = new DateTime(dataIni.Year, dataIni.Month, 1);

                    for (Int32 i = 0; i < numMes; i++)
                    {
                        sqlCampos.Append("SUM(CASE WHEN anoMes = @AnoMes" + i.ToString() + " THEN Valor ELSE 0 END) AS '" + dataIniTemp.ToString("MM-yyyy") + "',");
                        banco.AddParameter("AnoMes" + i.ToString(), dataIniTemp.ToString("yyyyMM"));
                        dataIniTemp = dataIniTemp.AddMonths(1);
                    }
                }

                sqlCampos.Append(" SUM(lancamentos_senadores.Valor) AS vlrTotal");

                if (ItemsParlamentar != null)
                {
                    if (ItemsParlamentar.Count > 0)
                    {
                        if (ItemsParlamentar.Count == 1)
                        {
                            sqlWhere.Append(" AND lancamentos_senadores.CodigoParlamentar = " + ItemsParlamentar[0].Value.ToString());
                        }
                        else
                        {
                            StringBuilder values = new StringBuilder();
                            for (Int32 i = 0; i < ItemsParlamentar.Count; i++)
                            {
                                if (i == 0)
                                    values.Append(ItemsParlamentar[i].Value.ToString());
                                else
                                    values.Append("," + ItemsParlamentar[i].Value.ToString());
                            }

                            sqlWhere.Append(" AND lancamentos_senadores.CodigoParlamentar IN (" + values.ToString() + ")");
                        }
                    }
                }

                if (ItemsDespesa != null)
                {
                    if (ItemsDespesa.Count > 0)
                    {
                        if (ItemsDespesa.Count == 1)
                        {
                            sqlWhere.Append(" AND lancamentos_senadores.CodigoDespesa = " + ItemsDespesa[0].Value.ToString());
                        }
                        else
                        {
                            StringBuilder values = new StringBuilder();
                            for (Int32 i = 0; i < ItemsDespesa.Count; i++)
                            {
                                if (i == 0)
                                    values.Append(ItemsDespesa[i].Value.ToString());
                                else
                                    values.Append("," + ItemsDespesa[i].Value.ToString());
                            }

                            sqlWhere.Append(" AND lancamentos_senadores.CodigoDespesa IN (" + values.ToString() + ")");
                        }
                    }
                }

                if (ItemsFornecedor != null)
                {
                    if (ItemsFornecedor.Count > 0)
                    {
                        if (ItemsFornecedor.Count == 1)
                        {
                            sqlWhere.Append(" AND lancamentos_senadores.CNPJCPF = '" + ItemsFornecedor[0].Value.ToString() + "'");
                        }
                        else
                        {
                            StringBuilder values = new StringBuilder();
                            for (Int32 i = 0; i < ItemsFornecedor.Count; i++)
                            {
                                if (i == 0)
                                    values.Append("'" + ItemsFornecedor[i].Value.ToString() + "'");
                                else
                                    values.Append(",'" + ItemsFornecedor[i].Value.ToString() + "'");
                            }

                            sqlWhere.Append(" AND lancamentos_senadores.CNPJCPF IN (" + values.ToString() + ")");
                        }
                    }
                }

                if (ItemsUF != null)
                {
                    if (ItemsUF.Count > 0)
                    {
                        if (ItemsUF.Count == 1)
                        {
                            sqlWhere.Append(" AND senadores.SiglaUf = '" + ItemsUF[0].Value.ToString() + "'");
                        }
                        else
                        {
                            StringBuilder values = new StringBuilder();
                            for (Int32 i = 0; i < ItemsUF.Count; i++)
                            {
                                if (i == 0)
                                    values.Append("'" + ItemsUF[i].Value.ToString() + "'");
                                else
                                    values.Append(",'" + ItemsUF[i].Value.ToString() + "'");
                            }

                            sqlWhere.Append(" AND senadores.SiglaUf IN (" + values.ToString() + ")");
                        }

                        if (tabSenadores == false)
                        {
                            sqlWhere.Append(" AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar");
                            sqlFrom.Append(", senadores");
                            tabSenadores = true;
                        }
                    }
                }

                if (ItemsPartidos != null)
                {
                    if (ItemsPartidos.Count > 0)
                    {
                        if (ItemsPartidos.Count == 1)
                        {
                            sqlWhere.Append(" AND senadores.SiglaPartido = '" + ItemsPartidos[0].Value.ToString() + "'");
                        }
                        else
                        {
                            StringBuilder values = new StringBuilder();
                            for (Int32 i = 0; i < ItemsPartidos.Count; i++)
                            {
                                if (i == 0)
                                    values.Append("'" + ItemsPartidos[i].Value.ToString() + "'");
                                else
                                    values.Append(",'" + ItemsPartidos[i].Value.ToString() + "'");
                            }

                            sqlWhere.Append(" AND senadores.SiglaPartido IN (" + values.ToString() + ")");
                        }

                        if (tabSenadores == false)
                        {
                            sqlWhere.Append(" AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar");
                            sqlFrom.Append(", senadores");
                            tabSenadores = true;
                        }
                    }
                }

                if (documento != null && documento != "")
                {
                    String[] valores = documento.Split('|');
                    sqlWhere.Append(" AND lancamentos_senadores.Documento = '" + valores[0].Trim() + "'");
                    sqlWhere.Append(" AND lancamentos_senadores.CnpjCpf   = '" + valores[1].Trim() + "'");
                }

                sqlCmd.Append(sqlCampos.ToString());
                sqlCmd.Append(sqlFrom.ToString());
                sqlCmd.Append(sqlWhere.ToString());

                switch (agrupamento)
                {
                    case Pesquisa.AGRUPAMENTO_PARLAMENTAR:
                        sqlCmd.Append(" GROUP BY 1, 2, 3, 4, 5");

                        if (separarMes == true)
                            sqlCmd.Append(" ORDER BY " + (numMes + 6).ToString() + " DESC");
                        else
                            sqlCmd.Append(" ORDER BY 6 DESC");

                        break;

                    case Pesquisa.AGRUPAMENTO_DESPESA:
                    case Pesquisa.AGRUPAMENTO_PARTIDO:
                    case Pesquisa.AGRUPAMENTO_UF:
                        sqlCmd.Append(" GROUP BY 1, 2");

                        if (separarMes == true)
                            sqlCmd.Append(" ORDER BY " + (numMes + 3).ToString() + " DESC");
                        else
                            sqlCmd.Append(" ORDER BY 3 DESC");

                        break;

                    case Pesquisa.AGRUPAMENTO_FORNECEDOR:
                        sqlCmd.Append(" GROUP BY 1, 2, 3, 4, 5, 6");

                        if (separarMes == true)
                            sqlCmd.Append(" ORDER BY " + (numMes + 7).ToString() + " DESC");
                        else
                            sqlCmd.Append(" ORDER BY 7 DESC");

                        break;

                    case Pesquisa.AGRUPAMENTO_DOCUMENTO:
                        sqlCmd.Append(" GROUP BY 1, 2, 3, 4, 5, 6, 7, 8");

                        //if (separarMes == true)
                        //    sqlCmd.Append(" ORDER BY " + (numMes + 6).ToString() + " DESC");
                        //else
                        //    sqlCmd.Append(" ORDER BY 6 DESC");

                        sqlCmd.Append(" ORDER BY lancamentos_senadores.DataDoc");

                        break;
                }

                sqlCmd.Append(" LIMIT 1000");

                DbEstatisticas.InsereEstatisticaPesquisa("SENADOR", agrupamento, periodo, userName, sqlCmd.ToString(), anoIni, mesIni, anoFim, mesFim);

                using (MySqlDataReader reader = banco.ExecuteReader(sqlCmd.ToString(), 300))
                {
                    DataTable table = new DataTable("agrupamento");
                    table.Load(reader);

                    if (agrupamento == Pesquisa.AGRUPAMENTO_DOCUMENTO)
                    {
                        Int64 recibo = 0;

                        foreach (DataRow row in table.Rows)
                        {
                            if (Int64.TryParse(row[1].ToString(), out recibo))
                                row[1] = recibo.ToString("000000000");
                        }
                    }


                    FormataColunas(agrupamento, table);

                    HttpContext.Current.Session["AuditoriaUltimaConsulta" + ChavePesquisa] = table;
                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        private Int32 BuscaInicioMandato(Int32 ano)
        {
            Int32 anoIni = 2011;
            Int32 dif = ano - anoIni;

            while (dif > 3)
            {
                anoIni += 4; ;
                dif -= 4;
            }

            return anoIni;
        }

        private void FormataColunas(String agrupamento, DataTable table)
        {
            switch (agrupamento)
            {
                case Pesquisa.AGRUPAMENTO_PARLAMENTAR:
                    table.Columns[1].ColumnName = "Senador";
                    table.Columns[2].ColumnName = "UF";
                    table.Columns[3].ColumnName = "Partido";
                    table.Columns[table.Columns.Count - 1].ColumnName = "Valor Total";
                    break;

                case Pesquisa.AGRUPAMENTO_DESPESA:
                    table.Columns[1].ColumnName = "Despesa";
                    table.Columns[table.Columns.Count - 1].ColumnName = "Valor Total";
                    break;

                case Pesquisa.AGRUPAMENTO_FORNECEDOR:
                    table.Columns[1].ColumnName = "Razão Social";
                    table.Columns[2].ColumnName = "CNPJ/CPF";

                    //Setar a INDEX_COLUNA_AUDITEI
                    table.Columns[3].ColumnName = "Auditei?";

                    table.Columns[4].ColumnName = "Última NF";
                    table.Columns[5].ColumnName = "Doador?";
                    table.Columns[table.Columns.Count - 1].ColumnName = "Valor Total";
                    break;

                case Pesquisa.AGRUPAMENTO_PARTIDO:
                    table.Columns[1].ColumnName = "Partido";
                    table.Columns[table.Columns.Count - 1].ColumnName = "Valor Total";
                    break;

                case Pesquisa.AGRUPAMENTO_UF:
                    table.Columns[1].ColumnName = "UF";
                    table.Columns[table.Columns.Count - 1].ColumnName = "Valor Total";
                    break;

                case Pesquisa.AGRUPAMENTO_DOCUMENTO:
                    table.Columns[1].ColumnName = "NF/Recibo";
                    table.Columns[2].ColumnName = "Data Emissão";
                    table.Columns[3].ColumnName = "CNPJ/CPF";
                    table.Columns[4].ColumnName = "Razão Social/Nome";
                    table.Columns[table.Columns.Count - 1].ColumnName = "Valor Total";
                    break;
            }
        }

        internal void DocumentosFornecedor(GridView grid, String cnpj, String codParlamentar)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT DISTINCT");
            sql.Append("          lancamentos_senadores.Senador,");
            sql.Append("          lancamentos_senadores.Documento,");
            sql.Append("          lancamentos_senadores.DataDoc,");
            sql.Append("          lancamentos_senadores.Valor,");
            sql.Append("          0,");
            sql.Append("          0,");
            sql.Append("          0");
            sql.Append("     FROM lancamentos_senadores");
            sql.Append("    WHERE lancamentos_senadores.CnpjCpf           = @txtCNPJCPF");
            sql.Append("      AND lancamentos_senadores.CodigoParlamentar = @CodigoParlamentar");
            sql.Append(" ORDER BY 1, 3 DESC");
            sql.Append("    LIMIT 1000");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", cnpj);
                banco.AddParameter("CodigoParlamentar", codParlamentar);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("lancamentos");
                    table.Load(reader);

                    Int64 recibo = 0;

                    foreach (DataRow row in table.Rows)
                    {
                        if (Int64.TryParse(row[1].ToString(), out recibo))
                            row[1] = recibo.ToString("000000000");
                    }

                    table.Columns[0].ColumnName = "Senador";
                    table.Columns[1].ColumnName = "NF/Recibo";
                    table.Columns[2].ColumnName = "Data Emissão";
                    table.Columns[3].ColumnName = "Valor Documento";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }
    }
}