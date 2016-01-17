using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;
using System.IO;
using System.Drawing;

namespace AuditoriaParlamentar
{
    public partial class NovaNoticia : System.Web.UI.Page
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
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("NOTICIA"))
                Response.Redirect("~/Default.aspx");

            Int64 idNoticia = Convert.ToInt64(HttpUtility.HtmlDecode(Request.QueryString["IdNoticia"]));

            if (!IsPostBack)
            {
                if (idNoticia > 0)
                {
                    Noticia noticia = new Noticia();
                    noticia.CarregaNoticia(idNoticia);

                    if (noticia.IdNoticia == 0)
                        Response.Redirect("~/Default.aspx");

                    TextBoxNoticia.Text = noticia.TextoNoticia;
                    TextBoxLink.Text = noticia.LinkNoticia;
                }
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {

            Noticia noticia = new Noticia();
            noticia.TextoNoticia = TextBoxNoticia.Text;
            noticia.LinkNoticia = TextBoxLink.Text;
            noticia.UserName = System.Web.HttpContext.Current.User.Identity.Name;

            if (Request.QueryString["IdNoticia"] != null)
            {
                noticia.IdNoticia = Convert.ToInt64(HttpUtility.HtmlDecode(Request.QueryString["IdNoticia"]));
                noticia.AtualizaNoticia();

                if (FileUpload.HasFile)
                {
                    ResizeImage(noticia.IdNoticia);
                }
            }
            else
            {
                if (!FileUpload.HasFile)
                {
                    AnexoValidator.ErrorMessage = "Imagem da notícia não informada.";
                    AnexoValidator.IsValid = false;
                    return;
                }

                noticia.ImagemNoticia = FileUpload.FileName;
                noticia.InsereNoticia();

                ResizeImage(noticia.IdNoticia);
            }

            Cache.Remove("tableNoticias");

            Response.Redirect("~/Noticias.aspx");
        }

        protected void ResizeImage(Int64 idNoticia)
        {
            int width = 100;
            int height = 100;

            Stream stream = FileUpload.PostedFile.InputStream;

            Bitmap image = new Bitmap(stream);

            Bitmap target = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(target);
            graphic.DrawImage(image, 0, 0, width, height);
            target.Save(Server.MapPath("Noticias") + "\\" + idNoticia.ToString() + ".png");

        }
    }
}