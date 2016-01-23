<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="AuditoriaParlamentar.Relatorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container" class="container-fluid" style="position: absolute; width: 100%; top: 61px; padding-bottom: 65px;">
        <iframe src="PesquisaAbas.aspx?op=A" frameborder="0" width="100%" height="100%"></iframe>
    </div>
</asp:Content>
