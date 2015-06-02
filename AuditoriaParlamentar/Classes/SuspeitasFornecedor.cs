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
    public class SuspeitasFornecedor
    {
        internal void CarregaSuspeitas()
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT txtCNPJCPF, cast(txtNumero as decimal) as txtNumero");
            sql.Append("     FROM lancamentos ");
            sql.Append("    WHERE txtCNPJCPF NOT IN (SELECT txtCNPJCPF FROM fornecedores_suspeitos)");
            sql.Append("      AND txtCNPJCPF NOT IN (SELECT txtCNPJCPF FROM denuncias)");
            //sql.Append("      AND txtCNPJCPF = '00547345000160'");
            sql.Append(" ORDER BY txtCNPJCPF, cast(txtNumero as decimal)");


            using (Banco banco = new Banco())
            {
                for (int qtd = 10; qtd >= 3; qtd--)
                {
                    DataTable tableLan = new DataTable("lancamentos");

                    using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                    {
                        tableLan.Load(reader);
                    }

                    String oldCnpjCpf = "";
                    Int64[] notas = new Int64[10];

                    foreach (DataRow rowLan in tableLan.Rows)
                    {
                        if (oldCnpjCpf != rowLan["txtCNPJCPF"].ToString())
                        {
                            for (int i = 0; i < 10; i++)
                                notas[i] = 0;
                        }

                        oldCnpjCpf = rowLan["txtCNPJCPF"].ToString();

                        try
                        {
                            for(int i = qtd - 1; i > 0; i--)
                                notas[i] = notas[i-1];

                            Int64.TryParse(rowLan["txtNumero"].ToString(), out notas[0]);

                            Int64 soma = 0;
                            for (int i = 0; i < 9; i++)
                                if (notas[i] > 0 && notas[i + 1] > 0)
                                    if (notas[i] - notas[i + 1] == 1)
                                        soma += 1;

                            if (soma == qtd -1)
                            {
                                banco.AddParameter("txtCNPJCPF", rowLan["txtCNPJCPF"].ToString());
                                banco.ExecuteNonQuery("INSERT INTO fornecedores_suspeitos (txtCNPJCPF, tipoSuspeita, descricao) VALUES (@txtCNPJCPF, 1, 'Notas Fiscais em Sequência: " + qtd.ToString("00") + "')");
                            }
                        }
                        catch (Exception ex)
                        {
                            for (int i = 0; i < 10; i++)
                                notas[i] = 0;
                        }
                    }
                }
            }
        }

        internal static String StringStatus()
        {
            StringBuilder status = new StringBuilder();

            status.Append(" CASE fornecedores_suspeitos.tipoSuspeita");
            status.Append("     WHEN 1 THEN 'Notas em sequência'");
            status.Append("     ELSE ''");
            status.Append(" END AS tipoSuspeita");

            return status.ToString();
        }

        internal void CarregaGrid(GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT fornecedores_suspeitos.UserName,");
            sql.Append("          fornecedores.txtCNPJCPF,");
            sql.Append("          SUBSTRING(fornecedores.txtBeneficiario, 1, 50) AS txtbeneficiario,");
            sql.Append("          fornecedores.Uf,");
            sql.Append("          fornecedores.Cidade,");
            sql.Append("          fornecedores_suspeitos.descricao");
            sql.Append("     FROM fornecedores_suspeitos, fornecedores");
            sql.Append("    WHERE fornecedores_suspeitos.txtCNPJCPF = fornecedores.txtCNPJCPF");
            sql.Append(" ORDER BY fornecedores_suspeitos.descricao DESC");

            using (Banco banco = new Banco())
            {
                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("fornecedores_suspeitos");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Usuário";
                    table.Columns[1].ColumnName = "CNPJ/CPF";
                    table.Columns[2].ColumnName = "Razão Social";
                    table.Columns[3].ColumnName = "UF";
                    table.Columns[4].ColumnName = "Cidade";
                    table.Columns[5].ColumnName = "Suspeita";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal Boolean DefineUsuario(String userName, String txtCNPJCPF)
        {
            Int64 retorno = 0;
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE fornecedores_suspeitos");
            sql.Append("   SET UserName          = @UserName");
            sql.Append(" WHERE txtCNPJCPF        = @txtCNPJCPF");
            sql.Append("   AND UserName          IS NULL");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("UserName", userName);
                banco.AddParameter("txtCNPJCPF", txtCNPJCPF);

                banco.ExecuteNonQuery(sql.ToString());
                retorno = banco.Rows;
            }

            return (retorno > 0);
        }

        internal Boolean RemoveUsuario(String userName, String txtCNPJCPF)
        {
            Int64 retorno = 0;
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE fornecedores_suspeitos");
            sql.Append("   SET UserName          = NULL");
            sql.Append(" WHERE txtCNPJCPF        = @txtCNPJCPF");
            sql.Append("   AND UserName          = @UserName");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("UserName", userName);
                banco.AddParameter("txtCNPJCPF", txtCNPJCPF);

                banco.ExecuteNonQuery(sql.ToString());
                retorno = banco.Rows;
            }

            return (retorno > 0);
        }
    }
}