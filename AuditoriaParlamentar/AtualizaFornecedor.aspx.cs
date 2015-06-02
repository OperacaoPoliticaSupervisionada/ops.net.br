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
    public partial class AtualizaFornecedor : System.Web.UI.Page
    {
        public String AgrupamentoFornecedor { get { return Pesquisa.AGRUPAMENTO_FORNECEDOR; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Boolean authenticated = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

                Classes.Fornecedor fornecedor = new Classes.Fornecedor();

                try
                {
                    fornecedor.Cnpj = HttpUtility.HtmlDecode(Request.QueryString["a"]);
                    fornecedor.IdAtualizacao = HttpUtility.HtmlDecode(Request.QueryString["b"]);
                }
                catch { }

                if (fornecedor.Cnpj != null && fornecedor.IdAtualizacao != null)
                {
                    fornecedor.RazaoSocial = HttpUtility.HtmlDecode(Request.QueryString["c"]);
                    fornecedor.NomeFantasia = HttpUtility.HtmlDecode(Request.QueryString["d"]);
                    fornecedor.AtividadePrincipal = HttpUtility.HtmlDecode(Request.QueryString["e"]);
                    fornecedor.NaturezaJuridica = HttpUtility.HtmlDecode(Request.QueryString["f"]);
                    fornecedor.Logradouro = HttpUtility.HtmlDecode(Request.QueryString["g"]);
                    fornecedor.Numero = HttpUtility.HtmlDecode(Request.QueryString["h"]);
                    fornecedor.Complemento = HttpUtility.HtmlDecode(Request.QueryString["i"]);
                    fornecedor.Cep = HttpUtility.HtmlDecode(Request.QueryString["j"]);
                    fornecedor.Bairro = HttpUtility.HtmlDecode(Request.QueryString["l"]);
                    fornecedor.Cidade = HttpUtility.HtmlDecode(Request.QueryString["m"]);
                    fornecedor.Uf = HttpUtility.HtmlDecode(Request.QueryString["n"]);
                    fornecedor.Situacao = HttpUtility.HtmlDecode(Request.QueryString["o"]);
                    fornecedor.DataSituacao = HttpUtility.HtmlDecode(Request.QueryString["p"]);
                    fornecedor.MotivoSituacao = HttpUtility.HtmlDecode(Request.QueryString["q"]);
                    fornecedor.SituacaoEspecial = HttpUtility.HtmlDecode(Request.QueryString["r"]);
                    fornecedor.DataSituacaoEspecial = HttpUtility.HtmlDecode(Request.QueryString["s"]);
                    fornecedor.DataAbertura = HttpUtility.HtmlDecode(Request.QueryString["t"]);
                    fornecedor.AtividadeSecundaria01 = HttpUtility.HtmlDecode(Request.QueryString["u"]);
                    fornecedor.AtividadeSecundaria02 = HttpUtility.HtmlDecode(Request.QueryString["v"]);
                    fornecedor.AtividadeSecundaria03 = HttpUtility.HtmlDecode(Request.QueryString["x"]);
                    fornecedor.AtividadeSecundaria04 = HttpUtility.HtmlDecode(Request.QueryString["z"]);
                    fornecedor.AtividadeSecundaria05 = HttpUtility.HtmlDecode(Request.QueryString["a1"]);
                    fornecedor.AtividadeSecundaria06 = HttpUtility.HtmlDecode(Request.QueryString["b1"]);
                    fornecedor.AtividadeSecundaria07 = HttpUtility.HtmlDecode(Request.QueryString["c1"]);
                    fornecedor.AtividadeSecundaria08 = HttpUtility.HtmlDecode(Request.QueryString["d1"]);
                    fornecedor.AtividadeSecundaria09 = HttpUtility.HtmlDecode(Request.QueryString["e1"]);
                    fornecedor.AtividadeSecundaria10 = HttpUtility.HtmlDecode(Request.QueryString["f1"]);
                    fornecedor.AtividadeSecundaria11 = HttpUtility.HtmlDecode(Request.QueryString["g1"]);
                    fornecedor.AtividadeSecundaria12 = HttpUtility.HtmlDecode(Request.QueryString["h1"]);
                    fornecedor.AtividadeSecundaria13 = HttpUtility.HtmlDecode(Request.QueryString["i1"]);
                    fornecedor.AtividadeSecundaria14 = HttpUtility.HtmlDecode(Request.QueryString["j1"]);
                    fornecedor.AtividadeSecundaria15 = HttpUtility.HtmlDecode(Request.QueryString["l1"]);
                    fornecedor.AtividadeSecundaria16 = HttpUtility.HtmlDecode(Request.QueryString["m1"]);
                    fornecedor.AtividadeSecundaria17 = HttpUtility.HtmlDecode(Request.QueryString["n1"]);
                    fornecedor.AtividadeSecundaria18 = HttpUtility.HtmlDecode(Request.QueryString["o1"]);
                    fornecedor.AtividadeSecundaria19 = HttpUtility.HtmlDecode(Request.QueryString["p1"]);
                    fornecedor.AtividadeSecundaria20 = HttpUtility.HtmlDecode(Request.QueryString["q1"]);
                    fornecedor.UsuarioInclusao = HttpUtility.HtmlDecode(Request.QueryString["r1"]);

                    if (fornecedor.AtualizaDados() == false)
                    {
                        Response.Write("<script>alert('Erro ao atualizar os dados ou acesso não autorizado.')</script>");
                        return;
                    }
                }
                else
                {
                    fornecedor.CarregaDados(fornecedor.Cnpj);
                }

                fornecedor.MarcaVisitado(System.Web.HttpContext.Current.User.Identity.Name);

                LabelAtividadePrincipal.Text = fornecedor.AtividadePrincipal;
                LabelBairro.Text = fornecedor.Bairro;
                LabelCep.Text = fornecedor.Cep;
                LabelCidade.Text = fornecedor.Cidade;
                LabelCNPJ.Text = fornecedor.Cnpj;
                LabelComplemento.Text = fornecedor.Complemento;
                LabelDataAbertura.Text = fornecedor.DataAbertura;
                LabelDataSituacao.Text = fornecedor.DataSituacao;
                LabelDataSituacaoEspecial.Text = fornecedor.DataSituacaoEspecial;
                LabelLogradouro.Text = fornecedor.Logradouro;
                LabelMotivoSituacao.Text = fornecedor.MotivoSituacao;
                LabelNaturezaJuridica.Text = fornecedor.NaturezaJuridica;
                LabelNomeFantasia.Text = fornecedor.NomeFantasia;
                LabelNumero.Text = fornecedor.Numero;
                LabelRazaoSocial.Text = fornecedor.RazaoSocial;
                LabelSituacao.Text = fornecedor.Situacao;
                LabelSituacaoEspecial.Text = fornecedor.SituacaoEspecial;
                LabelUf.Text = fornecedor.Uf;

                LabelAtividadeSecundaria.Text = fornecedor.AtividadeSecundaria01;

                if (fornecedor.AtividadeSecundaria02 != "" && fornecedor.AtividadeSecundaria02 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria02;

                if (fornecedor.AtividadeSecundaria03 != "" && fornecedor.AtividadeSecundaria03 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria03;

                if (fornecedor.AtividadeSecundaria04 != "" && fornecedor.AtividadeSecundaria04 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria04;

                if (fornecedor.AtividadeSecundaria05 != "" && fornecedor.AtividadeSecundaria05 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria05;

                if (fornecedor.AtividadeSecundaria06 != "" && fornecedor.AtividadeSecundaria06 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria06;

                if (fornecedor.AtividadeSecundaria07 != "" && fornecedor.AtividadeSecundaria07 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria07;

                if (fornecedor.AtividadeSecundaria08 != "" && fornecedor.AtividadeSecundaria08 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria08;

                if (fornecedor.AtividadeSecundaria09 != "" && fornecedor.AtividadeSecundaria09 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria09;

                if (fornecedor.AtividadeSecundaria10 != "" && fornecedor.AtividadeSecundaria10 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria10;

                if (fornecedor.AtividadeSecundaria11 != "" && fornecedor.AtividadeSecundaria11 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria11;

                if (fornecedor.AtividadeSecundaria12 != "" && fornecedor.AtividadeSecundaria12 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria12;

                if (fornecedor.AtividadeSecundaria13 != "" && fornecedor.AtividadeSecundaria13 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria13;

                if (fornecedor.AtividadeSecundaria14 != "" && fornecedor.AtividadeSecundaria14 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria14;

                if (fornecedor.AtividadeSecundaria15 != "" && fornecedor.AtividadeSecundaria15 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria15;

                if (fornecedor.AtividadeSecundaria16 != "" && fornecedor.AtividadeSecundaria16 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria16;

                if (fornecedor.AtividadeSecundaria17 != "" && fornecedor.AtividadeSecundaria17 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria17;

                if (fornecedor.AtividadeSecundaria18 != "" && fornecedor.AtividadeSecundaria18 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria18;

                if (fornecedor.AtividadeSecundaria19 != "" && fornecedor.AtividadeSecundaria19 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria19;

                if (fornecedor.AtividadeSecundaria20 != "" && fornecedor.AtividadeSecundaria20 != null)
                    LabelAtividadeSecundaria.Text += "<br />" + fornecedor.AtividadeSecundaria20;

                if (fornecedor.Logradouro != null)
                {
                    StringBuilder url = new StringBuilder();
                    url.Append("http://maps.google.com/?q=");
                    url.Append(fornecedor.Logradouro);
                    url.Append(", ");
                    url.Append(fornecedor.Numero);
                    url.Append(", ");
                    url.Append(fornecedor.Cep.Replace(".",""));
                    url.Append(", ");
                    url.Append(fornecedor.Uf);
                    url.Append(", Brasil");

                    ButtonMaps.OnClientClick = "window.open('" + url.ToString() + "');return false;";

                    url.Clear();
                    url.Append("http://www.google.com.br/search?q=");
                    url.Append(fornecedor.RazaoSocial);
                    url.Append(", ");
                    url.Append(fornecedor.Cidade);
                    url.Append(" ");
                    url.Append(fornecedor.Uf);                    

                    ButtonPesquisa.OnClientClick = "window.open('" + url.ToString() + "');return false;";
                }

                ButtonOque.OnClientClick = "$('#dialog-message').dialog('open');return false;";
                ButtonDenunciar.OnClientClick = "Denunciar();return false;";
                ButtonAtualizar.Visible = authenticated;
                ButtonListarDeputados.OnClientClick = "window.parent.addTabDocumentos('" + fornecedor.Cnpj + "','" + fornecedor.RazaoSocial + "', 0);return false;";
                ButtonListarDocumentos.OnClientClick = "window.parent.addTabDocumentos('" + fornecedor.Cnpj + "','" + fornecedor.RazaoSocial + "', 1);return false;";
                ButtonListarDoacoes.Visible = fornecedor.Doador;
                ButtonListarDoacoes.OnClientClick = "Doacoes();return false;";

                Denuncia denuncia = new Denuncia();
                denuncia.DenunciasFornecedorResumida(GridViewDenuncias, fornecedor.Cnpj);

                if (GridViewDenuncias.Rows.Count > 0)
                {
                    PanelExisteDenuncia.Visible = true;

                    if (GridViewDenuncias.Rows.Count == 1)
                        LabelExisteDenuncia.Text = "Este fornecedor possui 1 denúncia. Evite enviar denúncias repetidas caso existam outras recentes.";
                    else
                        LabelExisteDenuncia.Text = "Este fornecedor possui " + GridViewDenuncias.Rows.Count.ToString() + " denúncias. Evite enviar denúncias repetidas caso existam outras recentes.";
                }
                
            }
        }

        protected void ButtonAtualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuditoriaFornecedor.aspx?codigo=" + LabelCNPJ.Text + "&forcarConsulta=sim");
        }
    }
}