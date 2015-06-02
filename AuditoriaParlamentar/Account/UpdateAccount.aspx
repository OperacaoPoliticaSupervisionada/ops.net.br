<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="UpdateAccount.aspx.cs" Inherits="AuditoriaParlamentar.Account.UpdateAccount" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            margin-left: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="margin: 10px">
        <h2>
            Alterar Conta
        </h2>
        <p>
            Utilize o formulário abaixo para alterar os dados da sua conta.
        </p>
        <p>
            <a href="ChangePassword.aspx">Clique aqui para alterar sua senha.</a>
        </p>
        <span class="failureNotification">
            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
        </span>
        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification"
            ValidationGroup="RegisterUserValidationGroup" />
        <div class="accountInfo">
            <fieldset>
                <legend>Informações da Conta</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownListUF">UF:</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownListUF" runat="server" Width="320px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="UFRequired" runat="server" ControlToValidate="DropDownListUF"
                                CssClass="failureNotification" ErrorMessage="É necessário informar a UF." ToolTip="É necessário informar UF."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxCidade">Cidade:</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:TextBox ID="TextBoxCidade" runat="server" CssClass="textEntry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator ID="CidadeRequired" runat="server" ControlToValidate="TextBoxCidade"
                                CssClass="failureNotification" ErrorMessage="É necessário informar a cidade."
                                ToolTip="É necessário informar a cidade." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckBoxMostraEmail" runat="server" 
                                Text="Divulgar meu e-mail para que outros membros solicitem ajuda nas investigações" 
                                Checked="True" />
                        </td>
                    </tr>
                </table>
                <p>
                    &nbsp;</p>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="UpdateUserButton" runat="server" Text="Alterar" ValidationGroup="RegisterUserValidationGroup"
                    OnClick="UpdateUserButton_Click" />
            </p>
        </div>
    </div>
</asp:Content>
