<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CidadesPendenciaGerenciar.aspx.cs" Inherits="AuditoriaParlamentar.CidadesPendenciaGerenciar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/Site.css">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css" />
    <style type="text/css">
        .ui-button-text-only
        {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table100">
            <tr>
                <td>
                <asp:Button ID="ButtonVoltar" runat="server" Text="Voltar" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonVoltar_Click" />
                </td>
            </tr>
            <tr>
                <td align="center">
                        <asp:GridView ID="GridViewFornecedores" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="Vertical" OnRowCommand="GridViewFornecedores_RowCommand"
                        CssClass="Grid">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField SelectText="Remover" ShowSelectButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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
    </form>
</body>
</html>
