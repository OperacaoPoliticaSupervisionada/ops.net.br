<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="AuditoriaParlamentar.Account.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table100">
        <tr>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelMsg" runat="server" ForeColor="#0000CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="ValidationGroup" />
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Informe o Usuário:"></asp:Label>
                            <asp:RequiredFieldValidator ID="UsernameValidator" runat="server" 
                                ControlToValidate="TextBoxUser" CssClass="failureNotification" 
                                ErrorMessage="Usuário não informado." SetFocusOnError="True" 
                                ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxUser" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="ButtonEnviar" runat="server" onclick="ButtonEnviar_Click" 
                                Text="Recuperar" ValidationGroup="ValidationGroup" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
