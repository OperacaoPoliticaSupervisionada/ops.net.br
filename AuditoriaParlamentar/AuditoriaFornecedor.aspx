<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditoriaFornecedor.aspx.cs"
    Inherits="AuditoriaParlamentar.AuditoriaFornecedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .btn { margin-bottom: 10px; }
    </style>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#buscar-captcha-btn").on("click", function (e) {
                e.preventDefault();

                $("#captcha_img").fadeOut(1000, function () {
                    $(this).attr('src', "");
                    BuscarCaptcha();
                });

            });

            $("#buscarDados-btn").on("click", function () {
                if ($("#img-input").val()) {
                    ObterDados();
                } else {
                    alert('Digite o texto da imagem!');
                    $("#img-input").focus();
                }
            });

            $('#ButtonMaps').click(function (e) {
                e.preventDefault();
                window.open("http://maps.google.com/?q=" +
                    $('#lblLogradouro').text() + ',' +
                    $('#lblNumero').text() + ',' +
                    $('#lblCep').text().replace(".", "") + ',' +
                    $('#lblUf').text() + ',Brasil');
            });

            $('#ButtonPesquisa').click(function (e) {
                e.preventDefault();
                window.open("http://www.google.com.br/search?q=" +
                    $('#lblRazaoSocial').text() + ',' +
                    $('#lblCidade').text() + ',' +
                    $('#Uf').text());
            });

            $('#ButtonAtualizar').click(function (e) {
                e.preventDefault();

                ReconsultarDadosReceita();
            });

            $('#ButtonDenunciar').click(function (e) {
                e.preventDefault();
                window.parent.TabDenuncia($("#lblCNPJ").text(), $("#lblRazaoSocial").text());
            });

            $('#ButtonListarDoacoes').click(function (e) {
                e.preventDefault();
                window.parent.TabDoacoes($("#lblCNPJ").text(), $("#lblRazaoSocial").text());
            });

            $('#ButtonListarDeputados').click(function (e) {
                e.preventDefault();
                window.parent.addTabDocumentos($("#lblCNPJ").text(), $("#lblRazaoSocial").text(), 0);
            });

            $('#ButtonListarDocumentos').click(function (e) {
                e.preventDefault();
                window.parent.addTabDocumentos($("#lblCNPJ").text(), $("#lblRazaoSocial").text(), 1);
            });
        });

        function ReconsultarDadosReceita() {
            BuscarCaptcha();

            $("#fsConsultaReceita").show();
        };

        var pathLoader = "<%= ResolveClientUrl("~/") %>assets/img/ajax-loader-facebook.gif";
        var $loader = $('<img class="loader-facebook" src="' + pathLoader + '"/> <em>Buscando ...</em>');

        var BuscarCaptcha = function () {
            var strUrl = 'AuditoriaFornecedor.aspx/GetCaptcha';
            $.ajax({
                type: 'post',
                url: strUrl,
                data: {},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                async: true,
                beforeSend: function () {
                    $loader.insertAfter($("#captcha_img"));
                },
                success: function (data) {
                    $("#captcha_img").removeClass("hidden").attr('src', data.d).fadeIn(1000);
                    $('#img-input').val('').focus();
                },
                complete: function () {
                    $loader.remove();
                    $("#img-input").focus();
                },
                error: function (err) {
                    alert("erro na tentativa de obter o captcha");
                }
            });
        };

        var ObterDados = function () {
            var strUrl = 'AuditoriaFornecedor.aspx/ConsultarDados';
            $.ajax({
                type: 'post',
                url: strUrl,
                cache: false,
                async: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ "cnpj": $("#lblCNPJ").text(), "captcha": $("#img-input").val() }),
                beforeSend: function () {
                    $loader.insertBefore($("#fechar-button"));
                },
                success: function (data) {
                    $loader.remove();
                    if (data.d.erro.length > 0) {
                        $("#msgErro-span").text(data.d.erro).closest("p").removeClass("hidden");
                        $("#captcha_img").fadeOut(1000, function () {
                            $(this).attr('src', "");
                            BuscarCaptcha();
                            $("#img-input").focus();
                        });
                        setTimeout(function () {
                            $("#msgErro-span").closest("p").addClass("hidden");
                        }, 2000);
                    } else {
                        if (data.d.dados != null) {
                            PreencheDados(data.d.dados, false);
                            $("#buscar-modal").modal("hide");

                            $("#fsConsultaReceita").hide();
                            $("#fsDadosReceita, #dvBotoesAcao").show();

                        } else {
                            $("#msgErro-span").text("erro de comunicação com a receita.").closest("p").removeClass("hidden");
                            $("#captcha_img").fadeOut(1000, function () {
                                $(this).attr('src', "");
                                BuscarCaptcha();
                                $("#img-input").focus();
                            });
                            setTimeout(function () {
                                $("#msgErro-span").closest("p").addClass("hidden");
                            }, 2000);
                        }

                    }
                },
                error: function (data) {
                    $loader.remove();
                    alert("erro de comunicação.");
                },
            });
        };

        var PreencheDados = function (dados) {
            $("#lblCNPJ").text(dados.Cnpj);
            $("#lblRazaoSocial").text(dados.RazaoSocial);
            $("#lblNomeFantasia").text(dados.NomeFantasia);
            $("#lblAtividadePrincipal").text(dados.AtividadePrincipal);
            $("#lblLogradouro").text(dados.Logradouro);
            $("#lblNumero").text(dados.Numero);
            $("#lblComplemento").text(dados.Complemento);
            $("#lblBairro").text(dados.Bairro);
            $("#lblCep").text(dados.Cep);
            $("#lblCidade").text(dados.Cidade);
            $("#lblUf").text(dados.Uf);
            $("#lblSituacaoCadastral").text(dados.Situacao);
            $("#lblDataSituacaoCadastral").text(dados.DataSituacao);
            $("#lblMotivoSituacaoCadastral").text(dados.MotivoSituacao);
            $("#lblCodigoDescricaoNaturezaJuridica").text(dados.NaturezaJuridica);
            $("#lblEmail").text(dados.Email);
            $("#lblTelefone").text(dados.Telefone);
            $("#lblEnteFederativoResponsavel").text(dados.EnteFederativoResponsavel);
            $("#lblDataAbertura").text(dados.DataAbertura);
            $("#lblSituacaoEspecial").text(dados.SituacaoEspecial);
            $("#lblDataSituacaoEspecial").text(dados.DataSituacaoEspecial);
            $("#lblAtividadeSecundaria").html(dados.AtividadeSecundaria01);
        };

    </script>
