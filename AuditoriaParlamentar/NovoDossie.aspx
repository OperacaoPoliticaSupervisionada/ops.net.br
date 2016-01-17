<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovoDossie.aspx.cs" Inherits="AuditoriaParlamentar.NovoDossie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/assets/css/style.css" rel="stylesheet" />
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/bootstrap.min.js"></script>
    <style type="text/css">
        .style2 { color: #333333; border-collapse: collapse; text-align: left; font-size: 1em; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="HiddenFieldIdDossie" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="ButtonVoltar" runat="server" Text="Voltar" CssClass="btn btn-default btn-sm" OnClick="ButtonVoltar_Click" />
            <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Salvar Dossiê" ValidationGroup="ValidationGroup" CssClass="btn btn-success btn-sm" />
            <asp:Button ID="ButtonExcluir" runat="server" Text="Excluir Dossiê" CssClass="btn btn-danger btn-sm" OnClick="ButtonExcluir_Click" />
        </div>
    </div>
    <div class="row">
        <br />
        <div class="col-md-12">
            <div class="form-group">
                <label>Nome do Dossiê:</label>
                <asp:TextBox ID="TextBoxNome" runat="server" MaxLength="255" CssClass="form-control">Dossiê X</asp:TextBox>
                <asp:RequiredFieldValidator ID="TextoValidator" runat="server" ControlToValidate="TextBoxNome" CssClass="failureNotification"
                    SetFocusOnError="True" ValidationGroup="ValidationGroup">Nome não informado.</asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
             <label>Parlamentares:</label>
            <asp:GridView ID="GridViewResultado" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                UseAccessibleHeader="true" EmptyDataText="Nenhuma dossiê foi incluída" EmptyDataRowStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:TemplateField HeaderText="Selecionar">
                        <ItemTemplate>
                            <center><asp:CheckBox ID="CheckBoxSelecionar" runat="server" /></center>
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
