<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="AuditoriaParlamentar.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            var $alert = $('#MainContent_ChangeUserPassword_ChangePasswordContainerID_dvFailureText');
            if ($alert.find('span').text().trim())
                $alert.show();
        })
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <h2>Alterar Senha
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
                    <div id="dvFailureText" runat="server" class="alert alert-danger" role="alert" style="display: none;">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><i aria-hidden="true">&times;</i></button>
                        <span><asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal></span>
                    </div>
                    <fieldset class="login">
                        <legend>Informações da Conta</legend>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Senha antiga:</asp:Label>
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                    CssClass="small pull-right text-danger" ErrorMessage="" ToolTip="É necessário informar a senha antiga."
                                    ValidationGroup="ChangeUserPasswordValidationGroup">* É necessário informar a senha antiga.</asp:RequiredFieldValidator>
                                <asp:TextBox ID="CurrentPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nova senha:</asp:Label>
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                    CssClass="small pull-right text-danger" ErrorMessage="" ToolTip="É necessário informar a nova senha."
                                    ValidationGroup="ChangeUserPasswordValidationGroup">* É necessário informar a nova senha.</asp:RequiredFieldValidator>
                                <asp:TextBox ID="NewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar nova senha:</asp:Label>
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                    CssClass="small pull-right text-danger" Display="Dynamic" ErrorMessage=""
                                    ToolTip="É necessário informar a confirmação da senha."
                                    ValidationGroup="ChangeUserPasswordValidationGroup">* Informe a confirmação da senha.</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                    CssClass="small pull-right text-danger" Display="Dynamic" ErrorMessage=""
                                    ValidationGroup="ChangeUserPasswordValidationGroup">* A nova senha e a confirmação devem ser iguais.</asp:CompareValidator>
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Alterar"
                                    ValidationGroup="ChangeUserPasswordValidationGroup" CssClass="btn btn-success" />
                                &nbsp;&nbsp;&nbsp;
                              <a href="#" onclick="history.back();">Voltar</a>
                            </div>
                        </div>
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </div>
    </div>
</asp:Content>
