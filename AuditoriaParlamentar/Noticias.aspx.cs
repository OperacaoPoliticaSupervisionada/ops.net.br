using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
   public partial class Noticias : System.Web.UI.Page
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
         {
            plhInserir.Visible = false;
         }

         if (!IsPostBack)
         {
            Noticia noticia = new Noticia();
            noticia.CarregaNoticias(rptNoticia);

            if (rptNoticia.Items.Count == 0)
            {
               rptNoticia.Visible = false;
               plhInfo.Visible = true;
               lblInfo.Text = "Nenhuma notícia foi incluída";
            }
            else
            {
               rptNoticia.Visible = true;
               plhInfo.Visible = false;
            }
         }
      }
   }
}