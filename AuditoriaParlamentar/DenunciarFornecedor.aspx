<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DenunciarFornecedor.aspx.cs" Inherits="AuditoriaParlamentar.DenunciarFornecedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/Site.css"/>
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css"/>
    <style type="text/css">
        .fonte0
        {
            font-family: Verdana;
            font-size: small;
        }
        
        .fonte1
        {
            font-family: Verdana;
            font-weight: bold;
            font-size: small;
        }
            
        .style3
        {
            height: 23px;
        }
        .style4
        {
            height: 24px;
        }
    </style>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
    <table class="table100">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="DenunciaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="DenunciaGroup"/>
                </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td>
                    <asp:Label ID="Label1" runat="server" Text="CNPJ/CPF:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                    <asp:Label ID="LabelCNPJ" runat="server" Text="Label" Font-Bold="True" 
                                CssClass="fonte1"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                    <asp:Label ID="Label3" runat="server" Text="Razão Social:" CssClass="fonte0"></asp:Label>
                            </td>
                        <td>
                    <asp:Label ID="LabelRazaoSocial" runat="server" Text="Label" 
                        CssClass="fonte1"></asp:Label>
                            </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top" rowspan="2">
                    <asp:Label ID="Label4" runat="server" Text="Denúncia:" CssClass="fonte0"></asp:Label>
                            <asp:RequiredFieldValidator ID="DenunciaValidator" runat="server" 
                                ControlToValidate="TextBoxDenuncia" CssClass="failureNotification" 
                                ErrorMessage="Texto da denúncia não informado." SetFocusOnError="True" 
                                ValidationGroup="DenunciaGroup">*</asp:RequiredFieldValidator>
                            </td>
                        <td rowspan="2">
                            <asp:TextBox ID="TextBoxDenuncia" runat="server" Rows="10" 
                                TextMode="MultiLine" Width="600px" ValidationGroup="DenunciaGroup"></asp:TextBox>
                        </td>
                        <td valign="top">
                    <asp:Label ID="Label6" runat="server" 
                                Text="Informe um pequeno resumo da denúncia. Você poderá anexar um documento mais completo com imagens e fotos." 
                                CssClass="fonte0" Font-Italic="True" Width="150px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Anexo (ZIP):" CssClass="fonte0"></asp:Label>
                            <asp:CustomValidator ID="AnexoValidator" runat="server" 
                                CssClass="failureNotification" 
                                ErrorMessage="O anexo deverá estar compactado no formato .zip" 
                                ValidationGroup="DenunciaGroup">*</asp:CustomValidator>
                            </td>
                        <td class="style3">
                            <asp:FileUpload ID="FileUpload" runat="server" 
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
                        </td>
                        <td class="style3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4">
                        </td>
                        <td class="style4">
                            <asp:Button ID="ButtonEnviar" runat="server" onclick="ButtonEnviar_Click" 
                                Text="Enviar Denuncia" ValidationGroup="DenunciaGroup" 
                                
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
                            <asp:Button ID="ButtonCancelar" runat="server" 
                                Text="Cancelar" ValidationGroup="DenunciaGroup" 
                                
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
                        </td>
                        <td class="style4">
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
        
    </form>
</body>
</html>
