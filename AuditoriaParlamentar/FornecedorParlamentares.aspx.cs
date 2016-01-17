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
    public partial class FornecedorParlamentares : System.Web.UI.Page
    {
        Double mTotalGeral = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                String cnpj = HttpUtility.HtmlDecode(Request.QueryString["Cnpj"]);
                String nome = HttpUtility.HtmlDecode(Request.QueryString["Nome"]);

                lblCNPJ.InnerText = cnpj;
                lblrazaoSocial.InnerText = nome;

                AcompanhaDenuncias dados = new AcompanhaDenuncias();
                dados.FornecedorParlamentares(GridViewResultado, cnpj);

                Session["FornecedorParlamentares"] = GridViewResultado.DataSource;
                Session["FornecedorParlamentaresExpression"] = "Parlamentar";
                Session["FornecedorParlamentaresDirection"] = "ASC";

            }
            GridViewResultado.PreRender += GridViewResultado_PreRender;
        }

        private void GridViewResultado_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridViewResultado.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
            }
        }
        protected void GridViewResultado_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["FornecedorParlamentares"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridViewResultado.DataSource = Session["FornecedorParlamentares"];
                GridViewResultado.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "DESC";

            // Retrieve the last column that was sorted.
            string sortExpression = Session["FornecedorParlamentaresExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = Session["FornecedorParlamentaresDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            Session["FornecedorParlamentaresExpression"] = column;
            Session["FornecedorParlamentaresDirection"] = sortDirection;

            return sortDirection;
        }

        protected void GridViewResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[5].Visible = false;
            //e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[4].Text = string.Format("<a href=\"{0}\" target=\"_blank\" rel=\"nofollow\">Site</a>", e.Row.Cells[4].Text);
                Double valor;

                if (Double.TryParse(e.Row.Cells[5].Text, out valor))
                    e.Row.Cells[5].Text = Convert.ToDouble(valor).ToString("N2");
                else
                    e.Row.Cells[5].Text = "0,00";

                mTotalGeral += Convert.ToDouble(e.Row.Cells[5].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = mTotalGeral.ToString("N2");
            }
        }
    }
}