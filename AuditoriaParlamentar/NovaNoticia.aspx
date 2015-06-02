<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovaNoticia.aspx.cs" Inherits="AuditoriaParlamentar.NovaNoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css"/>
    <link rel="stylesheet" href="Styles/Master.css"/>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/MaxLength.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //Specifying the Character Count control explicitly
            $("[id*=TextBoxNoticia]").MaxLength(
            {
                MaxLength: 255,
                CharacterCountControl: $('#counterTexto')
            });
            $("[id*=TextBoxLink]").MaxLength(
            {
                MaxLength: 255,
                CharacterCountControl: $('#counterLink')
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:Button ID="ButtonVoltar" runat="server" Text="Voltar" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonVoltar_Click" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="ValidationGroup" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label3" runat="server" Text="Texto da Notícia:"></asp:Label>
            </td>
            <td valign="top">
                            <asp:RequiredFieldValidator ID="TextoValidator" runat="server" 
                                ControlToValidate="TextBoxNoticia" CssClass="failureNotification" 
                                ErrorMessage="Texto não informado." SetFocusOnError="True" 
                                ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
            <td>
                <asp:TextBox ID="TextBoxNoticia" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
                    Width="600px" ValidationGroup="ValidationGroup"></asp:TextBox>
                        </td>
            <td valign="bottom">
                <div id="counterTexto" style="font-size: small; color: #0000FF;">    
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Link da Notícia:"></asp:Label>
            </td>
            <td>
                            &nbsp;</td>
            <td>
                <asp:TextBox ID="TextBoxLink" runat="server" MaxLength="255" Width="600px"></asp:TextBox>
            </td>
            <td>
                <div id="counterLink" style="font-size: small; color: #0000FF;">    
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Imagem PNG (100 x 100):"></asp:Label>
            </td>
            <td>
                            <asp:CustomValidator ID="AnexoValidator" runat="server" 
                                CssClass="failureNotification" 
                                ValidationGroup="DenunciaGroup">*</asp:CustomValidator>
                            </td>
            <td>
                            <asp:FileUpload ID="FileUpload" runat="server" 
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
                        </td>
            <td style="text-align: right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td style="text-align: right">
                <asp:HiddenField ID="HiddenFieldIdNoticia" runat="server" />
                <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Incluir Notícia"
                    ValidationGroup="ValidationGroup" 
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                Font-Size="Small" />
                        </td>
            <td style="text-align: right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
