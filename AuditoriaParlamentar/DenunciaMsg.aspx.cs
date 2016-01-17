using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;
using System.Web.Security;
using System.IO;

namespace AuditoriaParlamentar
{
    public partial class DenunciaMsg : System.Web.UI.Page
    {
        Double mTotalGeral = 0;
        Boolean mNovaSituacao;
        Int64 mIdDenuncia;
        Boolean mRevisor;
        String mRetornoClose;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                Response.Redirect("~/Account/Login.aspx");

            mIdDenuncia = Convert.ToInt64(HttpUtility.HtmlDecode(Request.QueryString["IdDenuncia"]));
            mRevisor = Roles.IsUserInRole(System.Web.HttpContext.Current.User.Identity.Name, "REVISOR");

            mRetornoClose = Convert.ToString(HttpUtility.HtmlDecode(Request.QueryString["Retorno"]));

            if (!IsPostBack)
            {
                Denuncia denuncia = new Denuncia();
                denuncia.Carrega(mIdDenuncia, HttpContext.Current.User.Identity.Name, mRevisor);

                if (denuncia.IdDenuncia == 0)
                    Response.Redirect("~/Default.aspx");

                LabelId.Text = mIdDenuncia.ToString();
                LabelCNPJ.Text = denuncia.Cnpj;
                HyperLinkRazaoSocial.Text = denuncia.RazaoSocial;
                
                if (denuncia.Cnpj.Length == 11)
                    HyperLinkRazaoSocial.NavigateUrl = "javascript:window.parent.TabAuditoria('F','" + denuncia.Cnpj + "');";
                else
                    HyperLinkRazaoSocial.NavigateUrl = "javascript:window.parent.TabAuditoria('J','" + denuncia.Cnpj + "');";

                LabelData.Text = denuncia.DataDenuncia.ToString("dd/MM/yyyy hh:mm:ss");
                LabelSituacao.Text = denuncia.DesSituacao;
                LabelTexto.Text = denuncia.Texto;
                LabelUsuario.Text = denuncia.UsuarioDenuncia;

                if (denuncia.IdDenuncia > 0)
                {
                    Comentarios comentarios = new Comentarios();
                    comentarios.Carrega(GridViewComentarios, denuncia.IdDenuncia);

                    Anexos anexo = new Anexos();
                    anexo.Carrega(GridViewAnexo, denuncia.IdDenuncia);

                    AcompanhaDenuncias acompanha = new AcompanhaDenuncias();
                    acompanha.FornecedorParlamentares(GridViewDeputados, denuncia.Cnpj);
                }

                if (mRevisor)
                {
                    DropDownListSituacao.Visible = true;
                    DropDownListSituacao.Items.Add(new ListItem(Denuncia.TXT_SITUACAO_AGUARDANDO_REVISAO, Denuncia.SITUACAO_AGUARDANDO_REVISAO));
                    DropDownListSituacao.Items.Add(new ListItem(Denuncia.TXT_SITUACAO_PENDENTE_INFORMACOES, Denuncia.SITUACAO_PENDENTE_INFORMACOES));
                    DropDownListSituacao.Items.Add(new ListItem(Denuncia.TXT_SITUACAO_CASO_DUVIDOSO, Denuncia.SITUACAO_CASO_DUVIDOSO));
                    DropDownListSituacao.Items.Add(new ListItem(Denuncia.TXT_SITUACAO_CASO_DOSSIE, Denuncia.SITUACAO_CASO_DOSSIE));
                    DropDownListSituacao.Items.Add(new ListItem(Denuncia.TXT_SITUACAO_CASO_REPETIDO, Denuncia.SITUACAO_CASO_REPETIDO));
                    DropDownListSituacao.Items.Add(new ListItem(Denuncia.TXT_SITUACAO_NAO_PROCEDE, Denuncia.SITUACAO_NAO_PROCEDE));
                    DropDownListSituacao.SelectedValue = denuncia.Situacao;

                    GridViewDenuncias.EmptyDataText = "Este fornecedor ainda não possui denuncias.";
                    denuncia.DenunciasFornecedor(GridViewDenuncias);

                    if (denuncia.PendenteFoto == 1)
                    {
                        ButtonFotoExcluir.Visible = true;
                        ButtonFotoIncluir.Visible = false;
                    }
                    else
                    {
                        ButtonFotoExcluir.Visible = false;
                        ButtonFotoIncluir.Visible = true;
                    }
                }
                else
                {
                    DropDownListSituacao.Visible = false;
                    dvOutrasDenuncias.Visible = false;
                    ButtonFotoExcluir.Visible = false;
                    ButtonFotoIncluir.Visible = false;
                }

                if (mRetornoClose == "close")
                    ButtonVoltar.OnClientClick = "javaScript:window.parent.closeTab();";

                ButtonListarDocumentos.OnClientClick = "window.parent.addTabDocumentos('" + denuncia.Cnpj + "','" + denuncia.RazaoSocial + "');return false;";
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                if (!FileUpload.FileName.EndsWith(".zip", StringComparison.CurrentCultureIgnoreCase))
                {
                    AnexoValidator.ErrorMessage = "O anexo deverá estar compactado no formato ZIP";
                    AnexoValidator.IsValid = false;
                    return;
                }

                if (FileUpload.PostedFile.ContentLength > 10485760)
                {
                    AnexoValidator.ErrorMessage = "O anexo deverá ter no máximo 10 MB.";
                    AnexoValidator.IsValid = false;
                    return;
                }
            }

