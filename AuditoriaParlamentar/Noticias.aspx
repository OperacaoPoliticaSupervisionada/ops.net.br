<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="AuditoriaParlamentar.Noticias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <% if (plhInserir.Visible)
        { %>
    <script type="text/javascript">
        function editar(id) {
            window.location.href = '<%= ResolveClientUrl("~/NovaNoticia.aspx?IdNoticia=") %>' + id.toString();
        }
    </script>
    <%} %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <asp:PlaceHolder runat="server" ID="plhInfo" Visible="false">
                    <asp:Label runat="server" ID="lblInfo" />
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="plhInserir">
                    <a class="btn btn-success pull-right" style="margin-top: 25px;" href="NovaNoticia.aspx">Nova Notícia</a>
                </asp:PlaceHolder>
                <h2 class="section-heading text-center">Notícias e Artigos</h2>
            </div>
        </div>
        <div class="row">
            <asp:Repeater runat="server" ID="rptNoticia">
                <ItemTemplate>
                    <div class="col-lg-3 col-sm-4 col-xs-12" style="margin-top: 10px;">
                        <a class="list-group-item" href='<%# DataBinder.Eval(Container.DataItem, "LinkNoticia") %>' target="_blank" runat="server">
                            <p class="text-center">
                                <img class="img-thumbnail" src='<%# ResolveClientUrl("~/") %>Noticias/<%# DataBinder.Eval(Container.DataItem, "IdNoticia") %>.png' alt="" />
                            </p>
                            <p class="text-justify" style="min-height: 150px"><%# DataBinder.Eval(Container.DataItem, "TextoNoticia") %></p>
                            <p class="text-muted small text-right"><%# DataBinder.Eval(Container.DataItem, "UserName") %> - <%# DataBinder.Eval(Container.DataItem, "DataNoticia", "{0:dd/MM/yyyy HH:mm}") %></p>
                            <% if (plhInserir.Visible)
                                { %>
                            <input type="button" class="btn btn-success pull-right" onclick='editar(<%# DataBinder.Eval(Container.DataItem, "IdNoticia") %>); return false;' value="Editar"></input>
                            <div class="clearfix"></div>
                            <%} %>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </div>
</asp:Content>
