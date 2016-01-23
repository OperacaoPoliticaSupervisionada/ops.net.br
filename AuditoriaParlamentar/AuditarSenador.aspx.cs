using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar
{
    public partial class AuditarSenador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx?ReturnUrl=/AuditarSenador.aspx");

            if (!IsPostBack)
            {
                CarregaDados();
            }

            GridView.PreRender += GridView_PreRender;
        }

        protected void GridView_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
            }
        }

        private void CarregaDados()
        {
            CarregaGrid(GridView);

            Session["AuditarSenador"] = GridView.DataSource;

            Session["AuditarSenadorSortExpression"] = "DespesasMandato";
            Session["AuditarSenadorSortDirection"] = "DESC";
        }

        private void CarregaGrid(GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("    SELECT senador_usuario.UserName,");
            sql.Append("           senadores.NomeParlamentar,");
            sql.Append("           senadores.CodigoParlamentar,");
            sql.Append("           senadores.SiglaPartido,");
            sql.Append("           senadores.SiglaUf,");
            sql.Append("           senadores.url,");
            sql.Append("           senadores.DespesasMandato");
            sql.Append("      FROM senadores");
            sql.Append(" LEFT JOIN senador_usuario");
            sql.Append("        ON senador_usuario.CodigoParlamentar = senadores.CodigoParlamentar");
            sql.Append(" LEFT JOIN users");
            sql.Append("        ON users.UserName  = senador_usuario.UserName");
            sql.Append("     WHERE senadores.Ativo = 'S'");
            sql.Append("  ORDER BY 7 DESC");

            try
            {
                using (Banco banco = new Banco())
                {
                    using (DataTable table = banco.GetTable(sql.ToString(), 300))
                    {
                        grid.DataSource = table;
                        grid.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double valor;

                if (Double.TryParse(e.Row.Cells[7].Text, out valor))
                    e.Row.Cells[7].Text = Convert.ToDouble(valor).ToString("N2");
                else
                    e.Row.Cells[7].Text = "0,00";

                CheckBox chkRow = (e.Row.Cells[0].FindControl("CheckBoxSelecionar") as CheckBox);
                chkRow.Checked = false;

                if (HttpUtility.HtmlDecode(e.Row.Cells[1].Text).Trim() != "")
                {
                    e.Row.ForeColor = System.Drawing.Color.LightGray;

                    if (HttpUtility.HtmlDecode(e.Row.Cells[1].Text).Trim() == System.Web.HttpContext.Current.User.Identity.Name)
                    {
                        chkRow.Checked = true;
                        chkRow.Enabled = true;
                    }
                    else
                    {
                        chkRow.Enabled = false;
                    }
                }
                else
                {
                    chkRow.Enabled = true;
                }
            }
        }

        protected void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["AuditarSenador"] as DataTable;

            if (dt != null)
            {
                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridView.DataSource = Session["AuditarSenador"];
                GridView.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {

            // By default, set the sort direction to ascending.
            string sortDirection = "DESC";

            // Retrieve the last column that was sorted.
            string sortExpression = Session["AuditarSenadorSortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = Session["AuditarSenadorSortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            Session["AuditarSenadorSortExpression"] = column;
            Session["AuditarSenadorSortDirection"] = sortDirection;

            return sortDirection;
        }

        protected void ButtonGravar_Click(object sender, EventArgs e)
        {
            Gravar();
            CarregaDados();
        }

        private void Gravar()
        {
            try
            {
                using (Banco banco = new Banco())
                {
                    banco.BeginTransaction();

                    banco.AddParameter("UserName", System.Web.HttpContext.Current.User.Identity.Name);
                    banco.ExecuteNonQuery("DELETE FROM senador_usuario WHERE UserName = @UserName");

                    foreach (GridViewRow row in GridView.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("CheckBoxSelecionar") as CheckBox);

                            if (chkRow.Checked && chkRow.Enabled == true)
                            {
                                try
                                {
                                    banco.AddParameter("UserName", System.Web.HttpContext.Current.User.Identity.Name);
                                    banco.AddParameter("CodigoParlamentar", row.Cells[3].Text);
                                    banco.ExecuteNonQuery("INSERT INTO senador_usuario (UserName, CodigoParlamentar) VALUES (@UserName, @CodigoParlamentar)");
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                        }
                    }

                    banco.CommitTransaction();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Gravar();

                Int32 index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect(String.Format("~/PesquisaInicio.aspx?SENADOR={0}", GridView.Rows[index].Cells[3].Text));
            }
        }

    }
}