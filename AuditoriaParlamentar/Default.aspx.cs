using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HyperLinkParlamentar.NavigateUrl = "PesquisaInicio.aspx?GA=" + Pesquisa.AGRUPAMENTO_PARLAMENTAR;
                HyperLinkDespesa.NavigateUrl = "PesquisaInicio.aspx?GA=" + Pesquisa.AGRUPAMENTO_DESPESA;
                HyperLinkEstado.NavigateUrl = "PesquisaInicio.aspx?GA=" + Pesquisa.AGRUPAMENTO_UF;
                HyperLinkPartido.NavigateUrl = "PesquisaInicio.aspx?GA=" + Pesquisa.AGRUPAMENTO_PARTIDO;
                HyperLinkFornecedor.NavigateUrl = "PesquisaInicio.aspx?GA=" + Pesquisa.AGRUPAMENTO_FORNECEDOR;

                AcompanhaDenuncias denuncia = new AcompanhaDenuncias();
                LabelDenunciasEnviadas.Text = denuncia.TotalDenuncias(Cache).ToString("N0");
                LabelFornecedoresDenunciados.Text = denuncia.TotalFornecedoresDenunciados(Cache).ToString("N0");
                LabelParlamentaresAtingidos.Text = denuncia.TotalParlamentaresAtingidos(Cache).ToString("N0");

                Noticia noticia = new Noticia();
                noticia.UltimasNoticias(Cache, GridViewNoticia);
            }
        }

        protected void GridViewNoticia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
            }
        }
    }
}