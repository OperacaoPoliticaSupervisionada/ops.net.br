<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Suspeitas.aspx.cs" Inherits="AuditoriaParlamentar.Suspeitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        body
        {
            background: #b6b7bc;
            font-size: .80em;
            font-family: Verdana;
            margin: 0px;
            padding: 0px;
            color: #696969;
            height: auto;
        }
        .style2
        {
            text-align: center;
        }
        
        .Grid
        {
            font-size: small;
            font-family: Verdana;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table100">
        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="style2">
                <center>
                    <asp:GridView ID="GridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Style="text-align: left" CssClass="Grid" OnRowDataBound="GridView_RowDataBound"
                        OnRowCommand="GridView_RowCommand" Font-Size="X-Small" AllowSorting="True" 
                        OnSorting="GridView_Sorting" PageSize="100">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:ButtonField ButtonType="Button" Text="Investigar" CommandName="Select">
                                <ControlStyle Font-Size="X-Small" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Button" Text="Desfazer" CommandName="Desfazer">
                                <ControlStyle Font-Size="X-Small" />
                            </asp:ButtonField>
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
</asp:Content>
