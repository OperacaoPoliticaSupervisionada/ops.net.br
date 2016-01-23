using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Web.Services;

namespace AuditoriaParlamentar
{
    public partial class AuditoriaFornecedor : System.Web.UI.Page
    {
        public Int64 Id { get; set; }
        public String UserName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewDenuncias.PreRender += GridViewDenuncias_PreRender;

            if (!IsPostBack && Request.QueryString["codigo"] != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated == false)
                    Response.Redirect("~/Account/Login.aspx");

                String forcarConsulta;

                lblCNPJ.InnerText = Request.QueryString["codigo"];
                forcarConsulta = Request.QueryString["forcarConsulta"];

                if (lblCNPJ.InnerText == "")
                {
                    Response.Redirect("~/PesquisaInicio.aspx");
                }
                else
                {
                    Fornecedor fornecedor = new Fornecedor();
                    if (fornecedor.EstaAtualizado(lblCNPJ.InnerText) && fornecedor.CarregaDados(lblCNPJ.InnerText))
                    {
                        fornecedor.MarcaVisitado(System.Web.HttpContext.Current.User.Identity.Name);

                        lblAtividadePrincipal.InnerText = fornecedor.AtividadePrincipal;
                        lblBairro.InnerText = fornecedor.Bairro;
                        lblCep.InnerText = fornecedor.Cep;
                        lblCidade.InnerText = fornecedor.Cidade;
                        lblCNPJ.InnerText = fornecedor.Cnpj;
                        lblComplemento.InnerText = fornecedor.Complemento;
                        lblDataAbertura.InnerText = fornecedor.DataAbertura;
                        lblDataSituacaoCadastral.InnerText = fornecedor.DataSituacao;
                        lblDataSituacaoEspecial.InnerText = fornecedor.DataSituacaoEspecial;
                        lblLogradouro.InnerText = fornecedor.Logradouro;
                        lblMotivoSituacaoCadastral.InnerText = fornecedor.MotivoSituacao;
                        lblCodigoDescricaoNaturezaJuridica.InnerText = fornecedor.NaturezaJuridica;
                        lblNomeFantasia.InnerText = fornecedor.NomeFantasia;
                        lblNumero.InnerText = fornecedor.Numero;
                        lblRazaoSocial.InnerText = fornecedor.RazaoSocial;
                        lblSituacaoCadastral.InnerText = fornecedor.Situacao;
                        lblSituacaoEspecial.InnerText = fornecedor.SituacaoEspecial;
                        lblUf.InnerText = fornecedor.Uf;
                        lblEmail.InnerText = fornecedor.Email;
                        lblTelefone.InnerText = fornecedor.Telefone;
                        lblEnteFederativoResponsavel.InnerText = fornecedor.EnteFederativoResponsavel;

                        lblAtividadeSecundaria.InnerHtml = fornecedor.AtividadeSecundaria01;

                        if (fornecedor.AtividadeSecundaria02 != "" && fornecedor.AtividadeSecundaria02 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria02;

                        if (fornecedor.AtividadeSecundaria03 != "" && fornecedor.AtividadeSecundaria03 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria03;

                        if (fornecedor.AtividadeSecundaria04 != "" && fornecedor.AtividadeSecundaria04 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria04;

                        if (fornecedor.AtividadeSecundaria05 != "" && fornecedor.AtividadeSecundaria05 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria05;

                        if (fornecedor.AtividadeSecundaria06 != "" && fornecedor.AtividadeSecundaria06 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria06;

                        if (fornecedor.AtividadeSecundaria07 != "" && fornecedor.AtividadeSecundaria07 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria07;

                        if (fornecedor.AtividadeSecundaria08 != "" && fornecedor.AtividadeSecundaria08 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria08;

                        if (fornecedor.AtividadeSecundaria09 != "" && fornecedor.AtividadeSecundaria09 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria09;

                        if (fornecedor.AtividadeSecundaria10 != "" && fornecedor.AtividadeSecundaria10 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria10;

                        if (fornecedor.AtividadeSecundaria11 != "" && fornecedor.AtividadeSecundaria11 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria11;

                        if (fornecedor.AtividadeSecundaria12 != "" && fornecedor.AtividadeSecundaria12 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria12;

                        if (fornecedor.AtividadeSecundaria13 != "" && fornecedor.AtividadeSecundaria13 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria13;

                        if (fornecedor.AtividadeSecundaria14 != "" && fornecedor.AtividadeSecundaria14 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria14;

                        if (fornecedor.AtividadeSecundaria15 != "" && fornecedor.AtividadeSecundaria15 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria15;

                        if (fornecedor.AtividadeSecundaria16 != "" && fornecedor.AtividadeSecundaria16 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria16;

                        if (fornecedor.AtividadeSecundaria17 != "" && fornecedor.AtividadeSecundaria17 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria17;

                        if (fornecedor.AtividadeSecundaria18 != "" && fornecedor.AtividadeSecundaria18 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria18;

                        if (fornecedor.AtividadeSecundaria19 != "" && fornecedor.AtividadeSecundaria19 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria19;

                        if (fornecedor.AtividadeSecundaria20 != "" && fornecedor.AtividadeSecundaria20 != null)
                            lblAtividadeSecundaria.InnerHtml += "<br />" + fornecedor.AtividadeSecundaria20;

                        fsConsultaReceita.Style.Add("display", "none");

                        ButtonListarDoacoes.Visible = fornecedor.Doador;

                        if (fornecedor.DataInclusao != DateTime.MinValue)
                        {
                            //TODO: Consultar data da Ultima NF e comparar com a data de pesquisa (DataInclusao).
                            dvInfoDataConsultaCNPJ.Visible = true;
                            dvInfoDataConsultaCNPJ.InnerHtml = string.Format("As informações abaixo foram consultadas em {0:dd/MM/yyyy HH:mm}. Clique <a href='#' onclick='ReconsultarDadosReceita(); return false;'>aqui</a> para atualizar os dados a partir da Receita Federal.", fornecedor.DataInclusao);
                        }

                    }
                    else
                    {
                        fsDadosReceita.Style.Add("display", "none");
                        dvBotoesAcao.Style.Add("display", "none");

                        captcha_img.Src = GetCaptcha();
                    }


                    Denuncia denuncia = new Denuncia();
                    denuncia.DenunciasFornecedorResumida(GridViewDenuncias, fornecedor.Cnpj);

                    if (GridViewDenuncias.Rows.Count > 0)
                    {
                        fsMinhasDenuncias.Visible = true;

                        if (GridViewDenuncias.Rows.Count == 1)
                            LabelExisteDenuncia.InnerText = "Este fornecedor possui 1 denúncia. Evite enviar denúncias repetidas caso existam outras recentes.";
                        else
                            LabelExisteDenuncia.InnerText = "Este fornecedor possui " + GridViewDenuncias.Rows.Count.ToString() + " denúncias. Evite enviar denúncias repetidas caso existam outras recentes.";
                    }
                    else
                    {
                        fsMinhasDenuncias.Visible = false;
                    }
                }

                ButtonAtualizar.Visible = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        private void GridViewDenuncias_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridViewDenuncias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
            }
        }

        private const string urlBaseReceitaFederal = "http://www.receita.fazenda.gov.br/pessoajuridica/cnpj/cnpjreva/";
        private const string paginaValidacao = "valida.asp";
        private const string paginaPrincipal = "cnpjreva_solicitacao2.asp";
        private const string paginaCaptcha = "captcha/gerarCaptcha.asp";
        private const string paginaQuadroSocietario = "Cnpjreva_qsa.asp";

        [WebMethod(EnableSession = true)]
        public static string GetCaptcha()
        {
            CookieContainer _cookies = new CookieContainer();
            var htmlResult = string.Empty;

            using (var wc = new CookieAwareWebClient(_cookies))
            {
                wc.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; Synapse)";
                wc.Headers[HttpRequestHeader.KeepAlive] = "300";
                htmlResult = wc.DownloadString(urlBaseReceitaFederal + paginaPrincipal);
            }

            if (htmlResult.Length > 0)
            {
                var wc2 = new CookieAwareWebClient(_cookies);
                wc2.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (compatible; Synapse)";
                wc2.Headers[HttpRequestHeader.KeepAlive] = "300";
                byte[] data = wc2.DownloadData(urlBaseReceitaFederal + paginaCaptcha);

                HttpContext.Current.Session["cookies"] = _cookies;

                return "data:image/jpeg;base64," + Convert.ToBase64String(data, 0, data.Length);
            }

            return string.Empty;
        }

        [WebMethod(EnableSession = true)]
        public static dynamic ConsultarDados(string cnpj, string captcha)
        {
            var msg = string.Empty;
            var resp = ObterDados(cnpj, captcha);

            if (resp.Contains("Verifique se o mesmo foi digitado corretamente"))
                msg = "O número do CNPJ não foi localizado na Receita Federal";

            if (resp.Contains("Erro na Consulta"))
                msg += "Os caracteres não conferem com a imagem";

            Fornecedor fornecedor = null;
            if (resp.Length > 0)
            {
                fornecedor = new FormatarDados().MontarObjFornecedor(cnpj, resp);
                if (fornecedor != null)
                {
                    var UserName = HttpContext.Current.User.Identity.Name;

                    fornecedor.IdAtualizacao = Comum.Encrypt(fornecedor.PreparaAtualizacao(UserName).ToString());
                    fornecedor.UsuarioInclusao = UserName;
                    fornecedor.DataInclusao = DateTime.Now;

                    fornecedor.AtualizaDados();

                    fornecedor.MarcaVisitado(UserName);
                }
            }

            if (fornecedor.AtividadeSecundaria02 != "" && fornecedor.AtividadeSecundaria02 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria02;

            if (fornecedor.AtividadeSecundaria03 != "" && fornecedor.AtividadeSecundaria03 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria03;

            if (fornecedor.AtividadeSecundaria04 != "" && fornecedor.AtividadeSecundaria04 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria04;

            if (fornecedor.AtividadeSecundaria05 != "" && fornecedor.AtividadeSecundaria05 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria05;

            if (fornecedor.AtividadeSecundaria06 != "" && fornecedor.AtividadeSecundaria06 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria06;

            if (fornecedor.AtividadeSecundaria07 != "" && fornecedor.AtividadeSecundaria07 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria07;

            if (fornecedor.AtividadeSecundaria08 != "" && fornecedor.AtividadeSecundaria08 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria08;

            if (fornecedor.AtividadeSecundaria09 != "" && fornecedor.AtividadeSecundaria09 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria09;

            if (fornecedor.AtividadeSecundaria10 != "" && fornecedor.AtividadeSecundaria10 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria10;

            if (fornecedor.AtividadeSecundaria11 != "" && fornecedor.AtividadeSecundaria11 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria11;

            if (fornecedor.AtividadeSecundaria12 != "" && fornecedor.AtividadeSecundaria12 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria12;

            if (fornecedor.AtividadeSecundaria13 != "" && fornecedor.AtividadeSecundaria13 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria13;

            if (fornecedor.AtividadeSecundaria14 != "" && fornecedor.AtividadeSecundaria14 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria14;

            if (fornecedor.AtividadeSecundaria15 != "" && fornecedor.AtividadeSecundaria15 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria15;

            if (fornecedor.AtividadeSecundaria16 != "" && fornecedor.AtividadeSecundaria16 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria16;

            if (fornecedor.AtividadeSecundaria17 != "" && fornecedor.AtividadeSecundaria17 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria17;

            if (fornecedor.AtividadeSecundaria18 != "" && fornecedor.AtividadeSecundaria18 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria18;

            if (fornecedor.AtividadeSecundaria19 != "" && fornecedor.AtividadeSecundaria19 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria19;

            if (fornecedor.AtividadeSecundaria20 != "" && fornecedor.AtividadeSecundaria20 != null)
                fornecedor.AtividadeSecundaria01 += "<br />" + fornecedor.AtividadeSecundaria20;

            return
                new
                {
                    erro = msg,
                    dados = fornecedor
                };
        }

        private static string ObterDados(string aCNPJ, string aCaptcha)
        {
            CookieContainer _cookies = new CookieContainer();
            _cookies = (CookieContainer)HttpContext.Current.Session["cookies"];

            var request = (HttpWebRequest)WebRequest.Create(urlBaseReceitaFederal + paginaValidacao);
            request.ProtocolVersion = HttpVersion.Version10;
            request.CookieContainer = _cookies;
            request.Method = "POST";

            var postData = string.Empty;
            postData += "origem=comprovante&";
            postData += "cnpj=" + new Regex(@"[^\d]").Replace(aCNPJ, string.Empty) + "&";
            postData += "txtTexto_captcha_serpro_gov_br=" + aCaptcha + "&";
            postData += "submit1=Consultar&";
            postData += "search_type=cnpj";

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            var stHtml = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));
            return stHtml.ReadToEnd();
        }
    }
}
