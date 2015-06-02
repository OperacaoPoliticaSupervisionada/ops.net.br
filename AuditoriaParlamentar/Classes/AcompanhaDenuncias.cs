using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace AuditoriaParlamentar.Classes
{
    public class AcompanhaDenuncias
    {
        internal void DenunciasParlamentarFornecedor(GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT lancamentos.txNomeParlamentar,");
		    sql.Append("       fornecedores.txtCNPJCPF,");
		    sql.Append("       fornecedores.txtBeneficiario,");
		    sql.Append("       SUM(lancamentos.vlrLiquido)");
            sql.Append("  FROM lancamentos, fornecedores");
            sql.Append(" WHERE fornecedores.txtCNPJCPF = lancamentos.txtCNPJCPF");
            sql.Append("   AND fornecedores.txtCNPJCPF IN (SELECT denuncias.txtCNPJCPF");
			sql.Append("                                     FROM denuncias");
			sql.Append("                                    WHERE denuncias.Situacao = 'D') ");
            sql.Append(" GROUP BY 1, 2, 3");
            sql.Append(" ORDER BY 1");

            using (Banco banco = new Banco())
            {
                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Parlamentar";
                    table.Columns[1].ColumnName = "CPF/CNPJ";
                    table.Columns[2].ColumnName = "Razão Social";
                    table.Columns[3].ColumnName = "Valor";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void DenunciasParlamentarFornecedor(DropDownList listParlamentar, String cnpj)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("    SELECT senadores.CodigoParlamentar AS codigo,");
            sql.Append("           CONCAT(senadores.NomeParlamentar, ' (SENADOR)') AS nome");
            sql.Append("      FROM lancamentos_senadores, senadores");
            sql.Append("     WHERE lancamentos_senadores.CnpjCpf           = @txtCNPJCPF");
            sql.Append("       AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar");
            sql.Append("  GROUP BY 1, 2");
            sql.Append(" UNION ALL");
            sql.Append("    SELECT lancamentos.ideCadastro AS codigo,");
            sql.Append("           CONCAT(lancamentos.txNomeParlamentar, ' (DEPUTADO FEDERAL)') AS nome");
            sql.Append("      FROM lancamentos");
            sql.Append("     WHERE lancamentos.txtCNPJCPF = @txtCNPJCPF");
            sql.Append("  GROUP BY 1, 2");
            sql.Append("  ORDER BY 2");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", cnpj);

                using (DataTable table = banco.GetTable(sql.ToString(), 300))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        listParlamentar.Items.Add(new ListItem(Convert.ToString(row["nome"]), Convert.ToString(row["codigo"])));
                    }
                }
            }
        }

        internal Int32 TotalDenuncias(System.Web.Caching.Cache cache)
        {
            Int32 total = 0;

            if (cache["TotalDenuncias"] == null)
            {
                using (Banco banco = new Banco())
                {
                    Object retorno = banco.ExecuteScalar("SELECT COUNT(*) FROM denuncias", 300);

                    if (retorno != null)
                    {
                        total = Convert.ToInt32(retorno);
                    }
                }

                try
                {
                    cache.Add("TotalDenuncias", total, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                total = Convert.ToInt32(cache["TotalDenuncias"]);
            }

            return total;
        }

        internal Int32 TotalFornecedoresDenunciados(System.Web.Caching.Cache cache)
        {
            Int32 total = 0;

            if (cache["TotalFornecedoresDenunciados"] == null)
            {
                using (Banco banco = new Banco())
                {
                    Object retorno = banco.ExecuteScalar("SELECT COUNT(DISTINCT txtCNPJCPF) FROM denuncias WHERE Situacao = '" + Denuncia.SITUACAO_CASO_DOSSIE + "'", 300);

                    if (retorno != null)
                    {
                        total = Convert.ToInt32(retorno);
                    }
                }

                try
                {
                    cache.Add("TotalFornecedoresDenunciados", total, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                total = Convert.ToInt32(cache["TotalFornecedoresDenunciados"]);
            }

            return total;
        }

        internal Int32 TotalParlamentaresAtingidos(System.Web.Caching.Cache cache)
        {
            Int32 total = 0;

            if (cache["TotalParlamentaresAtingidos"] == null)
            {
                using (Banco banco = new Banco())
                {
                    Object retorno = banco.ExecuteScalar("SELECT COUNT(DISTINCT txNomeParlamentar) FROM lancamentos, denuncias WHERE lancamentos.txtCNPJCPF = denuncias.txtCNPJCPF AND denuncias.Situacao = '" + Denuncia.SITUACAO_CASO_DOSSIE + "'", 300);

                    if (retorno != null)
                    {
                        total = Convert.ToInt32(retorno);
                    }
                }

                try
                {
                    cache.Add("TotalParlamentaresAtingidos", total, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                total = Convert.ToInt32(cache["TotalParlamentaresAtingidos"]);
            }

            return total;
        }

        internal void FornecedorParlamentares(GridView grid, String cnpj)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("    SELECT 'Senador' AS tipo,");
            sql.Append("           senadores.NomeParlamentar,");
            sql.Append("           senadores.SiglaUF,");
            sql.Append("           senadores.SiglaPartido,");
            sql.Append("           CAST(senadores.url AS CHAR) AS url,");
            sql.Append("           SUM(lancamentos_senadores.Valor) AS Valor");
            sql.Append("      FROM lancamentos_senadores, senadores");
            sql.Append("     WHERE lancamentos_senadores.CnpjCpf           = @txtCNPJCPF");
            sql.Append("       AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar");
            sql.Append("  GROUP BY 1, 2, 3, 4, 5");
            sql.Append(" UNION ALL");
            sql.Append("    SELECT 'Deputado Federal',");
            sql.Append("           lancamentos.txNomeParlamentar,");
            sql.Append("           lancamentos.sgUF,");
            sql.Append("           lancamentos.sgPartido,");
            sql.Append("           CAST(CONCAT('http://www.camara.leg.br/internet/Deputado/dep_Detalhe.asp?id=', lancamentos.ideCadastro) AS CHAR),");
            sql.Append("           SUM(lancamentos.vlrLiquido)");
            sql.Append("      FROM lancamentos");
            sql.Append("     WHERE lancamentos.txtCNPJCPF = @txtCNPJCPF");
            sql.Append("  GROUP BY 1, 2, 3, 4, 5");
            sql.Append("  ORDER BY 1, 6 DESC");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", cnpj);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Cargo";
                    table.Columns[1].ColumnName = "Parlamentar";
                    table.Columns[2].ColumnName = "UF";
                    table.Columns[3].ColumnName = "Partido";
                    table.Columns[5].ColumnName = "Valor";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }
    }
}