<%@ Page Title="OPS - Operação Política Supervisionada" ViewStateMode="Disabled" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="PesquisaInicio.aspx.cs" Inherits="AuditoriaParlamentar.PesquisaInicio" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="~/assets/css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="container" class="container-fluid">
        <iframe id="frame" src="PesquisaAbas.aspx" frameborder="0"></iframe>
    </div>
</asp:Content>
