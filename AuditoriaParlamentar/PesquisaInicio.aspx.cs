using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AuditoriaParlamentar
{
    public partial class PesquisaInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String opcao = HttpUtility.HtmlDecode(Request.QueryString["UF"]);
            if (opcao != null)
            {
                Session["IniciaPesquisa"] = "SIM";
                Session["TipoPesquisa"] = "UF";
                Session["UFPesquisa"] = opcao;
                return;
            }

            opcao = HttpUtility.HtmlDecode(Request.QueryString["GA"]);
            if (opcao != null)
            {
                Session["IniciaPesquisa"] = "SIM";
                Session["TipoPesquisa"] = "GA";
                Session["AgrupamentoPesquisa"] = opcao;
                return;
            }

            opcao = HttpUtility.HtmlDecode(Request.QueryString["SENADOR"]);
            if (opcao != null)
            {
                Session["IniciaPesquisa"] = "SIM";
                Session["TipoPesquisa"] = "SENADOR";
                Session["SenadorPesquisa"] = opcao;
                return;
            }

            opcao = HttpUtility.HtmlDecode(Request.QueryString["IdShare"]);
            if (opcao != null)
            {
                Session["IniciaPesquisa"] = "SIM";
                Session["TipoPesquisa"] = "IdShare";
                Session["IdSharePesquisa"] = opcao;
                return;
            }

            opcao = HttpUtility.HtmlDecode(Request.QueryString["CARGO"]);
            if (opcao != null)
            {
                Session["IniciaPesquisa"] = "SIM";
                Session["TipoPesquisa"] = "CARGO";
                Session["CargoPesquisa"] = opcao;
                return;
            }
        }
    }
}