            Comentarios comentarios = new Comentarios();
            comentarios.IdDenuncia = mIdDenuncia;
            comentarios.UserName = HttpContext.Current.User.Identity.Name;
            comentarios.Texto = TextBoxComentario.Text;
            comentarios.Cnpj = LabelCNPJ.Text;
            comentarios.RazaoSocial = HyperLinkRazaoSocial.Text;
            comentarios.UserNameDenuncia = LabelUsuario.Text;

            if (mNovaSituacao == true)
            {
                comentarios.Texto += " [Situação alterada para " + DropDownListSituacao.SelectedItem.Text + "]";
            }

            if (comentarios.InsereComentario() == true)
            {
                if (FileUpload.HasFile)
                {
                    String dir = Server.MapPath("Denuncias") + "\\" + mIdDenuncia.ToString("0000");

                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    DirectoryInfo dirInfo = new DirectoryInfo(dir);

                    Anexos anexo = new Anexos();
                    anexo.IdDenuncia = mIdDenuncia;
                    anexo.UserName = HttpContext.Current.User.Identity.Name;
                    anexo.Arquivo = (dirInfo.GetFiles().Length + 1).ToString("00") + "_" + FileUpload.FileName;
                    anexo.InsereAnexo();

                    FileUpload.SaveAs(dir + "\\" + anexo.Arquivo);

                    anexo.Carrega(GridViewAnexo, mIdDenuncia);
                }

                TextBoxComentario.Text = "";
                comentarios.Carrega(GridViewComentarios, mIdDenuncia);
            }

            if (mNovaSituacao == true)
            {
                mNovaSituacao = false;

                Denuncia denuncia = new Denuncia();
                denuncia.AtualizaSituacao(mIdDenuncia, HttpContext.Current.User.Identity.Name, DropDownListSituacao.SelectedValue);

                LabelSituacao.Text = DropDownListSituacao.SelectedItem.Text;
            }
        }

        protected void GridViewComentarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Wrap = false;
            //e.Row.Cells[1].Wrap = false;

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Width = 100;
                //e.Row.Cells[1].Width = 100;
            }
        }

        protected void DropDownListSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            mNovaSituacao = true;
        }

        protected void ButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/" + mRetornoClose + ".aspx");
        }

        protected void GridViewAnexo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                Response.ContentType = "application/octate-stream";
                Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.HtmlDecode(GridViewAnexo.Rows[index].Cells[0].Text));
                Response.TransmitFile("~/Denuncias/" + mIdDenuncia.ToString("0000") + "/" + HttpUtility.HtmlDecode(GridViewAnexo.Rows[index].Cells[0].Text));
            }
        }

        protected void GridViewDeputados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            //e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Right;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Double valor;

                if (Double.TryParse(e.Row.Cells[6].Text, out valor))
                    e.Row.Cells[6].Text = Convert.ToDouble(valor).ToString("N2");
                else
                    e.Row.Cells[6].Text = "0,00";

                mTotalGeral += Convert.ToDouble(e.Row.Cells[6].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = mTotalGeral.ToString("N2");
            }
        }

        protected void ButtonFotoIncluir_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            if (fornecedor.IncluirSolicitacaoFoto(LabelCNPJ.Text))
            {
                ButtonFotoIncluir.Visible = false;
                ButtonFotoExcluir.Visible = true;
                DenunciaValidator.ErrorMessage = "Pendência incluída com sucesso.";
                DenunciaValidator.IsValid = false;
            }
        }

        protected void ButtonFotoExcluir_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            if (fornecedor.ExcluiSolicitacaoFoto(LabelCNPJ.Text))
            {
                ButtonFotoIncluir.Visible = true;
                ButtonFotoExcluir.Visible = false;
                DenunciaValidator.ErrorMessage = "Pendência excluída com sucesso.";
                DenunciaValidator.IsValid = false;
            }
        }
    }
}