<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeBehind="PesquisaResultado.aspx.cs"
    Inherits="AuditoriaParlamentar.PesquisaResultado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/Site.css">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <style type="text/css">
        a:link, a:visited
        {
            color: #034af3;
        }
        
        .style2
        {
            width: 100%;
        }
    </style>
    <script>
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
    <form id="form1" runat="server">
    <div style="padding: 3px">
        <div style="padding-bottom: 5px; padding-top: 5px;">
            <asp:Label ID="LabelFiltro" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"
                Font-Strikeout="False" Text="Label" ForeColor="#0099FF" ViewStateMode="Enabled"></asp:Label>
        </div>
        <table cellpadding="0" cellspacing="0" class="style2">
            <tr>
                <td>
                    <center>
                        <asp:Label ID="LabelMaximo" runat="server" Text="O resultado está limitado a 1.000 registros para evitar sobrecarga."
                            Font-Bold="True" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label></center>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridViewResultado" runat="server" AllowSorting="True" CellPadding="4"
                        ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" Width="100%"
                        OnRowDataBound="GridViewResultado_RowDataBound" OnSorting="GridViewResultado_Sorting"
                        ShowFooter="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <FooterTemplate>
                                    <asp:Label ID="LabelTotal" runat="server" Text="Total Geral:"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <input type="button" class="fonte" onclick="NovoNivel('<%# Eval("codigo") %>','<%# Eval("[1]") %>');"
                                        value="Detalhar" />
                                    <asp:Button ID="ButtonAuditar" runat="server" Text="Auditar" CssClass="fonte" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" CssClass="fonte" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                            CssClass="fonte" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" CssClass="fonte" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
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
    </form>
</body>
</html>
