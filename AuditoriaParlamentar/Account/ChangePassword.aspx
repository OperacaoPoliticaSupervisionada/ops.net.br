<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="AuditoriaParlamentar.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="margin: 10px">
        <h2>
            Alterar Senha
        </h2>
        <p>
            Utilize o formulário abaixo para alterar sua senha.
        </p>
        <p>
            A senha deverá ter no mínimo <%= Membership.MinRequiredPasswordLength %> caracteres.
        </p>
        <asp:ChangePassword ID="ChangeUserPassword" runat="server" 
            CancelDestinationPageUrl="~/" EnableViewState="false" RenderOuterTable="false" 
             SuccessPageUrl="ChangePasswordSuccess.aspx" 
            ChangePasswordFailureText="Não foi possível alterar. Verifique se a senha atual está correta.">
            <ChangePasswordTemplate>
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification" 
                     ValidationGroup="ChangeUserPasswordValidationGroup"/>
                <div class="accountInfo">
                    <fieldset class="changePassword">
                        <legend>Informações da Conta</legend>
                        <p>
                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Senha antiga:</asp:Label>
                            <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                                 CssClass="failureNotification" ErrorMessage="É necessário informar a senha antiga." ToolTip="É necessário informar a senha antiga." 
                                 ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nova senha:</asp:Label>
                            <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                                 CssClass="failureNotification" ErrorMessage="É necessário informar a nova senha." ToolTip="É necessário informar a nova senha." 
                                 ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar nova senha:</asp:Label>
                            <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                                 CssClass="failureNotification" Display="Dynamic" ErrorMessage="É necessário informar a confirmação da senha."
                                 ToolTip="É necessário informar a confirmação da senha." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                 CssClass="failureNotification" Display="Dynamic" ErrorMessage="A nova senha e a confirmação devem ser iguais."
                                 ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                        </p>
                    </fieldset>
                    <p class="submitButton">
                        <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Alterar" 
                             ValidationGroup="ChangeUserPasswordValidationGroup"/>
                        <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"/>
                    </p>
                </div>
            </ChangePasswordTemplate>
        </asp:ChangePassword>
    </div>
</asp:Content>
