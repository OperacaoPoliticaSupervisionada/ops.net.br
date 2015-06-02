<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FornecedorParlamentares.aspx.cs"
    Inherits="AuditoriaParlamentar.FornecedorParlamentares" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css">
    <link rel="stylesheet" href="Styles/Site.css">
</head>
<body>
    <form id="form1" runat="server">
    <table class="table100">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td width="100px">
                            <asp:Label ID="Label9" runat="server" Text="CNPJ/CPF:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelCNPJ" runat="server" Text="Label" Font-Bold="True" CssClass="fonte1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Razão Social:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelNome" runat="server" Text="Label" Font-Bold="True" CssClass="fonte1"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:GridView ID="GridViewResultado" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None" Style="text-align: left" CssClass="Grid" OnRowDataBound="GridViewResultado_RowDataBound"
                        ShowFooter="True" AllowSorting="True" OnSorting="GridViewResultado_Sorting">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="url" Target="_blank" Text="Site" />
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
                </center>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
