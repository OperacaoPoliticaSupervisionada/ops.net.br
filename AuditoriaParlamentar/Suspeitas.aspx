<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Suspeitas.aspx.cs" Inherits="AuditoriaParlamentar.Suspeitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        Style="text-align: left" CssClass="Grid" OnRowDataBound="GridView_RowDataBound"
        OnRowCommand="GridView_RowCommand" Font-Size="X-Small" AllowSorting="True"
        OnSorting="GridView_Sorting" PageSize="100" Width="100%">
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
</asp:Content>
