using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
   public partial class CidadesPendenciaGrid : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!IsPostBack)
         {
            GridViewCidades.EmptyDataText = "Nenhuma pendência foi incluída";

            Fornecedor fornecedor = new Fornecedor();
            fornecedor.CarregaCidadesPendencias(GridViewCidades);
         }

         if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("NOTICIA"))
         {
            ButtonGerenciar.Visible = false;
         }

         GridViewCidades.PreRender += GridViewCidades_PreRender;
      }

      protected void ButtonGerenciar_Click(object sender, EventArgs e)
      {
         Response.Redirect("~/CidadesPendenciaGerenciar.aspx");
      }

      protected void GridViewCidades_PreRender(object sender, EventArgs e)
      {
         try
         {
            GridViewCidades.HeaderRow.TableSection = TableRowSection.TableHeader;
         }
         catch (Exception ex)
         {
         }
      }
   }
}