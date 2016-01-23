<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeBehind="PesquisaAbas.aspx.cs" Inherits="AuditoriaParlamentar.PesquisaAbas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/assets/css/style.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <style type="text/css">
        #dialog label, #dialog input { display: block; }

        #dialog label { margin-top: 0.5em; }

        #dialog input, #dialog textarea { width: 95%; }

        #tabs { margin: 0px; width: 99%; padding: 0px; }

            #tabs li .ui-icon-close { float: left; margin: 0.4em 0.2em 0 0; cursor: pointer; }

        #add_tab { cursor: pointer; }

        .tab-pane { height: 100%; }
    </style>

    <script language="javascript" type="text/javascript">
        var mFiltro = "";
        var mDescricao = "";
        var mGrupo = "";
        var mAgrupamentoAtual = "";
        var mSeparaMes = "";
        var mPeriodo = "";
        var mAnoIni = "";
        var mMesIni = "";
        var mAnoFim = "";
        var mMesFim = "";
        var mParlamentar = "";
        var mDespesa = "";
        var mFornecedor = "";
        var mUF = "";
        var mPartido = "";
        var mDocumento = "";

        var tabTemplate = "<li><a href='#{href}' data-toggle='tab'>#{label}&nbsp;<i class='tab-close glyphicon glyphicon-remove' title='Fechar'></i></a></li>";
        var frameTemplate = "<div id='#{id}' class='tab-pane'><iframe src='#{src}' frameborder='0' width='100%'/></div>"
        var tabCounter = 1;
        var idCounter = 1;

        $(function () {
            // modal dialog init: custom buttons and a "close" callback reseting the form inside
            var $dialog = $('#modal-agrupamento');
            $dialog.on('hidden.bs.modal', function (e) {
                form[0].reset();
            })

            $('.acao-agrupamento').click(function () {
                addTabPesquisa($(this).attr('value'));
                $dialog.modal('hide');
            });

            // addTab form: calls addTab function on submit and closes the dialog
            var form = $("form").submit(function (event) {
                addTabPesquisa();
                $dialog.dialog("hide");
                event.preventDefault();
            });

            var tabs = $("#tabs").tab();

            // close icon: removing the tab on click
            tabs.delegate("i.tab-close", "click", function (e) {
                console.log('fechar aba')
                var $tab = $(this).parent();
                $($tab.attr('href')).remove();
                $tab.parent().remove();
                tabCounter--;

                if ($('#tabs li.active').length == 0)
                    $('#tabs li:eq(' + (tabCounter - 1) + ') a').tab('show');
            });
        });

        function closeTab() {
            var $tabs = $("#tabs").find("li.active");
            $($tabs.find('a').attr('href')).remove();
            $tabs.remove();

            tabCounter--;
            if ($('#tabs li.active').length == 0)
                $('#tabs li:eq(' + (tabCounter - 1) + ') a').tab('show');
        }

        function addTab(titulo, src) {
            var id = "tabs-" + idCounter;
            var li = $(tabTemplate.replace(/#\{href\}/g, "#" + id).replace(/#\{label\}/g, titulo));

            $('#tab-content').append(frameTemplate.replace(/#\{id\}/g, id).replace(/#\{src\}/g, src));
            var $tabs = $('#tabs');
            $tabs.append(li);
            //$tabs.unbind().tab();
            $tabs.find('a:last').tab('show');
        }

        // actual addTab function: adds new tab using the input from the form above
        function addTabPesquisa(agrupamentoNovo) {
            tabCounter++;
            idCounter++;

            var src = "PesquisaResultado.aspx?id=" + idCounter + "&filtro=" + mFiltro + "&descricao=" + mDescricao + "&grupo=" + mGrupo + "&agrupamentoAtual=" + mAgrupamentoAtual + "&agrupamentoNovo=" + agrupamentoNovo + "&separaMes=" + mSeparaMes + "&periodo=" + mPeriodo + "&anoIni=" + mAnoIni + "&mesIni=" + mMesIni + "&anoFim=" + mAnoFim + "&mesFim=" + mMesFim + "&parlamentar=" + mParlamentar + "&despesa=" + mDespesa + "&fornecedor=" + mFornecedor + "&uf=" + mUF + "&partido=" + mPartido + "&documento=" + mDocumento;

            addTab(agrupamentoNovo, src);
        }

        function addTabAuditoria(tipo, valor) {
            tabCounter++;
            idCounter++;

            var src;
            if (tipo == "J") {
                src = 'AuditoriaFornecedor.aspx?codigo=' + valor;
            }
            else {
                src = 'AuditoriaPF.aspx?codigo=' + valor;
            }

            addTab("Auditoria", src);
        }

        function addTabDenuncia(cnpj, nome) {
            tabCounter++;
            idCounter++;

            var src = "DenunciarFornecedor.aspx?Cnpj=" + cnpj + "&Nome=" + nome;

            addTab("Denúncia", src);
        }

        function addTabDoacao(cnpj, nome) {
            tabCounter++;
            idCounter++;

            var src = "ReceitasEleicao.aspx?Cnpj=" + cnpj + "&Nome=" + nome;

            addTab("Doações", src);
        }

        function addTabDocumentos(cnpj, nome, tipo) {
            tabCounter++;
            idCounter++;

            var title = "";
            var pag = "";

            if (tipo == 0) {
                title = "Parlamentares";
                pag = "FornecedorParlamentares.aspx";
            }
            else {
                title = "Documentos";
                pag = "SolicitaDocumentos.aspx";
            }

            var src = pag + "?Cnpj=" + cnpj + "&Nome=" + nome;

            addTab(title, src);
        }

        function TabPesquisa(filtro, descricao, grupo, agrupamentoAtual, separaMes, periodo, anoIni, mesIni, anoFim, mesFim, parlamentar, despesa, fornecedor, uf, partido, documento, novoAgrupamento) {
            mFiltro = filtro;
            mDescricao = descricao;
            mGrupo = grupo;
            mAgrupamentoAtual = agrupamentoAtual;
            mSeparaMes = separaMes;
            mPeriodo = periodo;
            mAnoIni = anoIni;
            mMesIni = mesIni;
            mAnoFim = anoFim;
            mMesFim = mesFim;
            mParlamentar = parlamentar;
            mDespesa = despesa;
            mFornecedor = fornecedor;
            mUF = uf;
            mPartido = partido;
            mDocumento = documento;

            if (novoAgrupamento == '') {
                $('body,html', window.parent.parent.document).animate({ scrollTop: 0 }, 600);

                //just opens the dialog
                $('#modal-agrupamento').modal();
            }
            else {
                addTabPesquisa(novoAgrupamento);
            }

        }

        function AlertaSemCnpj() {
            $("#dialog-message").modal();
            $('body,html', window.parent.parent.document).animate({ scrollTop: 0 }, 600);
        }

        function TabAuditoria(tipo, valor) {
            addTabAuditoria(tipo, valor);
        }

        function TabDenuncia(cnpj, nome) {
            addTabDenuncia(cnpj, nome);
        }
        function TabDoacoes(cnpj, nome) {
            addTabDoacao(cnpj, nome);
        }
    </script>
</head>
<body>
    <div class="modal fade" id="dialog-message" title="Auditar" style="display: none" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">Fornecedor sem CNPJ</h4>
                </div>
                <div class="modal-body">
                    Não será possível auditar este fornecedor porque seu CNPJ/CPF não está disponível.
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
    <div id="dialog" title="Nível de Pesquisa">
        <form runat="server" id="form_auditoria">
            <div class="modal fade" tabindex="-1" role="dialog" id="modal-agrupamento">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">Agrupamento</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Repeater ID="rptAgrupamento" runat="server">
                                <ItemTemplate>
                                    <input type="button" class="btn btn-primary acao-agrupamento" value="<%# Container.DataItem.ToString() %>" />
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <ul id="tabs" class="nav nav-tabs" data-tabs="tabs">
        <li class="active"><a href="#tabs-1" data-toggle="tab"><%= Titulo%></a></li>
    </ul>
    <br />
    <div id="tab-content" class="tab-content">
        <div class="tab-pane active" id="tabs-1">
            <iframe id="frame" src="<%= Pagina%>" frameborder="0" width="100%" style="height: 100%;" />
        </div>
    </div>
</body>
</html>

