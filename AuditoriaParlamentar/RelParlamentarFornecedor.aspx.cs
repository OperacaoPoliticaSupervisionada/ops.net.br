using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;
using System.Data;

namespace AuditoriaParlamentar
{
    public partial class RelParlamentarFornecedor : System.Web.UI.Page
    {
        Double mTotalGeral = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("REVISOR"))
                Response.Redirect("~/Default.aspx");

            if (!IsPostBack)
            {
                AcompanhaDenuncias acompanha = new AcompanhaDenuncias();
                acompanha.DenunciasParlamentarFornecedor(GridViewDenuncias);

                Session["Acompanha0"] = GridViewDenuncias.DataSource;
                Session["AcompanhaSortDirection0"] = "ASC";
                Session["AcompanhaSortExpression0"] = "Parlamentar";
            }
            GridViewDenuncias.PreRender += GGridViewDenuncias_PreRender;
        }

        private void GGridViewDenuncias_PreRender(object sender, EventArgs e)
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
            //e.Row.Cells[e.Row.Cells.Count - 1].HorizontalAlign = HorizontalAlign.Right;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double valor;

                if (Double.TryParse(e.Row.Cells[e.Row.Cells.Count - 1].Text, out valor))
                {
                    e.Row.Cells[e.Row.Cells.Count - 1].Text = Convert.ToDouble(valor).ToString("N2");

                    mTotalGeral += valor;
                }
                else
                {
                    e.Row.Cells[e.Row.Cells.Count - 1].Text = "0,00";
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[e.Row.Cells.Count - 1].Text = mTotalGeral.ToString("N2");
            }
        }

        protected void GridViewDenuncias_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["Acompanha0"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridViewDenuncias.DataSource = Session["Acompanha0"];
                GridViewDenuncias.DataBind();
            }
        }


        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "DESC";

            // Retrieve the last column that was sorted.
            string sortExpression = Session["AcompanhaSortExpression0"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = Session["AcompanhaSortDirection0"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            Session["AcompanhaSortDirection0"] = sortDirection;
            Session["AcompanhaSortExpression0"] = column;

            return sortDirection;
        }
    }
}