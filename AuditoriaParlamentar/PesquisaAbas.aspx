<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeBehind="PesquisaAbas.aspx.cs" Inherits="AuditoriaParlamentar.PesquisaAbas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link type="text/css" rel="stylesheet" href="Styles/Site.css"/>
    <link type="text/css" rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css"/>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.position.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.button.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.tabs.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.dialog.js"></script>

    <style type="text/css">        
        #dialog label, #dialog input { display:block; }
        #dialog label { margin-top: 0.5em; }
        #dialog input, #dialog textarea { width: 95%; }
        #tabs { margin: 0px; height: 99%; padding:0px;}
        #tabs li .ui-icon-close { float: left; margin: 0.4em 0.2em 0 0; cursor: pointer; }
        #add_tab { cursor: pointer; }
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

        var tabTitle = $("#tab_title");
		var tabContent = $("#tab_content");
		var tabTemplate = "<li><a href='#{href}'>#{label}</a> <span class='ui-icon ui-icon-close' role='presentation'>Remove Tab</span></li>";
		var tabCounter = 1;
		var idCounter = 1;

		$(function () {
		    var tabs = $("#tabs").tabs();

		    // modal dialog init: custom buttons and a "close" callback reseting the form inside
		    var dialog = $("#dialog").dialog({
		        autoOpen: false,
		        modal: true,
		        buttons: {
		            Confirmar: function () {
		                addTabPesquisa($("#<%= DropDownListAgrupamento.ClientID %>").val());
		                $(this).dialog("close");
		            },
		            Cancelar: function () {
		                $(this).dialog("close");
		            }
		        },
		        close: function () {
		            form[0].reset();
		        }
		    });

		    // addTab form: calls addTab function on submit and closes the dialog
		    var form = dialog.find("form").submit(function (event) {
		        addTabPesquisa();
		        dialog.dialog("close");
		        event.preventDefault();
		    });

		    // close icon: removing the tab on click
		    tabs.delegate("span.ui-icon-close", "click", function () {
		        var panelId = $(this).closest("li").remove().attr("aria-controls");
		        $("#" + panelId).remove();
		        tabCounter--;
		        tabs.tabs("refresh");
		    });

		    tabs.bind("keyup", function (event) {
		        if (event.altKey && event.keyCode === $.ui.keyCode.BACKSPACE) {
		            var panelId = tabs.find(".ui-tabs-active").remove().attr("aria-controls");
		            $("#" + panelId).remove();
		            tabs.tabs("refresh");
		        }
		    });
		});

		function closeTab() {
		    var tabs = $("#tabs");
		    var panelId = tabs.find(".ui-tabs-active").remove().attr("aria-controls");
		    $("#" + panelId).remove();
		    tabCounter--;
		    tabs.tabs("refresh");
		}

        // actual addTab function: adds new tab using the input from the form above
        function addTabPesquisa(agrupamentoNovo) {
            tabCounter++;
            idCounter++;
            var tabs = $("#tabs").tabs();
            var label = tabTitle.val() || agrupamentoNovo,
			    id = "tabs-" + idCounter,
			    li = $(tabTemplate.replace(/#\{href\}/g, "#" + id).replace(/#\{label\}/g, label)),
			    tabContentHtml = tabContent.val() || "Tab " + idCounter + " content.";

            tabs.find(".ui-tabs-nav").append(li);
            tabs.append("<div id='" + id + "' style='height:95%; padding:0px;'><iframe src='PesquisaResultado.aspx?id=" + idCounter + "&filtro=" + mFiltro + "&descricao=" + mDescricao + "&grupo=" + mGrupo + "&agrupamentoAtual=" + mAgrupamentoAtual + "&agrupamentoNovo=" + agrupamentoNovo + "&separaMes=" + mSeparaMes + "&periodo=" + mPeriodo + "&anoIni=" + mAnoIni + "&mesIni=" + mMesIni + "&anoFim=" + mAnoFim + "&mesFim=" + mMesFim + "&parlamentar=" + mParlamentar + "&despesa=" + mDespesa + "&fornecedor=" + mFornecedor + "&uf=" + mUF + "&partido=" + mPartido + "&documento=" + mDocumento + "' frameborder='0' height='99%' width='100%'/></div>");
            tabs.tabs("refresh");
            tabs.tabs("option", "active", tabCounter - 1);
        }

        function addTabAuditoria(tipo, valor) {
            tabCounter++;
            idCounter++;
            var tabs = $("#tabs").tabs();
            var label = tabTitle.val() || "Auditoria",
			    id = "tabs-" + idCounter,
			    li = $(tabTemplate.replace(/#\{href\}/g, "#" + id).replace(/#\{label\}/g, label)),
			    tabContentHtml = tabContent.val() || "Tab " + idCounter + " content.";

            tabs.find(".ui-tabs-nav").append(li);
            if (tipo == "J") {
                tabs.append("<div id='" + id + "' style='height:95%; padding:0px;'><iframe src='AuditoriaFornecedor.aspx?codigo=" + valor + "' frameborder='0' height='99%' width='100%'/></div>");
            }
            else {
                tabs.append("<div id='" + id + "' style='height:95%; padding:0px;'><iframe src='AuditoriaPF.aspx?codigo=" + valor + "' frameborder='0' height='99%' width='100%'/></div>");
            }
            tabs.tabs("refresh");
            tabs.tabs("option", "active", tabCounter - 1);
        }

        function addTabDenuncia(cnpj, nome) {
            tabCounter++;
            idCounter++;
            var tabs = $("#tabs").tabs();
            var label = tabTitle.val() || "Denúncia",
			    id = "tabs-" + idCounter,
			    li = $(tabTemplate.replace(/#\{href\}/g, "#" + id).replace(/#\{label\}/g, label)),
			    tabContentHtml = tabContent.val() || "Tab " + idCounter + " content.";

            tabs.find(".ui-tabs-nav").append(li);
            tabs.append("<div id='" + id + "' style='height:95%; padding:0px;'><iframe src='DenunciarFornecedor.aspx?Cnpj=" + cnpj + "&Nome=" + nome + "' frameborder='0' height='99%' width='100%'/></div>");
            tabs.tabs("refresh");
            tabs.tabs("option", "active", tabCounter - 1);
        }

        function addTabDoacao(cnpj, nome) {
            tabCounter++;
            idCounter++;
            var tabs = $("#tabs").tabs();
            var label = tabTitle.val() || "Doações",
			    id = "tabs-" + idCounter,
			    li = $(tabTemplate.replace(/#\{href\}/g, "#" + id).replace(/#\{label\}/g, label)),
			    tabContentHtml = tabContent.val() || "Tab " + idCounter + " content.";

            tabs.find(".ui-tabs-nav").append(li);
            tabs.append("<div id='" + id + "' style='height:95%; padding:0px;'><iframe src='ReceitasEleicao.aspx?Cnpj=" + cnpj + "&Nome=" + nome + "' frameborder='0' height='99%' width='100%'/></div>");
            tabs.tabs("refresh");
            tabs.tabs("option", "active", tabCounter - 1);
        }

        function addTabDocumentos(cnpj, nome, tipo) {
            tabCounter++;
            idCounter++;
            var tabs = $("#tabs").tabs();
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

            var label = tabTitle.val() || title,
			    id = "tabs-" + idCounter,
			    li = $(tabTemplate.replace(/#\{href\}/g, "#" + id).replace(/#\{label\}/g, label)),
			    tabContentHtml = tabContent.val() || "Tab " + idCounter + " content.";

            tabs.find(".ui-tabs-nav").append(li);
            tabs.append("<div id='" + id + "' style='height:95%; padding:0px;'><iframe src='" + pag + "?Cnpj=" + cnpj + "&Nome=" + nome + "' frameborder='0' height='99%' width='100%'/></div>");
            tabs.tabs("refresh");
            tabs.tabs("option", "active", tabCounter - 1);
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
                //just opens the dialog
                $("#dialog").dialog("open");
            }
            else {
                addTabPesquisa(novoAgrupamento);
            }

        }

        $(function () {
            $("#dialog-message").dialog({
                modal: true,
                autoOpen: false,
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
        });

        function AlertaSemCnpj() {
            $("#dialog-message").dialog("open");
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
    <div id="dialog-message" title="Auditar" style="display: none">
	    <p>
		    Não será possível auditar este fornecedor porque seu CNPJ/CPF não está disponível.
	    </p>
    </div>

    <div id="dialog" title="Nível de Pesquisa">
	    <form runat="server">
		        <table align="center">
                    <tr>
                        <td>
                            <label for="tab_title">Agrupamento:</label></td>
                        <td>
                            <asp:DropDownList ID="DropDownListAgrupamento" runat="server"/>
                        </td>
                    </tr>
                </table>
	    </form>
    </div>

    <div id="tabs">
	    <ul>
		    <li><a href="#tabs-1"><%= Titulo%></a></li>
	    </ul>
	    <div id="tabs-1" style="height:95%; padding:0px;">
		    <iframe src="<%= Pagina%>" frameborder="0" height="100%" width="100%" />
	    </div>
    </div>

</body>
</html>
