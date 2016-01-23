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
    public partial class NovoDossie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("REVISOR"))
                Response.Redirect("~/Default.aspx");

            if (!IsPostBack)
            {
                Int64 idDossie = Convert.ToInt64(HttpUtility.HtmlDecode(Request.QueryString["IdDossie"]));

                Dossie dossie = new Dossie();
                dossie.Carrega(idDossie, GridViewResultado);

                Session["NovoDossie"] = GridViewResultado.DataSource;

                if (idDossie > 0)
                {
                    HiddenFieldIdDossie.Value = idDossie.ToString();

                    if (dossie.IdDossie == 0)
                        Response.Redirect("~/Default.aspx");

                    TextBoxNome.Text = dossie.NomeDossie;
                }
                else
                {
                    ButtonExcluir.Visible = false;
                }
            }
            GridViewResultado.PreRender += GridViewResultado_PreRender;
        }

        protected void GridViewResultado_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridViewResultado.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
            }
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dossies.aspx");
        }

        protected void GridViewResultado_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["NovoDossie"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridViewResultado.DataSource = Session["NovoDossie"];
                GridViewResultado.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "DESC";

            // Retrieve the last column that was sorted.
            string sortExpression = Session["NovoDossieSortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = Session["NovoDossieSortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            Session["NovoDossieSortExpression"] = column;
            Session["NovoDossieSortDirection"] = sortDirection;

            return sortDirection;
        }

        protected void GridViewResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text == "1")
                {
                    CheckBox chkRow = (e.Row.Cells[0].FindControl("CheckBoxSelecionar") as CheckBox);
                    chkRow.Checked = true;
                }
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            Dossie dossie = new Dossie();
            dossie.NomeDossie = TextBoxNome.Text;

            if (HiddenFieldIdDossie.Value != "")
            {
                dossie.IdDossie = Convert.ToInt32(HiddenFieldIdDossie.Value);

                if (dossie.Atualiza(GridViewResultado) == false)
                {
                    Response.Write("<script>alert('Ocorreu um problema na atualização dos dados.')</script>");
                    return;
                }
            }
            else
            {
                if (dossie.Insere(GridViewResultado) == false)
                {
                    Response.Write("<script>alert('Ocorreu um problema na atualização dos dados.')</script>");
                    return;
                }
            }

            Response.Redirect("~/Dossies.aspx");
        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            Dossie dossie = new Dossie();
            dossie.IdDossie = Convert.ToInt32(HiddenFieldIdDossie.Value);

            if (dossie.Excluir() == true)
                Response.Redirect("~/Dossies.aspx");
            else
                Response.Write("<script>alert('Ocorreu um problema na atualização dos dados.')</script>");
        }
    }
}