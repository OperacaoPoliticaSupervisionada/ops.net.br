using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class CidadesPendenciaGerenciar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("REVISOR"))
                Response.Redirect("~/Default.aspx");

            if (!IsPostBack)
            {
                GridViewFornecedores.EmptyDataText = "Nenhuma pendência foi incluída";

                Fornecedor fornecedor = new Fornecedor();
                fornecedor.CarregaCidadesPendenciasFornecedor(GridViewFornecedores);
            }

        }

        protected void GridViewFornecedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                Fornecedor fornecedor = new Fornecedor();

                if (fornecedor.ExcluiSolicitacaoFoto(GridViewFornecedores.Rows[index].Cells[3].Text))
                {
                    fornecedor.CarregaCidadesPendenciasFornecedor(GridViewFornecedores);
                }
            }
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CidadesPendenciaGrid.aspx");
        }
    }
}