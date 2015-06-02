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
    public class Comentarios
    {
        internal Int64 IdMensagem { get; set; }
        internal Int64 IdDenuncia { get; set; }
        internal String UserName { get; set; }
        internal String UserNameDenuncia { get; set; }
        internal DateTime Data { get; set; }
        internal String Texto { get; set; }
        internal String Cnpj { get; set; }
        internal String RazaoSocial { get; set; }

        internal void Carrega(GridView grid, Int64 idDenuncia)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT denuncias_msg.Data,");
            sql.Append("          denuncias_msg.UserName,");
            sql.Append("          denuncias_msg.Texto");
            sql.Append("     FROM denuncias_msg");
            sql.Append("    WHERE denuncias_msg.idDenuncia = @idDenuncia");
            sql.Append(" ORDER BY idMensagem");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("idDenuncia", idDenuncia);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias_msg");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Data";
                    table.Columns[1].ColumnName = "Usuário";
                    table.Columns[2].ColumnName = "Comentário";

                    grid.DataSource = table;
                    grid.DataBind();
                }

                Notificacoes notificacao = new Notificacoes();
                notificacao.ApagaNotificacoes(banco, idDenuncia, System.Web.HttpContext.Current.User.Identity.Name);
            }
        }

        internal Boolean InsereComentario()
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("idDenuncia", IdDenuncia);
                banco.AddParameter("UserName", UserName);
                banco.AddParameter("Texto", Texto);

                if (banco.ExecuteNonQuery("INSERT INTO denuncias_msg (idDenuncia, UserName, Data, Texto) VALUES (@idDenuncia, @UserName, NOW(), @Texto)") == false)
                {
                    return false;
                }

                IdMensagem = banco.LastInsertedId;

                ThreadStart work = delegate
                {
                    Notificacoes notificacao = new Notificacoes();
                    notificacao.InsereNotificacoes(IdDenuncia, UserNameDenuncia, UserName, Texto, Cnpj, RazaoSocial);
                };
                new Thread(work).Start();
            }

            return true;
        }
    }
}