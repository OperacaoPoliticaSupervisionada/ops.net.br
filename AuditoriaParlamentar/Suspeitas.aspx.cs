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
    public partial class Suspeitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                CarregaDados();
            }
        }

        private void CarregaDados()
        {
            SuspeitasFornecedor suspeitas = new SuspeitasFornecedor();
            suspeitas.CarregaGrid(GridView);

            Session["Suspeitas"] = GridView.DataSource;

            Session["SuspeitasSortExpression"] = "Suspeita";
            Session["SuspeitasSortDirection"] = "DESC";
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (HttpUtility.HtmlDecode(e.Row.Cells[2].Text).Trim() != "")
                {
                    e.Row.Cells[0].Enabled = false;

                    if (HttpUtility.HtmlDecode(e.Row.Cells[2].Text).Trim() == System.Web.HttpContext.Current.User.Identity.Name)
                    {
                        e.Row.Cells[1].Enabled = true;
                    }
                    else
                    {
                        e.Row.Cells[1].Enabled = false;
                    }
                }
                else
                {
                    e.Row.Cells[1].Enabled = false;
                }
            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                SuspeitasFornecedor suspeitas = new SuspeitasFornecedor();
                if (suspeitas.DefineUsuario(System.Web.HttpContext.Current.User.Identity.Name, GridView.Rows[index].Cells[3].Text) == true)
                {
                    CarregaDados();
                }
            }
            else if (e.CommandName == "Desfazer")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                SuspeitasFornecedor suspeitas = new SuspeitasFornecedor();
                if (suspeitas.RemoveUsuario(System.Web.HttpContext.Current.User.Identity.Name, GridView.Rows[index].Cells[3].Text) == true)
                {
                    CarregaDados();
                }
            }
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["Suspeitas"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView.DataSource = Session["Suspeitas"];
                GridView.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "DESC";

            // Retrieve the last column that was sorted.
            string sortExpression = Session["SuspeitasSortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = Session["SuspeitasSortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            Session["SuspeitasSortExpression"] = column;
            Session["SuspeitasSortDirection"] = sortDirection;

            return sortDirection;
        }
    }
}