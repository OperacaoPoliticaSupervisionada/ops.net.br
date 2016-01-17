<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AuditoriaParlamentar.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            var $alert = $('#MainContent_RegisterUser_CreateUserStepContainer_dvErrorMessage');
            if ($alert.find('span').text().trim())
                $alert.show();
        })
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container">

        <asp:CreateUserWizard ID="RegisterUser" runat="server" OnCreatedUser="RegisterUser_CreatedUser"
            BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" Font-Size="0.8em" DuplicateEmailErrorMessage="O e-mail informado já está em uso. Escolha um e-mail diferente."
            DuplicateUserNameErrorMessage="O usuário informado já está em uso." InvalidEmailErrorMessage="Informe um endereço de e-mail válido."
            InvalidPasswordErrorMessage="A senha deverá ter no mínimo {0} caracteres." UnknownErrorMessage="Ocorreu um erro ao criar sua conta. Tente novamente mais tarde.">
            <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
                ForeColor="White" HorizontalAlign="Center" />
            <LayoutTemplate>
                <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <WizardSteps>
                <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <legend>Nova Conta</legend>
                            <div id="dvErrorMessage" runat="server" class="alert alert-danger" role="alert" style="display: none;">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><i aria-hidden="true">&times;</i></button>
                                <span><asp:Literal ID="ErrorMessage" runat="server" EnableViewState="false"></asp:Literal></span>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <p class="text-muted">
                                        Utilize o formulário abaixo para criar sua conta.
                                    </p>
                                    <br />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-xs-12">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário</asp:Label>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        CssClass="small pull-right text-danger" ValidationGroup="RegisterUserValidationGroup">* É necessário informa um nome de usuário</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" autofocus="true"></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-xs-12">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        CssClass="small pull-right text-danger" ValidationGroup="RegisterUserValidationGroup">* É necessário informa um e-mail</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 col-xs-12">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha</asp:Label>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        CssClass="small pull-right text-danger" ValidationGroup="RegisterUserValidationGroup">* É necessário informar uma senha</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-md-6 col-xs-12">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirmar Senha</asp:Label>
                                    <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="small pull-right text-danger"
                                        Display="Dynamic" ID="ConfirmPasswordRequired" runat="server"
                                        ValidationGroup="RegisterUserValidationGroup">* É necessário informar a confirmação da senha</asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" CssClass="pull-right" Display="Dynamic"
                                        ValidationGroup="RegisterUserValidationGroup">* A senha e a confirmação devem ser iguais</asp:CompareValidator>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-xs-12">
                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownListUF">UF</asp:Label>
                                    <asp:RequiredFieldValidator ID="UFRequired" runat="server" ControlToValidate="DropDownListUF"
                                        CssClass="small pull-right text-danger" ValidationGroup="RegisterUserValidationGroup">* É necessário informar a UF</asp:RequiredFieldValidator>
                                    <asp:DropDownList ID="DropDownListUF" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6 col-xs-12">
                                    <asp:RequiredFieldValidator ID="CidadeRequired" runat="server" ControlToValidate="TextBoxCidade"
                                        CssClass="small pull-right text-danger" ValidationGroup="RegisterUserValidationGroup">* É necessário informar a cidade</asp:RequiredFieldValidator>
                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="TextBoxCidade">Cidade</asp:Label>
                                    <asp:TextBox ID="TextBoxCidade" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="CheckBoxMostraEmail" runat="server" Checked="True" />
                                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="CheckBoxMostraEmail">
                                                Divulgar meu e-mail para que outros membros solicitem ajuda nas investigações</asp:Label>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Criar conta"
                                        ValidationGroup="RegisterUserValidationGroup" CssClass="btn btn-primary" />
                                </div>
                            </div>
                            <br />
                            <p>
                                <a href="#" onclick="history.back();">Voltar</a>
                            </p>
                        </fieldset>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-12">
                                <h3 class="text-center text-success">Concluído</h3>
                                <h4 class="text-center text-success">Sua conta foi criada com sucesso.</h4>
                            </div>
                            <div class="col-md-12">
                                <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                    Text="Continar" ValidationGroup="RegisterUser" CssClass="btn btn-success btn-block" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
            <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
            <StepStyle BorderWidth="0px" />
        </asp:CreateUserWizard>
    </div>
</asp:Content>
