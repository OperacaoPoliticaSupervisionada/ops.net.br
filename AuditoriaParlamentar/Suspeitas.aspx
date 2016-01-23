<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Suspeitas.aspx.cs" Inherits="AuditoriaParlamentar.Suspeitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container" class="container-fluid">
        <asp:GridView ID="GridView" runat="server" OnRowCommand="GridView_RowCommand"
            UseAccessibleHeader="true" OnRowDataBound="GridView_RowDataBound"
            AllowSorting="True" OnSorting="GridView_Sorting"
            CssClass="table table-hover table-striped" GridLines="None" ShowFooter="True"
            EmptyDataText="Não há suspeitas para exibir!" EmptyDataRowStyle-HorizontalAlign="Center">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="Investigar" CommandName="Select">
                    <ControlStyle Font-Size="X-Small" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Button" Text="Desfazer" CommandName="Desfazer">
                    <ControlStyle Font-Size="X-Small" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
