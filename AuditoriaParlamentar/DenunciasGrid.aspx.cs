using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class DenunciasGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewDenuncias.PreRender += GridViewDenuncias_PreRender;

            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                Denuncia denuncia = new Denuncia();
                denuncia.DenunciasUsuario(GridViewDenuncias, HttpContext.Current.User.Identity.Name);
            }
        }

        private void GridViewDenuncias_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridViewDenuncias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
            }
        }

        protected void GridViewDenuncias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Width = 25;
                e.Row.Cells[2].Width = 70;
                e.Row.Cells[3].Width = 140;
                e.Row.Cells[4].Width = 300;
                e.Row.Cells[5].Width = 170;
            }

            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
            }
        }

        protected void GridViewDenuncias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect(String.Format("~/DenunciaMsg.aspx?Retorno=DenunciasGrid&IdDenuncia={0}", GridViewDenuncias.Rows[index].Cells[2].Text));
            }
        }
    }
}