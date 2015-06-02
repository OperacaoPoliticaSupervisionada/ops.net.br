<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AuditoriaParlamentar.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="margin: 10px">
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
                        <h2>
                            Nova Conta
                        </h2>
                        <p>
                            Utilize o formulário abaixo para criar sua conta.
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
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                CssClass="failureNotification" ErrorMessage="É necessário informa um nome de usuário."
                                                ToolTip="É necessário informa um nome de usuário." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                CssClass="failureNotification" ErrorMessage="É necessário informa um e-mail."
                                                ToolTip="É necessário informa um e-mail." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                CssClass="failureNotification" ErrorMessage="É necessário informar uma senha."
                                                ToolTip="É necessário informar uma senha." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirmar Senha:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                                Display="Dynamic" ErrorMessage="É necessário informar a confirmação da senha."
                                                ID="ConfirmPasswordRequired" runat="server" ToolTip="É necessário informar a confirmação da senha."
                                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                                                ErrorMessage="A senha e a confirmação devem ser iguais." ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" AssociatedControlID="DropDownListUF">UF:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DropDownListUF" runat="server" Width="320px">
                                            </asp:DropDownList>
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
                                        <td>
                                            <asp:TextBox ID="TextBoxCidade" runat="server" CssClass="textEntry"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CidadeRequired" runat="server" ControlToValidate="TextBoxCidade"
                                                CssClass="failureNotification" ErrorMessage="É necessário informar a cidade."
                                                ToolTip="É necessário informar a cidade." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="CheckBoxMostraEmail" runat="server" Text="Divulgar meu e-mail para que outros membros solicitem ajuda nas investigações"
                                                Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <p class="submitButton">
                                <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Criar conta"
                                    ValidationGroup="RegisterUserValidationGroup" />
                            </p>
                        </div>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="center">
                                    Concluído
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Sua conta foi criada com sucesso.
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                        Text="Continar" ValidationGroup="RegisterUser" />
                                </td>
                            </tr>
                        </table>
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
