using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace AuditoriaParlamentar.Classes
{
    public class Email
    {
        private String mRemetente = "informa@ops.net.br";
        private String mPassword = "informa";

        internal Boolean Enviar(ArrayList destinatarios, String assunto, String texto, Boolean geraPendencia = true)
        {
            Boolean retorno = false;

            ////http://higlabo.codeplex.com/

            //using (SmtpClient cl = new SmtpClient())
            //{
            //    cl.ServerName = "mail.ops.net.br";
            //    cl.HostName = "mail.ops.net.br";
            //    cl.Port = 465;
            //    cl.UserName = mRemetente;
            //    cl.Password = mPassword;
            //    cl.EncryptedCommunication = SmtpEncryptedCommunication.Ssl;
            //    cl.RequestEncoding = Encoding.GetEncoding("ISO-8859-1");
            //    cl.AuthenticateMode = SmtpAuthenticateMode.Auto;

            //    SmtpMessage mg = new SmtpMessage();
            //    mg.ContentTransferEncoding = TransferEncoding.Base64;
            //    mg.HeaderTransferEncoding = TransferEncoding.Base64;
            //    mg.Subject = assunto;
            //    mg.BodyText = texto;
            //    mg.IsHtml = true;
            //    mg.From = new MailAddress(mRemetente);

            //    foreach (String destinatatio in destinatarios)
            //    {
            //        mg.Bcc.Add(new MailAddress(destinatatio));
            //    }

            //    var rs = cl.SendMail(mg);

            //    if (rs.SendSuccessful == false)
            //    {
            //        if (geraPendencia)
            //        {
            //            GravaPendencia(destinatarios, assunto, texto);
            //        }
            //    }
            //    else
            //    {
            //        retorno = true;
            //    }

            //    cl.Close();
            //}

            try
            {
                MailMessage objEmail = new MailMessage();

                objEmail.From = new MailAddress(mRemetente);
                objEmail.ReplyToList.Add(new MailAddress(mRemetente));
                objEmail.IsBodyHtml = true;
                objEmail.Subject = assunto;
                objEmail.Body = texto;
                objEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                foreach (String destinatatio in destinatarios)
                {
                    objEmail.To.Add(destinatatio);
                }

                SmtpClient objSmtp = new SmtpClient();

                objSmtp.Host = "mail.ops.net.br";
                objSmtp.Credentials = new NetworkCredential(mRemetente, mPassword);
                objSmtp.EnableSsl = false;
                objSmtp.Send(objEmail);

                retorno = true;
            }
            catch (Exception ex)
            {
                if (geraPendencia)
                {
                    GravaPendencia(destinatarios, assunto, texto);
                }
            }

            return retorno;
        }

        private Boolean GravaPendencia(ArrayList destinatarios, String assunto, String texto)
        {
            using (Banco banco = new Banco())
            {
                String dest = "";

                foreach (String destinatatio in destinatarios)
                {
                    dest += destinatatio + ";";
                }

                banco.AddParameter("destinatario", dest);
                banco.AddParameter("assunto", assunto);
                banco.AddParameter("texto", texto);

                if (banco.ExecuteNonQuery("INSERT INTO email_pendencia (destinatario, assunto, texto) VALUES (@destinatario, @assunto, @texto)") == false)
                {
                    return false;
                }
            }

            return true;
        }

        internal void ReEnviaEmail()
        {
            using (Banco banco = new Banco())
            {
                using (DataTable table = banco.GetTable("SELECT * FROM email_pendencia", 300))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        ArrayList destinatarios = new ArrayList();
                        destinatarios.Add(row["destinatario"].ToString());

                        String assunto = row["assunto"].ToString();
                        String texto = row["texto"].ToString();

                        if (Enviar(destinatarios, assunto, texto, false) == true)
                        {
                            banco.ExecuteNonQuery("DELETE FROM email_pendencia WHERE id = " + row["id"].ToString());
                        }
                    }
                }
            }
        }
    }
}