<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Denuncias.aspx.cs" Inherits="AuditoriaParlamentar.Denuncias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <iframe id="frame" src="PesquisaAbas.aspx?op=D" frameborder="0" width="100%" height="100%"></iframe>
    </div>
</asp:Content>
