<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="AuditoriaParlamentar.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        $(function () {
            var $alert = $('#MainContent_LoginUser_dvFailureText');
            if ($alert.find('span').text().trim())
                $alert.show();
        })
    </script>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <asp:Login ID="LoginUser" runat="server" EnableViewState="false"
                    RenderOuterTable="false"
                    FailureText="Não foi possível conectar. Verifique se os dados estão corretos."
                    OnLoginError="LoginUser_LoginError" OnLoggedIn="LoginUser_LoggedIn"
                    RememberMeSet="True">
                    <TextBoxStyle CssClass="form-control" />
                    <LoginButtonStyle CssClass="btn btn-lg btn-primary btn-block" />
                    <CheckBoxStyle CssClass="form-control" />
                    <LayoutTemplate>
                        <fieldset class="login">
                            <legend>Entrar</legend>
                            <div id="dvFailureText" runat="server" class="alert alert-danger" role="alert" style="display: none;">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><i aria-hidden="true">&times;</i></button>
                                <span>
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal></span>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário</asp:Label>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        CssClass="small pull-right text-danger" ValidationGroup="LoginUserValidationGroup">* É necessário informar o nome de usuário</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" autofocus="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha</asp:Label>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        CssClass="small pull-right text-danger" ValidationGroup="LoginUserValidationGroup">* É necessário informar a senha</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="RememberMe" runat="server" />
                                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Mantenha-me conectado</asp:Label>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar"
                            CssClass="btn btn-primary" ValidationGroup="LoginUserValidationGroup" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="RecoverHyperLink" runat="server" EnableViewState="false" NavigateUrl="RecoverPassword.aspx">Esqueceu sua senha?</asp:HyperLink>
                    </LayoutTemplate>
                </asp:Login>
                <br />
                <br />
                <p>
                    <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false" CssClass="btn btn-info">Crie uma conta caso ainda não tenha.</asp:HyperLink>
                </p>
                <p>
                    
                </p>
            </div>
        </div>
    </div>
</asp:Content>
