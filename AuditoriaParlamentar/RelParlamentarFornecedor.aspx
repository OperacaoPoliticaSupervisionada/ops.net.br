<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelParlamentarFornecedor.aspx.cs"
    Inherits="AuditoriaParlamentar.RelParlamentarFornecedor" MasterPageFile="~/Site.Master" Title="OPS - Relatório Parlamentar x Fornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <p class="text-center">Lista de Parlamentares associados com Fornecedores denunciados (denúncia dossiê).</p>
        <br />
        <asp:GridView ID="GridViewDenuncias" runat="server" AllowSorting="True" UseAccessibleHeader="true" OnRowDataBound="GridViewDenuncias_RowDataBound"
            CssClass="table table-hover table-striped" GridLines="None" ShowFooter="True" OnSorting="GridViewDenuncias_Sorting">
            <RowStyle CssClass="cursor-pointer" />
        </asp:GridView>
    </div>
</asp:Content>
