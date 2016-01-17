using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class SolicitaDocumentos : System.Web.UI.Page
    {
        Double mTotalGeralDep = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx");

            if (!IsPostBack)
            {
                String cnpj = HttpUtility.HtmlDecode(Request.QueryString["Cnpj"]);
                String nome = HttpUtility.HtmlDecode(Request.QueryString["Nome"]);

                AcompanhaDenuncias denuncias = new AcompanhaDenuncias();
                denuncias.DenunciasParlamentarFornecedor(DropDownListParlamentar, cnpj);

                Object parlamentarSendoPesquisado = Session["ParlamentarQueEstaSendoAuditado"];

                if (parlamentarSendoPesquisado != null)
                {
                    if (DropDownListParlamentar.Items.FindByValue(parlamentarSendoPesquisado.ToString()) != null)
                        DropDownListParlamentar.SelectedValue = parlamentarSendoPesquisado.ToString();
                }
                
                lblCNPJ.InnerText = cnpj;
                lblrazaoSocial.InnerText = nome;

                CarregaNotas();
            }
        }

        private void CarregaNotas()
        {
            LabelSel.Visible = true;
            TextBoxTexto.Visible = false;
            HyperLinkDoc.Visible = false;
            HyperLinkCamara.Visible = false;

            if (DropDownListParlamentar.SelectedItem.Text.IndexOf("(DEPUTADO FEDERAL)") > 0)
            {
                HyperLinkCamara.Visible = true;
                HyperLinkCamara.NavigateUrl = "http://www.camara.gov.br/cota-parlamentar/consulta-cota-parlamentar?ideDeputado=" + DropDownListParlamentar.SelectedValue;

                Pesquisa pesquisa = new Pesquisa();
                pesquisa.DocumentosFornecedor(GridViewResultado, lblCNPJ.InnerText, DropDownListParlamentar.SelectedValue);

                if (GridViewResultado.Rows.Count > 0)
                {
                    Session["SolicitaDocumentos"] = GridViewResultado.DataSource;
                    Session["SolicitaDocumentosExpression"] = "Parlamentar";
                    Session["SolicitaDocumentosDirection"] = "ASC";
                }
            }
            else
            {
                PesquisaSenadores pesquisaSenadores = new PesquisaSenadores();
                pesquisaSenadores.DocumentosFornecedor(GridViewResultado, lblCNPJ.InnerText, DropDownListParlamentar.SelectedValue);

                if (GridViewResultado.Rows.Count > 0)
                {
                    Session["SolicitaDocumentosSenadores"] = GridViewResultado.DataSource;
                    Session["SolicitaDocumentosExpressionSenadores"] = "Parlamentar";
                    Session["SolicitaDocumentosDirectionSenadores"] = "ASC";
                }
            }
        }

        protected void GridViewResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double valor;

                if (Double.TryParse(e.Row.Cells[4].Text, out valor))
                    e.Row.Cells[4].Text = Convert.ToDouble(valor).ToString("N2");
                else
                    e.Row.Cells[4].Text = "0,00";

                mTotalGeralDep += Convert.ToDouble(e.Row.Cells[4].Text);

                try
                {
                    e.Row.Cells[3].Text = Convert.ToDateTime(e.Row.Cells[3].Text).ToString("dd/MM/yyyy");
                }
                catch
                {}

                long refDoc;

                if (Int64.TryParse(e.Row.Cells[7].Text, out refDoc))
                {
                    if (refDoc > 0)
                    {
                        HyperLink url = new HyperLink();
                        url.NavigateUrl = "http://www.camara.gov.br/cota-parlamentar/documentos/publ/" + e.Row.Cells[5].Text + "/" + e.Row.Cells[6].Text + "/" + e.Row.Cells[7].Text + ".pdf";
                        url.Target = "_blank";
                        url.Text = e.Row.Cells[2].Text;
                        e.Row.Cells[2].Controls.Clear();
                        e.Row.Cells[2].Controls.Add(url);
                    }
                }
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[4].Text = mTotalGeralDep.ToString("N2");
                //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        protected void ButtonGerar_Click(object sender, EventArgs e)
        {
            GerarTexto(GridViewResultado);
            LabelSel.Visible = false;
            HyperLinkDoc.Visible = true;

            if (DropDownListParlamentar.SelectedItem.Text.IndexOf("(DEPUTADO FEDERAL)") > 0)
            {
                HyperLinkDoc.Text = "Clique aqui para abrir uma solicitação no Fale Conosco da Câmara dos Deputados. Copie o texto abaixo e cole na mensagem da solicitação. Após a solicitação ser processada a Câmara enviará um e-mail com instruções de como fazer o pagamento. O custo é de R$ 0,15 centavos por folha.";
                HyperLinkDoc.NavigateUrl = "http://www2.camara.leg.br/participe/fale-conosco/?contexto=biblarq";
                HyperLinkDoc.Target = "_blank";
            }
            else
            {
                HyperLinkDoc.Visible = true;
                HyperLinkDoc.Text = "Clique aqui para abrir uma solicitação no Portal da Transparência do Senado. Copie o texto abaixo e cole na mensagem da solicitação. Após a solicitação ser processada o Senado enviará um e-mail com instruções.";
                HyperLinkDoc.NavigateUrl = "http://www.senado.gov.br/transparencia/formtransp.asp";
                HyperLinkDoc.Target = "_blank";
            }
        }

        private void GerarTexto(GridView grid)
        {
            StringBuilder texto = new StringBuilder();

            texto.AppendLine("Sou membro da Operação Política Supervisionada (OPS) e solicito uma cópia das notas fiscais discriminadas abaixo com base na Lei 12.527 de 18 de novembro de 2011.");


            foreach (GridViewRow row in grid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBoxSelecionar") as CheckBox);

                    if (chkRow.Checked)
                    {
                        texto.AppendLine("");
                        texto.AppendLine("Parlamentar: " + row.Cells[1].Text);
                        texto.AppendLine("Fornecedor : " + lblCNPJ.InnerText + " - " + lblrazaoSocial.InnerText);
                        texto.AppendLine("NF/Recibo  : " + row.Cells[2].Text);
                        texto.AppendLine("Dt. Emissão: " + row.Cells[3].Text);
                        texto.AppendLine("Valor      : " + row.Cells[4].Text);
                    }
                }
            }

            texto.AppendLine("");
            texto.AppendLine("Certo de sua colaboração desde já agradeço.");
            texto.AppendLine("www.ops.net.br");

            TextBoxTexto.Text = HttpUtility.HtmlDecode(texto.ToString());
            TextBoxTexto.Visible = true;
        }

        protected void GridViewResultado_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = Session["SolicitaDocumentos"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                GridViewResultado.DataSource = Session["SolicitaDocumentos"];
                GridViewResultado.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "DESC";

            // Retrieve the last column that was sorted.
            string sortExpression = Session["SolicitaDocumentosSortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = Session["SolicitaDocumentosSortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "DESC"))
                    {
                        sortDirection = "ASC";
                    }
                }
            }

            Session["SolicitaDocumentosSortExpression"] = column;
            Session["SolicitaDocumentosSortDirection"] = sortDirection;

            return sortDirection;
        }

        protected void DropDownListParlamentar_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaNotas();
        }
    }
}