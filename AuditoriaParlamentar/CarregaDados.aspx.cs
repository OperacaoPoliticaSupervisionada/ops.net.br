using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Web.Configuration;
using System.Configuration;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class CarregaDados : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (Session["MasterPage"] == "Farejador")
            {
                Page.MasterPageFile = "~/OpsFarejador.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //CifrarStringConexao();
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            Cache.Remove("menorAno");
            Cache.Remove("ultima_atualizacao");
            Cache.Remove("tableParlamentar");
            Cache.Remove("tableDespesa");
            Cache.Remove("tablePartido");

            String atualDir = Server.MapPath("Upload");

            if (FileUpload.FileName != "")
            {
                //string ftpUrl = ConfigurationManager.AppSettings["ftpAddress"];
                //string ftpUsername = ConfigurationManager.AppSettings["ftpUsername"];
                //string ftpPassword = ConfigurationManager.AppSettings["ftpPassword"];
                //FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl + "Transactions.zip");
                //request.Proxy = new WebProxy(); //-----The requested FTP command is not supported when using HTTP proxy.
                //request.Method = WebRequestMethods.Ftp.UploadFile;
                //request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                //StreamReader sourceStream = new StreamReader(fileToBeUploaded);
                //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                //sourceStream.Close();
                //request.ContentLength = fileContents.Length;
                //Stream requestStream = request.GetRequestStream();
                //requestStream.Write(fileContents, 0, fileContents.Length);
                //requestStream.Close();
                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                //response.Close();

                //using (var requestStream = request.GetRequestStream())
                //{
                //    using (var input = File.OpenRead(fileToBeUploaded))
                //    {
                //        input.CopyTo(requestStream);
                //    }
                //}


                FileUpload.SaveAs(atualDir + "//" + FileUpload.FileName);

                ICSharpCode.SharpZipLib.Zip.ZipFile file = null;

                try
                {
                    file = new ICSharpCode.SharpZipLib.Zip.ZipFile(atualDir + "//" + FileUpload.FileName);

                    if (file.TestArchive(true) == false)
                    {
                        Response.Write("<script>alert('Erro no Zip. Faça o upload novamente.')</script>");
                        return;
                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }

                ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                zip.ExtractZip(atualDir + "//" + FileUpload.FileName, Server.MapPath("Upload"), null);

                File.Delete(atualDir + "//" + FileUpload.FileName);

                Carregar(atualDir);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(atualDir);

                foreach (FileInfo file in dir.GetFiles("*.zip"))
                {
                    ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                    zip.ExtractZip(file.FullName, file.DirectoryName, null);

                    File.Delete(file.FullName);

                    Carregar(file.DirectoryName);
                }
            }
        }

        protected void Carregar(String atualDir)
        {
            Dados dados = new Dados();
            Boolean temFile = false;

            DirectoryInfo dir = new DirectoryInfo(atualDir);

            dados.DirFiguras = Server.MapPath("Figuras");

            foreach (FileInfo file in dir.GetFiles("*.xml"))
            {
                temFile = true;

                if (dados.CarregaDados(file.FullName, CheckBoxDiferenca.Checked, GridViewPrevia))
                {
                    File.Delete(file.FullName);
                }
                else
                {
                    Response.Write("<script>alert('Erro na carga de dados: " + dados.MsgErro.Replace("'", "") + "')</script>");
                    return;
                }
            }            
        }

        protected void ButtonEfetivaDep_Click(object sender, EventArgs e)
        {
            Dados dados = new Dados();

            if (dados.EfetivaDados())
            {
                Response.Write("<script>alert('Processamento concluído.')</script>");
            }
            else
            {
                Response.Write("<script>alert('Erro na carga de dados: " + dados.MsgErro.Replace("'", "") + "')</script>");
            }
        }

        private void CifrarStringConexao()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
            ConfigurationSection section = config.GetSection("connectionStrings") ;

            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                config.Save();
            }
        }

        protected void ButtonCarregarRec_Click(object sender, EventArgs e)
        {
            if (TextBoxAno.Text == "")
                return;

            String atualDir = Server.MapPath("Upload");

            Dados dados = new Dados();

            if (dados.CarregaDadosReceitaEleicao(atualDir, TextBoxAno.Text) == false)
            {
                Response.Write("<script>alert('Erro na carga de dados: " + dados.MsgErro.Replace("'", "") + "')</script>");
            }
            else
            {
                Response.Write("<script>alert('Processamento concluído.')</script>");
            }
        }

        protected void ButtonSuspeitas_Click(object sender, EventArgs e)
        {
            SuspeitasFornecedor suspeitas = new SuspeitasFornecedor();
            suspeitas.CarregaSuspeitas();

        }

        protected void ButtonSenadores_Click(object sender, EventArgs e)
        {
            Cache.Remove("menorAnoSenadores");
            Cache.Remove("ultimaAtualizacaoSenadores");
            Cache.Remove("tableSenadores");
            Cache.Remove("tableDespesaSenadores");
            Cache.Remove("tablePartidoSenadores");

            String atualDir = Server.MapPath("Upload");

            if (FileUpload.FileName != "")
            {
                FileUpload.SaveAs(atualDir + "//" + FileUpload.FileName);

                ICSharpCode.SharpZipLib.Zip.ZipFile file = null;

                try
                {
                    file = new ICSharpCode.SharpZipLib.Zip.ZipFile(atualDir + "//" + FileUpload.FileName);

                    if (file.TestArchive(true) == false)
                    {
                        Response.Write("<script>alert('Erro no Zip. Faça o upload novamente.')</script>");
                        return;
                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }

                ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                zip.ExtractZip(atualDir + "//" + FileUpload.FileName, Server.MapPath("Upload"), null);

                File.Delete(atualDir + "//" + FileUpload.FileName);

                CarregarSenadores(atualDir);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(atualDir);

                foreach (FileInfo file in dir.GetFiles("*.zip"))
                {
                    ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                    zip.ExtractZip(file.FullName, file.DirectoryName, null);

                    File.Delete(file.FullName);

                    CarregarSenadores(file.DirectoryName);
                }
            }
        }

        private void CarregarSenadores(String atualDir)
        {
            DadosSenadores dados = new DadosSenadores();
            Boolean temFile = false;

            DirectoryInfo dir = new DirectoryInfo(atualDir);

            foreach (FileInfo file in dir.GetFiles("*.csv"))
            {
                temFile = true;

                if (dados.CarregaDados(file.FullName, CheckBoxDiferenca.Checked, GridViewPrevia))
                {
                    File.Delete(file.FullName);
                }
                else
                {
                    Response.Write("<script>alert('Erro na carga de dados: " + dados.MsgErro.Replace("'", "") + "')</script>");
                    return;
                }
            }
        }

        protected void ButtonEfetivaSen_Click(object sender, EventArgs e)
        {
            DadosSenadores dados = new DadosSenadores();

            if (dados.EfetivaDados())
            {
                Response.Write("<script>alert('Processamento concluído.')</script>");
            }
            else
            {
                Response.Write("<script>alert('Erro na carga de dados: " + dados.MsgErro.Replace("'", "") + "')</script>");
            }
        }

        protected void ButtonFotos_Click(object sender, EventArgs e)
        {
            Dados deputadoFed = new Dados();
            deputadoFed.DirFiguras = Server.MapPath("Figuras");
            deputadoFed.DownaloadFotos();

            DadosSenadores senador = new DadosSenadores();
            senador.DirFiguras = Server.MapPath("Figuras");
            senador.DownaloadFotos();
        }
    }
}