<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovoDossie.aspx.cs" Inherits="AuditoriaParlamentar.NovoDossie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="HiddenFieldIdDossie" runat="server" />
    <div class="container-fluid">
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
                <div class="table-responsive">
                    <asp:GridView ID="GridViewResultado" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                        UseAccessibleHeader="true" EmptyDataText="Nenhuma dossiê foi incluída" EmptyDataRowStyle-HorizontalAlign="Center"
                        OnRowDataBound="GridViewResultado_RowDataBound" AllowSorting="True" OnSorting="GridViewResultado_Sorting">
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
        </div>
    </div>
</asp:Content>
