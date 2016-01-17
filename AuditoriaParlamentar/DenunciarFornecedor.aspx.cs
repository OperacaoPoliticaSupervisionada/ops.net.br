using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;
using System.IO;

namespace AuditoriaParlamentar
{
    public partial class DenunciarFornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                lblCNPJ.InnerText = HttpUtility.HtmlDecode(Request.QueryString["Cnpj"]);
                lblRazaoSocial.InnerText = HttpUtility.HtmlDecode(Request.QueryString["Nome"]);

                Denuncia denuncia = new Denuncia();
                if (denuncia.Existe(lblCNPJ.InnerText, HttpContext.Current.User.Identity.Name) == true)
                {
                    Response.Redirect(String.Format("~/DenunciaMsg.aspx?Retorno=close&IdDenuncia={0}", denuncia.IdDenuncia.ToString()));
                }
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                if (!FileUpload.FileName.EndsWith(".zip", StringComparison.CurrentCultureIgnoreCase))
                {
                    AnexoValidator.ErrorMessage = "O anexo deverá estar compactado no formato ZIP";
                    AnexoValidator.IsValid = false;
                    return;
                }

                if (FileUpload.PostedFile.ContentLength > 10485760)
                {
                    AnexoValidator.ErrorMessage = "O anexo deverá ter no máximo 10 MB.";
                    AnexoValidator.IsValid = false;
                    return;
                }
            }

            String userName = HttpContext.Current.User.Identity.Name;

            if (userName == null)
                Response.Redirect("~/Oops.aspx");

            Denuncia denuncia = new Denuncia();
            denuncia.Cnpj = lblCNPJ.InnerText;
            denuncia.RazaoSocial = lblRazaoSocial.InnerText;
            denuncia.UsuarioDenuncia = HttpContext.Current.User.Identity.Name;
            denuncia.Texto = TextBoxDenuncia.Text;

            if (denuncia.InsereDenuncia())
            {
                if (FileUpload.HasFile)
                {
                    String dir = Server.MapPath("Denuncias") + "\\" + denuncia.IdDenuncia.ToString("0000");

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    DirectoryInfo dirInfo = new DirectoryInfo(dir);

                    Anexos anexo = new Anexos();
                    anexo.IdDenuncia = denuncia.IdDenuncia;
                    anexo.UserName = HttpContext.Current.User.Identity.Name;
                    anexo.Arquivo = (dirInfo.GetFiles().Length + 1).ToString("00") + "_" + FileUpload.FileName;
                    anexo.InsereAnexo();

                    FileUpload.SaveAs(dir + "\\" + anexo.Arquivo);
                }

                //Response.Write("<script>alert('Denúncia enviada com sucesso.');window.parent.closeTab();</script>");

                Response.Redirect(String.Format("~/DenunciaMsg.aspx?Retorno=close&IdDenuncia={0}", denuncia.IdDenuncia.ToString()));
            }
        }
    }
}