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
    public partial class ReceitasEleicao : System.Web.UI.Page
    {
        Double mTotalGeral = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCNPJ.InnerText = HttpUtility.HtmlDecode(Request.QueryString["Cnpj"]);
                lblrazaoSocial.InnerText = HttpUtility.HtmlDecode(Request.QueryString["Nome"]);

                String cnpjCpf = lblCNPJ.InnerText;

                if (cnpjCpf.Length == 14)
                    cnpjCpf = cnpjCpf.Substring(0, 8);

                Eleicao receitas = new Eleicao();
                receitas.Pesquisa(GridViewResultado, cnpjCpf);
            }
        }

        protected void GridViewResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[e.Row.Cells.Count - 1].HorizontalAlign = HorizontalAlign.Right;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double valor;

                if (Double.TryParse(e.Row.Cells[e.Row.Cells.Count - 1].Text, out valor))
                    e.Row.Cells[e.Row.Cells.Count - 1].Text = Convert.ToDouble(valor).ToString("N2");
                else
                    e.Row.Cells[e.Row.Cells.Count - 1].Text = "0,00";

                mTotalGeral += Convert.ToDouble(e.Row.Cells[e.Row.Cells.Count - 1].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Total Geral";
                e.Row.Cells[e.Row.Cells.Count - 1].Text = mTotalGeral.ToString("N2");
            }
        }
    }
}