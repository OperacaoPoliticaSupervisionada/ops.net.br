<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="UpdateAccount.aspx.cs" Inherits="AuditoriaParlamentar.Account.UpdateAccount" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2 {
            margin-left: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <h2>Alterar Conta
            </h2>
            <p>
                Utilize o formulário abaixo para alterar os dados da sua conta.
            </p>
            <p>
                <a href="ChangePassword.aspx">Clique aqui para alterar sua senha.</a>
            </p>

            <fieldset>
                <legend>Informações da Conta</legend>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownListUF">UF:</asp:Label>
                        <asp:RequiredFieldValidator ID="UFRequired" runat="server" ControlToValidate="DropDownListUF"
                            CssClass="failureNotification" ErrorMessage="" ToolTip="É necessário informar UF."
                            ValidationGroup="RegisterUserValidationGroup">* É necessário informar a UF.</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="DropDownListUF" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxCidade">Cidade:</asp:Label>
                        <asp:RequiredFieldValidator ID="CidadeRequired" runat="server" ControlToValidate="TextBoxCidade"
                            CssClass="small pull-right text-danger"
                            ToolTip="É necessário informar a cidade." ValidationGroup="RegisterUserValidationGroup">* É necessário informar a cidade.</asp:RequiredFieldValidator>
                        <asp:TextBox ID="TextBoxCidade" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="CheckBoxMostraEmail" runat="server" Checked="True" />
                                Divulgar meu e-mail para que outros membros solicitem ajuda nas investigações
                            </label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Button ID="UpdateUserButton" runat="server" Text="Alterar" ValidationGroup="RegisterUserValidationGroup"
                            OnClick="UpdateUserButton_Click" CssClass="btn btn-success" />
                        &nbsp;&nbsp;&nbsp;
                        <a href="#" onclick="history.back();">Voltar</a>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
