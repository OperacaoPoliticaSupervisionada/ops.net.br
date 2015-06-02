using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Text;
using System.Threading;
using System.Web.Security;

namespace AuditoriaParlamentar.Classes
{
    public class Notificacoes
    {
        internal Boolean InsereNotificacoes(Int64 idDenuncia, String userNameDenuncia, String userName, String texto, String cnpj, String razaoSocial)
        {
            using (Banco banco = new Banco())
            {
                //Usuário da denúncia
                if (userNameDenuncia != userName)
                {
                    banco.AddParameter("idDenuncia", idDenuncia);
                    banco.AddParameter("UserName", userName);
                    banco.ExecuteNonQuery("INSERT INTO notificacoes SELECT idDenuncia, UserNameDenuncia FROM denuncias WHERE idDenuncia = @idDenuncia AND NOT EXISTS (SELECT 1 FROM notificacoes WHERE notificacoes.idDenuncia = denuncias.idDenuncia AND notificacoes.UserName = denuncias.UserNameDenuncia) AND UserNameDenuncia <> @UserName");
                }

                //Demais usuários que participam do chat
                banco.AddParameter("idDenuncia", idDenuncia);
                banco.AddParameter("UserName", userName);
                banco.ExecuteNonQuery("INSERT INTO notificacoes SELECT DISTINCT idDenuncia, UserName FROM denuncias_msg WHERE idDenuncia = @idDenuncia AND NOT EXISTS (SELECT 1 FROM notificacoes WHERE notificacoes.idDenuncia = denuncias_msg.idDenuncia AND notificacoes.UserName = denuncias_msg.UserName) AND UserName <> @UserName");

                EnviaEmail(banco, idDenuncia, userName, texto, cnpj, razaoSocial);
            }
            
            return true;
        }

        private void EnviaEmail(Banco banco, Int64 idDenuncia, String userName, String texto, String cnpj, String razaoSocial)
        {
            ArrayList destinatarios = new ArrayList();

            banco.AddParameter("idDenuncia", idDenuncia);

            using (MySqlDataReader reader = banco.ExecuteReader("SELECT Email FROM notificacoes, users WHERE notificacoes.idDenuncia = @idDenuncia AND notificacoes.UserName = users.UserName", 300))
            {
                while (reader.Read())
                {
                    destinatarios.Add(reader["Email"].ToString());
                }
            }

            if (destinatarios.Count > 0)
            {
                StringBuilder corpo = new StringBuilder();

                corpo.Append(@"<html><head><title>O.P.S.</title></head><body><table width=""100%""><tr><td><center><h3>O.P.S. - Operação Política Supervisionada</h3></center></td></tr><tr><td><i>Um novo comentário foi adicionado a sua denúncia.</i></td></tr><tr><td><table><tr><td valign=""top""><b>Denúncia:</b></td><td>");
                corpo.Append(@"<a href=""http://www.ops.net.br/Denuncias.aspx"">" + idDenuncia.ToString("0000") + "</a></td></tr>");
                corpo.Append(@"<tr><td valign=""top""><b>Fornecedor:</b></td><td>");
                corpo.Append(cnpj + " - " + razaoSocial);
                corpo.Append(@"</td></tr>");
                corpo.Append(@"<tr><td valign=""top""><b>Usuário:</b></td><td>");
                corpo.Append(userName);
                corpo.Append(@"</td></tr><tr><td valign=""top""><b>Texto:</b></td><td>");
                corpo.Append(texto);
                corpo.Append(@"</td></tr></table></td></tr></table></body></html>");

                Email envio = new Email();
                envio.Enviar(destinatarios, "[O.P.S.] Novo Comentário", corpo.ToString());
            }
        }

        internal Boolean ApagaNotificacoes(Banco banco, Int64 idDenuncia, String userNamen)
        {
            //Usuário da denúncia
            banco.AddParameter("idDenuncia", idDenuncia);
            banco.AddParameter("UserName", userNamen);

            if (banco.ExecuteNonQuery("DELETE FROM notificacoes WHERE idDenuncia = @idDenuncia AND UserName = @UserName") == false)
            {
                return false;
            }

            return true;
        }
    }
}