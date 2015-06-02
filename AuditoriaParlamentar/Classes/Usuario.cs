using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    internal class Usuario
    {
        internal Boolean InsereDadosComplementares(String userName, String uf, String cidade, Boolean mostraEmail)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("Username", userName);
                banco.AddParameter("uf", uf);
                banco.AddParameter("cidade", cidade.ToUpper());
                banco.AddParameter("mostra_email", Convert.ToInt32(mostraEmail));

                if (banco.ExecuteNonQuery("INSERT INTO users_detail (Username, uf, cidade, mostra_email) VALUES (@Username, @uf, @cidade, @mostra_email)") == false)
                {
                    return false;
                }
            }

            return true;
        }

        internal Boolean AtualizaDadosComplementares(String userName, String uf, String cidade, Boolean mostraEmail)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("userName", userName);
                banco.AddParameter("uf", uf);
                banco.AddParameter("cidade", cidade.ToUpper());
                banco.AddParameter("mostra_email", Convert.ToInt32(mostraEmail));

                if (banco.ExecuteNonQuery("UPDATE users_detail SET uf = @uf, cidade = @cidade, mostra_email = @mostra_email WHERE userName = @userName") == false)
                {
                    return false;
                }
            }

            return true;
        }

        public String UserUF { get; set; }
        public String UserCidade { get; set; }
        public Boolean MostraEmail { get; set; }

        internal Boolean CarregaDadosComplementares(String userName)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("userName", userName);

                using (MySql.Data.MySqlClient.MySqlDataReader reader = banco.ExecuteReader("SELECT * FROM users_detail WHERE userName = @userName"))
                {
                    if (reader.Read())
                    {
                        try { UserUF = reader["uf"].ToString(); }
                        catch { UserUF = ""; }

                        try { UserCidade = reader["cidade"].ToString(); }
                        catch { UserCidade = ""; }

                        try { MostraEmail = Convert.ToBoolean(reader["mostra_email"]); }
                        catch { MostraEmail = false; }
                    }

                    reader.Close();
                }
            }

            return true;
        }

        internal void Membros(GridView grid, String uf)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT users.UserName,");
            sql.Append("          users_detail.Cidade,");
            sql.Append("          users.Email");
            sql.Append("     FROM users, users_detail");
            sql.Append("    WHERE users.Username            = users_detail.Username");
            sql.Append("      AND users_detail.uf           = @uf");
            sql.Append("      AND users_detail.mostra_email = 1");
            sql.Append(" ORDER BY 2");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("uf", uf);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("users");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Membros de " + uf;
                    table.Columns[1].ColumnName = "Cidade";
                    table.Columns[2].ColumnName = "E-mail";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal Boolean RecuperarSenha(String userName)
        {
            MySqlMembershipProvider provider = new MySqlMembershipProvider();
            String pass = provider.ResetPassword(userName, "");
            System.Web.Security.MembershipUser user = provider.GetUser(userName, false);

            System.Collections.ArrayList destinatario = new System.Collections.ArrayList();
            destinatario.Add(user.Email);

            Email email = new Email();
            email.Enviar(destinatario, "[O.P.S.] Recuperação de senha", "Senha: " + pass);

            return true;
        }
    }
}