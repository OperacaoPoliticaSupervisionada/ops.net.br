<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelParlamentarFornecedor.aspx.cs"
    Inherits="AuditoriaParlamentar.RelParlamentarFornecedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/Site.css">
    <style type="text/css">
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table class="table100">
                <tr>
                    <td>
                        <center>
                            <asp:Label ID="Label1" runat="server" Text="Lista de Parlamentares associados com Fornecedores denunciados (denúncia dossiê)."
                                CssClass="fonte0"></asp:Label>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td>
                        <center>
                            <asp:GridView ID="GridViewDenuncias" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None" Style="text-align: left" CssClass="Grid" Width="800px" AllowSorting="True"
                                OnRowDataBound="GridViewDenuncias_RowDataBound" OnSorting="GridViewDenuncias_Sorting"
                                ShowFooter="True">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    </div>
    </form>
</body>
</html>
