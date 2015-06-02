using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;
using System.Web.UI.HtmlControls;
using System.Data;

namespace AuditoriaParlamentar
{
    public partial class DossiesOld : System.Web.UI.Page
    {
        String mNomeDossie = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewDossie.EmptyDataText = "Nenhuma dossiê foi incluído";

                Dossie dossie = new Dossie();
                dossie.CarregaDossies(GridViewDossie);
            }

            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("REVISOR"))
            {
                ButtonNova.Visible = false;
            }
        }

        protected void ButtonNova_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NovoDossie.aspx");
        }

        protected void GridViewDossie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect(String.Format("~/NovoDossie.aspx?IdDossie={0}", GridViewDossie.Rows[index].Cells[3].Text));
            }
        }

        protected void GridViewDossie_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (mNomeDossie != e.Row.Cells[2].Text)
                    {
                        mNomeDossie = e.Row.Cells[2].Text;

                        Table parentTable = (Table)e.Row.Parent;
                        GridViewRow row = new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);
                        TableCell cell = new TableCell();
                        cell.ColumnSpan = GridViewDossie.Columns.Count;
                        cell.Width = Unit.Percentage(100);
                        cell.Style.Add("font-weight", "bold");
                        cell.Style.Add("background-color", "#5D7B9D");
                        cell.Style.Add("color", "white");

                        if (System.Web.HttpContext.Current.User.IsInRole("REVISOR"))
                            cell.Text = "<center><a href='NovoDossie.aspx?IdDossie=" + e.Row.Cells[4].Text + "'>" + mNomeDossie + " (ALTERAR)</a></center>";
                        else
                            cell.Text = "<center>" + mNomeDossie + "</center>";

                        row.Cells.Add(cell);
                        parentTable.Rows.AddAt(parentTable.Rows.Count - 1, row);
                    }
                }
            }
        }
    }
}