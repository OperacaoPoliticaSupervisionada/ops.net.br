using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar
{
    public partial class Membros : System.Web.UI.Page
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
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                String uf = Convert.ToString(HttpUtility.HtmlDecode(Request.QueryString["UF"]));

                if (uf != null)
                {
                    GridViewMembros.EmptyDataText = "Não há nenhum membro cadastrado neste estado.";

                    Usuario usuario = new Usuario();
                    usuario.Membros(GridViewMembros, uf);
                }
            }
        }
    }
}