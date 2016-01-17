using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class AuditoriaPF : System.Web.UI.Page
    {
        public String AgrupamentoFornecedor { get { return Pesquisa.AGRUPAMENTO_FORNECEDOR; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == false)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                String cnpj = Request.QueryString["codigo"];

                if (cnpj == null || cnpj == "")
                    Response.Redirect("~/PesquisaInicio.aspx");
                
                Classes.Fornecedor fornecedor = new Classes.Fornecedor();

                fornecedor.CarregaDados(cnpj);

                fornecedor.MarcaVisitado(System.Web.HttpContext.Current.User.Identity.Name);

                LabelCNPJ.Text = fornecedor.Cnpj;
                LabelRazaoSocial.Text = fornecedor.RazaoSocial;

                ButtonDenunciar.OnClientClick = "Denunciar();return false;";

                ButtonListarDeputados.OnClientClick = "window.parent.addTabDocumentos('" + fornecedor.Cnpj + "','" + fornecedor.RazaoSocial + "', 0);return false;";
                ButtonListarDocumentos.OnClientClick = "window.parent.addTabDocumentos('" + fornecedor.Cnpj + "','" + fornecedor.RazaoSocial + "', 1);return false;";
                ButtonListarDoacoes.Visible = fornecedor.Doador;
                ButtonListarDoacoes.OnClientClick = "Doacoes();return false;";

                StringBuilder url = new StringBuilder();
                url.Append("http://www.google.com.br/search?q=");
                url.Append("\"" + fornecedor.RazaoSocial + "\"");

                ButtonPesquisa.OnClientClick = "window.open('" + url.ToString() + "');return false;";

                Denuncia denuncia = new Denuncia();
                denuncia.DenunciasFornecedorResumida(GridViewDenuncias, fornecedor.Cnpj);

                if (GridViewDenuncias.Rows.Count > 0)
                {
                    PanelExisteDenuncia.Visible = true;

                    if (GridViewDenuncias.Rows.Count == 1)
                        dvDenuncias.InnerText = "Este fornecedor possui 1 denúncia. Evite enviar denúncias repetidas caso existam outras recentes.";
                    else
                        dvDenuncias.InnerText = "Este fornecedor possui " + GridViewDenuncias.Rows.Count.ToString() + " denúncias. Evite enviar denúncias repetidas caso existam outras recentes.";
                }
                
            }

            GridViewDenuncias.PreRender += GridViewDenuncias_PreRender;
        }

        protected void GridViewDenuncias_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridViewDenuncias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
            }
        }

        protected void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuditoriaFornecedor.aspx?codigo=" + LabelCNPJ.Text + "&forcarConsulta=sim");
        }
    }
}