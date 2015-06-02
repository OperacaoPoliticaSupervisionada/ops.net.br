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
            if (!IsPostBack)
            {
                GridViewNoticia.EmptyDataText = "Nenhuma notícia foi incluída";

                Noticia noticia = new Noticia();
                noticia.CarregaNoticias(GridViewNoticia);
            }

            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("NOTICIA"))
            {
                ButtonNova.Visible = false;
            }

        }

        protected void ButtonNova_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NovaNoticia.aspx");
        }

        protected void GridViewNoticia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                if (!System.Web.HttpContext.Current.User.IsInRole("NOTICIA"))
                {
                    e.Row.Cells[0].Visible = false;
                }

                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
        }

        protected void GridViewNoticia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect(String.Format("~/NovaNoticia.aspx?IdNoticia={0}", GridViewNoticia.Rows[index].Cells[3].Text));
            }
        }
    }
}