</head>
<body>
    <div class="container-fluid">
        <form id="form1" runat="server">
            <fieldset id="fsConsultaReceita" runat="server">
                <legend>Consulta de CNPJ na Receita Federal</legend>
                <div class="row">
                    <div class="col-md-4 col-md-offset-2">
                        <div class="col-md-12">
                            <div class="form-group img-captcha" style="height: 50px">
                                <img id="captcha_img" runat="server" title="Informe o texto da imagem" alt="Captcha" src="#" />
                                <a href="#" id="buscar-captcha-btn" class="btn btn-warning btn-sm" style="margin-left: 3px" title="Carregar outra imagem"><i class="glyphicon glyphicon-refresh"></i></a>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Digite o Captcha</label>
                                <div class="input-group">
                                    <input type="text" id="img-input" value="" class="form-control input-sm input-sm" />
                                    <span class="input-group-btn">
                                        <button type="button" id="buscarDados-btn" class="btn btn-primary btn-sm">Buscar</button>
                                    </span>
                                </div>
                                <p class="bg-danger pull-left hidden msg" style="padding: 10px 20px;">
                                    <i class="glyphicon glyphicon-warning-sign"></i>&nbsp;<strong><span id="msgErro-span"></span></strong>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <p class="text-justify">
                            O Captcha exibido é necessário para você consultar os dados do fornecedor na página da Receita Federal.<br />
                            Após a consulta as informações do fornecedor serão salvas para as próximas consultas e para os próximos
                        usuários que auditarem este fornecedor.<br />
                            Caso tenha alguma dúvida entre em <a href="mailto:suporte@ops.net.br">contato</a>.
                        </p>
                    </div>
                </div>
                <br />
            </fieldset>
            <div class="row" id="dvBotoesAcao" runat="server">

                <div class="col-md-12 text-center">
                    <a class="btn btn-primary btn-sm" data-toggle="modal" data-target="#dvQueProcurar">O Que Procurar?</a>
                    <asp:Button ID="ButtonAtualizar" runat="server" Text="Atualizar Dados" ToolTip="Reconsultar dados a partir da Receita Federal" CssClass="btn btn-primary btn-sm" />
                    <asp:Button ID="ButtonDenunciar" runat="server" Text="Denunciar" ToolTip="Denunciar esse Fornecedor" CssClass="btn btn-success btn-sm" />
                    <asp:Button ID="ButtonMaps" runat="server" Text="Pesquisar no Maps" ToolTip="Pesquisar Fornecedor no Maps" CssClass="btn btn-default btn-sm" />
                    <asp:Button ID="ButtonPesquisa" runat="server" Text="Pesquisar no Google" ToolTip="Pesquisar Fornecedor no Google" CssClass="btn btn-default btn-sm" />
                    <asp:Button ID="ButtonListarDeputados" runat="server" Text="Listar Parlamentares" ToolTip="Listar Todos os Parlamentares que Contrataram esse Fornecedor" CssClass="btn btn-default btn-sm" />
                    <asp:Button ID="ButtonListarDocumentos" runat="server" Text="Solicitar/Listar Documentos" CssClass="btn btn-default btn-sm" />
                    <asp:Button ID="ButtonListarDoacoes" runat="server" Text="Listar Doações Eleitorais" ToolTip="Listar Doações Eleitorais do Fornecedor" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
            <fieldset id="fsMinhasDenuncias" runat="server" visible="false">
                <legend>Denúncias</legend>
                <div class="row">
                    <div class="col-md-12">
                        <div runat="server" id="LabelExisteDenuncia" class="alert alert-danger"></div>
                    </div>
                    <div class="col-md-12">
                        <asp:GridView ID="GridViewDenuncias" runat="server" AllowSorting="True" UseAccessibleHeader="true"
                            CssClass="table table-hover table-striped" GridLines="None" ShowFooter="True">
                            <RowStyle CssClass="cursor-pointer" />
                        </asp:GridView>
                    </div>
                </div>
                <br />
            </fieldset>
            <fieldset id="fsDadosReceita" runat="server">
                <legend>Cadastro nacional da pessoa jurídica</legend>
                <div runat="server" id="dvInfoDataConsultaCNPJ" class="alert alert-warning" visible="false"></div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">CNPJ</label>
                            <span runat="server" id="lblCNPJ" class="control-label show"></span>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Data de abertura</label>
                            <span runat="server" id="lblDataAbertura" class="control-label show"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Razão social / Nome empresarial </label>
                            <span runat="server" id="lblRazaoSocial" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Nome fantasia / Título do estabelecimento</label>
                            <span runat="server" id="lblNomeFantasia" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label">Código e descrição da atividade econômica principal (CNAE)</label>
                            <span runat="server" id="lblAtividadePrincipal" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label">Código e descrição das atividades econômicas secundárias</label>
                            <span runat="server" id="lblAtividadeSecundaria" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label">Código e descrição da natureza jurídica</label>
                            <span runat="server" id="lblCodigoDescricaoNaturezaJuridica" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label class="control-label">Logradouro</label>
                            <span runat="server" id="lblLogradouro" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="control-label">Numero</label>
                            <span runat="server" id="lblNumero" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Complemento</label>
                            <span runat="server" id="lblComplemento" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Bairro / Distrito</label>
                            <span runat="server" id="lblBairro" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Município / Cidade</label>
                            <span runat="server" id="lblCidade" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="control-label">CEP</label>
                            <span runat="server" id="lblCep" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label class="control-label">UF</label>
                            <span runat="server" id="lblUf" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Situação Cadastral</label>
                            <span runat="server" id="lblSituacaoCadastral" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Data da situação cadastral</label>
                            <span runat="server" id="lblDataSituacaoCadastral" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Motivo de situação cadastral </label>
                            <span runat="server" id="lblMotivoSituacaoCadastral" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Situação especial</label>
                            <span runat="server" id="lblSituacaoEspecial" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Data da situação especial</label>
                            <span runat="server" id="lblDataSituacaoEspecial" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Ente federativo responsável (EFR)</label>
                            <span runat="server" id="lblEnteFederativoResponsavel" class="control-label show" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Endereço eletrônico (E-mail)</label>
                            <span runat="server" id="lblEmail" class="control-label show" />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="control-label">Telefone</label>
                            <span runat="server" id="lblTelefone" class="control-label show" />
                        </div>
                    </div>
                </div>
                <%--<div class="row">
                    <div class="col-md-12 text-center">
                        Clique <a href="http://www.receita.fazenda.gov.br/pessoajuridica/cnpj/cnpjreva/cnpjreva_solicitacao.asp" target="_blank" rel="nofollow">aqui</a> caso queira consultar as informações diretamente na Receita federal.
                    </div>
                </div>--%>
            </fieldset>
            <div id="dvQueProcurar" class="modal fade" tabindex="-1" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">O que procurar?</h4>
                        </div>
                        <div class="modal-body text-justify">
                            <p>
                                A primeira coisa que você pode fazer para começar a investigar este fornecedor é analisar seu endereço. Empresas localizadas em áreas residênciais ou em regiões pobres da cidade podem ser consideradas estranhas. Você pode utilizar o Google Maps e o Street View (se estiver disponível) para avaliar a localização da empresa. Você poderá inclusive visitar a região se tiver condições.
                            </p>
                            <p>
                                Outra opção é pesquisa pela internet se a empresa possui uma página na internet e se ela realmente fornece o serviço prestado ao parlamentar. Empresas sérias não se escondem e são facilmente localizadas.
                            </p>
                            <p>
                                Para descobrir os donos da empresa você poderá ir até a Junta Comercial da cidade onde a empresa está localizada para solicitar as informações. Será uma informação muito importante porque será possível investigar se é algum conhecido do Parlamentar. A Junta Comercial irá cobrar uma taxa para fornecer esta informação.
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" data-dismiss="modal">Entendi</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
