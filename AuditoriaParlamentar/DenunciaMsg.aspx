<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DenunciaMsg.aspx.cs" Inherits="AuditoriaParlamentar.DenunciaMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css"/>
    <link rel="stylesheet" href="Styles/Site.css"/>
    <style type="text/css">
        .Grid
        {
            font-size: small;
            font-family: Verdana;
        }

    </style>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <%--<script type="text/javascript" src="Scripts/MaxLength.min.js"></script>--%><%--<script type="text/javascript">
        $(function () {
            //Specifying the Character Count control explicitly
            $("[id*=TextBoxComentario]").MaxLength(
            {
                MaxLength: 255,
                CharacterCountControl: $('#counter')
            });
        });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table class="table100">
        <tr>
            <td>
                <asp:Button ID="ButtonVoltar" runat="server" Text="Voltar" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonVoltar_Click" />
                <asp:Button ID="ButtonListarDocumentos" runat="server" Text="Solicitar/Listar Documentos" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonVoltar_Click" />
                <asp:Button ID="ButtonFotoIncluir" runat="server" Text="Incluir Pendência" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonFotoIncluir_Click" />
                <asp:Button ID="ButtonFotoExcluir" runat="server" Text="Excluir Pendência" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonFotoExcluir_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="DenunciaValidationSummary" runat="server" CssClass="failureNotification"
                    ValidationGroup="DenunciaGroup" />
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td width="100px">
                            <asp:Label ID="Label8" runat="server" Text="Denúncia:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelId" runat="server" Text="Label" Font-Bold="True" 
                                CssClass="fonte1"></asp:Label>
                        </td>
                        <td width="100px">
                            <asp:Label ID="Label9" runat="server" Text="Usuário:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelUsuario" runat="server" Text="Label" CssClass="fonte1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100px">
                            <asp:Label ID="Label1" runat="server" Text="CNPJ/CPF:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelCNPJ" runat="server" Text="Label" Font-Bold="True" CssClass="fonte1"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Razão Social:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:HyperLink ID="HyperLinkRazaoSocial" runat="server" CssClass="fonte1">HyperLink</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Data:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelData" runat="server" Text="Label" CssClass="fonte1"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Situação:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelSituacao" runat="server" Text="Label" CssClass="fonte1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label4" runat="server" Text="Denúncia:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:Label ID="LabelTexto" runat="server" Text="Label" CssClass="fonte1"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="Label7" runat="server" Text="Anexos:" CssClass="fonte0"></asp:Label>
                        </td>
                        <td colspan="3">
                <asp:GridView ID="GridViewAnexo" runat="server"
                    GridLines="None" style="text-align: left" CssClass="Grid" AutoGenerateColumns="False" 
                                onrowcommand="GridViewAnexo_RowCommand" ShowHeader="False">
                    <Columns>
                        <asp:BoundField DataField="Arquivo" ReadOnly="True" SortExpression="Arquivo">
                        <ItemStyle Font-Bold="True" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Figuras/disk.png" 
                            ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle 
                        HorizontalAlign="Left" />
                </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td valign="top">
                            &nbsp;</td>
                        <td>
                <asp:GridView ID="GridViewComentarios" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" style="text-align: left" CssClass="Grid" 
                                onrowdatabound="GridViewComentarios_RowDataBound" Width="800px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;</td>
                        <td>
                            <asp:DropDownList ID="DropDownListSituacao" runat="server" CssClass="fonte1" 
                                onselectedindexchanged="DropDownListSituacao_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:RequiredFieldValidator ID="DenunciaValidator" runat="server" 
                                ControlToValidate="TextBoxComentario" CssClass="failureNotification" 
                                ErrorMessage="Comentário não informado." SetFocusOnError="True" 
                                ValidationGroup="DenunciaGroup">*</asp:RequiredFieldValidator>
                            </td>
                        <td>
                <asp:TextBox ID="TextBoxComentario" runat="server" Rows="5" TextMode="MultiLine"
                    Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:CustomValidator ID="AnexoValidator" runat="server" 
                                CssClass="failureNotification" 
                                ErrorMessage="O anexo deverá estar compactado no formato .zip" 
                                ValidationGroup="DenunciaGroup">*</asp:CustomValidator>
                            </td>
                        <td>
                            <asp:FileUpload ID="FileUpload" runat="server" 
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Enviar Comentário"
                    ValidationGroup="DenunciaGroup" 
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                Font-Size="Small" />
                        </td>
                        <%--<td>
                                <div id="counter" style="font-size: small; color: #0000FF;"/>
                            </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelOutrasDenuncias0" runat="server" CssClass="fonte0" 
                    Text="Abaixo são listados os deputados que utilizaram este fornecedor."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                        <asp:GridView ID="GridViewDeputados" runat="server" CellPadding="4" ForeColor="#333333"
                            GridLines="None" Style="text-align: left" CssClass="Grid" OnRowDataBound="GridViewDeputados_RowDataBound"
                            ShowFooter="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:HyperLinkField DataNavigateUrlFields="url" Target="_blank" Text="Site" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelOutrasDenuncias" runat="server" CssClass="fonte0" 
                    Text="Abaixo são listadas outras denúncias feitas para este mesmo fornecedor."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridViewDenuncias" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" style="text-align: left" CssClass="Grid">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                        </td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
