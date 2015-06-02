<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitaDocumentos.aspx.cs"
    Inherits="AuditoriaParlamentar.SolicitaDocumentos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css" />
    <link rel="stylesheet" href="Styles/Site.css">
    <style type="text/css">
        table
        {
            font-size: 1em;
        }
        
        .fonte
        {
            font-family: Tahoma;
            font-size: 10pt;
        }
        
        a:link
        {
            color: #034af3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table100">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td width="100px">
                                <asp:Label ID="Label9" runat="server" Text="CNPJ/CPF:" CssClass="fonte0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelCNPJ" runat="server" Text="Label" Font-Bold="True" CssClass="fonte1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Razão Social:" CssClass="fonte0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelNome" runat="server" Text="Label" Font-Bold="True" CssClass="fonte1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="LabelNome0" runat="server" Text="Selecione o Parlamentar:" 
                                    Font-Bold="True" CssClass="fonte1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListParlamentar" runat="server" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="DropDownListParlamentar_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    </center>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <center>
                        <asp:Panel ID="Panel1" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:HyperLink ID="HyperLinkCamara" runat="server" Font-Bold="True" 
                                            Font-Size="Medium" ForeColor="#0066FF" Target="_blank">Você poderá consultar se o documento está disponível no portal da Câmara.</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </center>
                </td>
            </tr>
            <tr>
                <td style="padding: 0px 10px 0px 10px">
                    <center>
                        <asp:HyperLink ID="HyperLinkDoc" runat="server" Font-Size="Medium" ForeColor="#0066FF"
                            NavigateUrl="http://www2.camara.leg.br/participe/fale-conosco/?contexto=biblarq"
                            Target="_blank">Clique aqui para abrir uma solicitação no Fale Conosco da Câmara dos Deputados. Copie o texto abaixo e cole na mensagem da solicitação. Após a solicitação ser processada a Câmara enviará um e-mail com instruções de como fazer o pagamento. O custo é de R$ 0,15 centavos por folha.</asp:HyperLink>
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:TextBox ID="TextBoxTexto" runat="server" Rows="10" TextMode="MultiLine" Width="700px"></asp:TextBox>
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:Label ID="LabelSel" runat="server" Font-Size="Medium" ForeColor="#0066FF" 
                            
                            Text="Selecione os documentos que deseja solicitar e clique em Gerar Texto."></asp:Label>
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:Button ID="ButtonGerar" runat="server" Text="Gerar Texto" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                            Font-Size="Small" OnClick="ButtonGerar_Click" />
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:GridView ID="GridViewResultado" runat="server" CellPadding="4" ForeColor="#333333"
                            GridLines="None" Style="text-align: left" CssClass="Grid" OnRowDataBound="GridViewResultado_RowDataBound"
                            ShowFooter="True" AllowSorting="True" OnSorting="GridViewResultado_Sorting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Selecionar">
                                    <ItemTemplate>
                                        <center>
                                            <asp:CheckBox ID="CheckBoxSelecionar" runat="server" /></center>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
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
                    </center>
                </td>
            </tr>
            <tr>
                <td height="40px">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
