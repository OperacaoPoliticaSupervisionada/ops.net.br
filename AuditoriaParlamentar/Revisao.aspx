﻿<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Revisao.aspx.cs" Inherits="AuditoriaParlamentar.Revisao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 100%; margin-right: 5px; margin-left: 5px;">
        <iframe src="PesquisaAbas.aspx?op=R" frameborder="0" width="100%" height="100%"></iframe> 
    </div>
</asp:Content>
