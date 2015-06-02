<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceitasEleicao.aspx.cs" Inherits="AuditoriaParlamentar.ReceitasEleicao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


table {
	font-size: 1em;
}

.fonte
{
    font-family: Tahoma;
    font-size: 10pt;
}

        a:link
        {
            color: #034af3;
        }
        
        .style2
        {
            height: 23px;
        }
        
        .fonte0
        {
            font-family: Verdana;
            font-size: small;
        }
        
        .fonte1
        {
            font-family: Verdana;
            font-weight: bold;
            font-size: small;
        }
            
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="table100">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                    <asp:Label ID="Label1" runat="server" Text="CNPJ:" CssClass="fonte0"></asp:Label>
                            </td>
                            <td>
                    <asp:Label ID="LabelCNPJ" runat="server" Text="Label" Font-Bold="True" 
                                CssClass="fonte1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Label ID="Label3" runat="server" Text="Razão Social:" CssClass="fonte0"></asp:Label>
                            </td>
                            <td>
                    <asp:Label ID="LabelRazaoSocial" runat="server" Text="Label" 
                        CssClass="fonte1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:GridView ID="GridViewResultado" runat="server" CellPadding="4"
                        ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" Width="100%"
                        OnRowDataBound="GridViewResultado_RowDataBound"
                        ShowFooter="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    </form>
</body>
</html>
