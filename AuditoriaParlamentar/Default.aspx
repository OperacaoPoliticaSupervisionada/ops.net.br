<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AuditoriaParlamentar.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="min-width: 500px">
        <div class="intro-header">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="intro-message">
                            <h1>Operação Política Supervisionada</h1>
                            <h3>Além do Projeto: Uma Solução Real</h3>
                            <hr class="intro-divider" />
                            <ul class="list-inline">
                                <li>
                                    <a href="http://luciobig.com.br/o-que-e-ops/" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-heart"></i>&nbsp;Conheça</a>
                                </li>
                                <li>
                                    <a href="#" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-eye-open"></i>&nbsp;Fiscalize</a>
                                </li>
                                <li>
                                    <a href="http://luciobig.com.br/pagina-para-doacoes_16-html/" class="btn btn-default btn-lg"><i class="glyphicon glyphicon-usd"></i>&nbsp;Doe</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container banner1">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h2>A OPS Já Economizou Mais de <b>R$5,5 MILHÕES</b> aos Cofres Públicos</h2>
                </div>
            </div>
            <div class="row text-center">
                <div class="col-lg-12">
                    <asp:Repeater runat="server" ID="rptResumoAuditoria">
                        <ItemTemplate>
                            <div class="col-xs-4 text-center">
                                <h3><%# Eval("Resultado") %></h3>
                                <h4><%# Eval("Nome") %></h4>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <br />
        </div>
        <div class="content-section-a">
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <h2>A Lista do 20: O primeiro dossiê da OPS</h2>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <br />
                        <a href="<%# ResolveClientUrl("~/") %>Dossies.aspx" class="btn btn-default btn-lg">Visualizar o Dossiê&nbsp;<i class="glyphicon glyphicon-menu-right"></i></a>
                    </div>
                </div>
            </div>
        </div>
        <div class="content-section-b">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <h2 class="section-heading text-center">Notícias e Artigos</h2>
                    </div>
                    <asp:Repeater runat="server" ID="rptNoticia">
                        <ItemTemplate>
                            <div class="col-lg-3 col-sm-4 col-xs-12" style="margin-top: 10px;">
                                <a class="list-group-item" href='<%# DataBinder.Eval(Container.DataItem, "LinkNoticia") %>' target="_blank" runat="server">
                                    <p class="text-center">
                                        <img class="img-thumbnail" src='<%# ResolveClientUrl("~/") %>Noticias/<%# DataBinder.Eval(Container.DataItem, "IdNoticia") %>.png' alt="" />
                                    </p>
                                    <p class="text-justify" style="min-height: 150px"><%# DataBinder.Eval(Container.DataItem, "TextoNoticia") %></p>
                                    <p class="text-muted small text-right"><%# DataBinder.Eval(Container.DataItem, "DataNoticia", "{0:dd/MM/yyyy HH:mm}") %></p>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <a href="~/Noticias.aspx" runat="server" class="btn btn-default pull-right">Ver todas&nbsp; <i class="glyphicon glyphicon-menu-right"></i></a>
                    </div>
                </div>
            </div>
        </div>
        <footer>
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <p style="margin: 15px 0 0;" class="text-muted text-center">O controle social é indispensável para combatermos a corrupção em nosso país.</p>
                    </div>
                </div>
            </div>
        </footer>
    </div>
</asp:Content>
