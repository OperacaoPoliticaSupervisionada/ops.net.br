using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar.Classes
{
    internal class Eleicao
    {
        internal void Pesquisa(GridView grid, String cnpj)
        {
            using (Banco banco = new Banco())
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("   SELECT anoEleicao,");
                sql.Append("          cpfCandidato,");
                sql.Append("          nomeCandidato,");
                sql.Append("          cargo,");
                sql.Append("          numDocumento,");
                sql.Append("          dataReceita,");
                sql.Append("          valorReceita");
                sql.Append("     FROM receitas_eleicao");
                sql.Append("    WHERE raizCnpjCpfDoador = @raizCnpjCpfDoador");
                sql.Append(" ORDER BY cpfCandidato, dataReceita");

                banco.AddParameter("raizCnpjCpfDoador", cnpj);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("eleicao");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Ano";
                    table.Columns[1].ColumnName = "CPF do Candidato";
                    table.Columns[2].ColumnName = "Nome do Candidato";
                    table.Columns[3].ColumnName = "Cargo";
                    table.Columns[4].ColumnName = "Documento";
                    table.Columns[5].ColumnName = "Data da Receita";
                    table.Columns[6].ColumnName = "Valor da Receita";

                    grid.DataSource = table;
                    grid.DataBind();

                }
            }
        }
    }
}