<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisaoGrid.aspx.cs" Inherits="AuditoriaParlamentar.RevisaoGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/Site.css">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css" />
    <style type="text/css">
        a:link
        {
            color: #034af3;
        }
        .watermark
        {
            background-image: url(figuras/logo_opaca.png);
            background-repeat: no-repeat;
            position: fixed;
            bottom: 5px;
            right: 5px;
            width: 600px;
            height: 365px;
            z-index: -1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="watermark"></div>
    <div>
        <table class="table100">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxNaoLidas" runat="server" Checked="True" 
                                    Text="Mensagens não Lidas" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxAguardando" runat="server" Checked="True" Text="Aguardando Revisão" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxPendenteInformacao" runat="server" 
                                    Text="Pendente Informação" Checked="True" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxDuvidoso" runat="server" Text="Duvidoso" 
                                    Checked="True" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxDossie" runat="server" Text="Dossiê" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxRepetido" runat="server" Text="Repetido" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxNaoProcede" runat="server" Text="Não Procede" />
                            </td>
                            <td>
                                <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Filtrar"
                                    ValidationGroup="DenunciaGroup" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Size="X-Small" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="GridViewRevisao" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="Vertical" OnRowCommand="GridViewDenuncias_RowCommand" OnRowDataBound="GridViewDenuncias_RowDataBound"
                        CssClass="Grid">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField SelectText="Detalhes" ShowSelectButton="True" />
                            <asp:ImageField DataImageUrlField="nova_msg" 
                                DataImageUrlFormatString="~/Figuras/{0}">
                            </asp:ImageField>
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
