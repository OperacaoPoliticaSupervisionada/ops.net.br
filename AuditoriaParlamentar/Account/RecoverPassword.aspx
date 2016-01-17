<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="AuditoriaParlamentar.Account.RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <fieldset class="login">
                    <legend>Recuperar Senha</legend>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="LabelMsg" runat="server" ForeColor="#0000CC"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Label ID="Label3" runat="server" Text="Informe o Usuário"></asp:Label>
                            <asp:RequiredFieldValidator ID="UsernameValidator" runat="server"
                                ControlToValidate="TextBoxUser" CssClass="small pull-right text-danger" SetFocusOnError="True"
                                ValidationGroup="ValidationGroup">* Usuário não informado</asp:RequiredFieldValidator>
                            <asp:TextBox ID="TextBoxUser" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click"
                                Text="Recuperar" ValidationGroup="ValidationGroup" CssClass="btn btn-primary" />
                            &nbsp;&nbsp;&nbsp;
                            <a href="#" onclick="history.back();">Voltar</a>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
