<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeBehind="PesquisaResultado.aspx.cs"
    Inherits="AuditoriaParlamentar.PesquisaResultado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/assets/css/bootstrap-select.min.css" rel="stylesheet" />
    <link href="~/assets/css/style.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function NovoNivel(value, descricao) {
            var desc = $("#<%= LabelFiltro.ClientID %>").text() + " > " + $("#<%= HiddenFieldAgrupamento.ClientID %>").val().substring(4).toUpperCase() + ": " + descricao;

            window.parent.TabPesquisa(
                value,
                desc,
                $("#<%= HiddenFieldGrupo.ClientID %>").val(),
                $("#<%= HiddenFieldAgrupamento.ClientID %>").val(),
                $("#<%= HiddenFieldSeparaMes.ClientID %>").val(),
                $("#<%= HiddenFieldPeriodo.ClientID %>").val(),
                $("#<%= HiddenFieldAnoIni.ClientID %>").val(),
                $("#<%= HiddenFieldMesIni.ClientID %>").val(),
                $("#<%= HiddenFieldAnoFim.ClientID %>").val(),
                $("#<%= HiddenFieldMesFim.ClientID %>").val(),
                $("#<%= HiddenFieldParlamentar.ClientID %>").val(),
                $("#<%= HiddenFieldDespesa.ClientID %>").val(),
                $("#<%= HiddenFieldFornecedor.ClientID %>").val(),
                $("#<%= HiddenFieldUF.ClientID %>").val(),
                $("#<%= HiddenFieldPartido.ClientID %>").val(),
                $("#<%= HiddenFieldDocumento.ClientID %>").val(),
                '');
        }

        function UpdateGridView(row, column, value) {
            var grd = document.getElementById('<%= GridViewResultado.ClientID %>');
            grd.rows[row].cells[column].textContent = value;
        }
    </script>
</head>
<body>
    <form id="form_auditoria" runat="server">
        <div id="conteudo" class="container-fluid" style="overflow:auto">
            <fieldset>
                <legend runat="server" id="LabelFiltro" viewstatemode="Enabled"></legend>
                <div class="text-center">
                    <button class="btn btn-default btn-sm" onclick="__doPostBack('ButtonExportar_Click', '');">Exportar Consulta em CSV</button>
                </div>
                <div id="LabelMaximo" runat="server" class="alert alert-warning" visible="false">
                    O resultado está limitado a 1.000 registros para evitar sobrecarga.
                </div>
                <asp:GridView ID="GridViewResultado" runat="server" AllowSorting="True" UseAccessibleHeader="true"
                    CssClass="table table-hover table-striped" GridLines="None"
                    OnRowDataBound="GridViewResultado_RowDataBound" OnSorting="GridViewResultado_Sorting"
                    ShowFooter="True">
                    <Columns>
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:Label ID="LabelTotal" runat="server" Text="Total Geral:"></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <input type="button" class="btn btn-primary btn-sm" onclick="NovoNivel('<%# Eval("codigo") %>    ','<%# Eval("[1]") %>    ');" value="Detalhar" />
                                <asp:Button ID="ButtonAuditar" runat="server" Text="Auditar" CssClass="btn btn-success btn-sm" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="cursor-pointer" />
                </asp:GridView>
            </fieldset>
        </div>
        <asp:HiddenField ID="HiddenFieldGrupo" runat="server" />
        <asp:HiddenField ID="HiddenFieldAgrupamento" runat="server" />
        <asp:HiddenField ID="HiddenFieldSeparaMes" runat="server" />
        <asp:HiddenField ID="HiddenFieldPeriodo" runat="server" />
        <asp:HiddenField ID="HiddenFieldAnoIni" runat="server" />
        <asp:HiddenField ID="HiddenFieldMesIni" runat="server" />
        <asp:HiddenField ID="HiddenFieldAnoFim" runat="server" />
        <asp:HiddenField ID="HiddenFieldMesFim" runat="server" />
        <asp:HiddenField ID="HiddenFieldParlamentar" runat="server" />
        <asp:HiddenField ID="HiddenFieldDespesa" runat="server" />
        <asp:HiddenField ID="HiddenFieldFornecedor" runat="server" />
        <asp:HiddenField ID="HiddenFieldUF" runat="server" />
        <asp:HiddenField ID="HiddenFieldPartido" runat="server" />
        <asp:HiddenField ID="HiddenFieldDocumento" runat="server" />
        <asp:HiddenField ID="ChavePesquisa" runat="server" />
    </form>
</body>
</html>
