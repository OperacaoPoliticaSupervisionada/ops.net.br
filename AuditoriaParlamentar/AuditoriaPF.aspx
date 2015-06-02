<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditoriaPF.aspx.cs" Inherits="AuditoriaParlamentar.AuditoriaPF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        
        .style4
        {
            width: 4px;
        }
    </style>
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/ui/jquery.ui.position.js"></script>
    <script src="Scripts/ui/jquery.ui.core.js"></script>
    <script src="Scripts/ui/jquery.ui.widget.js"></script>
    <script src="Scripts/ui/jquery.ui.button.js"></script>
    <script src="Scripts/ui/jquery.ui.tabs.js"></script>
    <script src="Scripts/ui/jquery.ui.dialog.js"></script>
    <link rel="stylesheet" href="Styles/Site.css">
    <script>
        $(function () {
            $("#dialog-message").dialog({
                modal: true,
                autoOpen: false,
                height: 500,
                width: 800,
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
        });

        function ExibeOqueProcurar() {
            $("#dialog-message").dialog("open");
        }

        function Denunciar() {
            window.parent.TabDenuncia(
                    '<%= LabelCNPJ.Text %>',
                    '<%= LabelRazaoSocial.Text %>');
        }

        function Doacoes() {
            window.parent.TabDoacoes(
                    '<%= LabelCNPJ.Text %>',
                    '<%= LabelRazaoSocial.Text %>');
        }
        
    </script>
</head>
<body>
    <div id="dialog-message" title="O que procurar?" style="display: none; font-size: 14px;">
        <p>
            A primeira coisa que você pode fazer para começar a investigar este fornecedor é
            analisar seu endereço. Empresas localizadas em áreas residênciais ou em regiões
            pobres da cidade podem ser consideradas estranhas. Você pode utilizar o Google Maps
            e o Street View (se estiver disponível) para avaliar a localização da empresa. Você
            poderá inclusive visitar a região se tiver condições.
            <br />
            <br />
            Outra opção é pesquisa pela internet se a empresa possui uma página na internet
            e se ela realmente fornece o serviço prestado ao parlamentar. Empresas sérias não
            se escondem e são facilmente localizadas.
            <br />
            <br />
            Para descobrir os donos da empresa você poderá ir até a Junta Comercial da cidade
            onde a empresa está localizada para solicitar as informações. Será uma informação
            muito importante porque será possível investigar se é algum conhecido do Parlamentar.
            A Junta Comercial irá cobrar uma taxa para fornecer esta informação.
        </p>
    </div>
    <form id="form1" runat="server">
    <table class="table100">
        <tr>
            <td>
                <center>
                    <table>
                        <tr>
                            <td style="margin-left: 120px">
                                <asp:Button ID="ButtonPesquisa" runat="server" Text="Pesquisar Pessoa no Google"
                                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Size="Small" Width="250px" />
                            </td>
                            <td>
                                <asp:Button ID="ButtonListarDocumentos" runat="server" Text="Solicitar/Listar Documentos"
                                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Size="Small" Width="250px" />
                            </td>
                            <td>
                                <asp:Button ID="ButtonListarDeputados" runat="server" Text="Listar Parlamentares"
                                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Size="Small" Width="250px" />
                            </td>
                            <td class="style4">
                                <asp:Button ID="ButtonDenunciar" runat="server" Text="Denunciar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Size="Small" Width="250px" />
                            </td>
                            <td>
                                <asp:Button ID="ButtonListarDoacoes" runat="server" Text="Listar Doações Eleitorais"
                                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                                    Font-Size="Small" Width="250px" />
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PanelExisteDenuncia" runat="server" Visible="False">
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Figuras/exclamation1.png" />
                                </td>
                                <td>
                                    <asp:Label ID="LabelExisteDenuncia" runat="server" Text="Este fornecedor teve 1 denúncia. Evite enviar denúncias repetidas."
                                        Font-Bold="True" CssClass="fonte1" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:GridView ID="GridViewDenuncias" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </center>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <h3 style="text-align: center" class="fonte1">PESSOA FÍSICA</h3></td>
        </tr>
        <tr>
            <td>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="CPF" CssClass="fonte0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelCNPJ" runat="server" Text="Label" Font-Bold="True" CssClass="fonte1"></asp:Label>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="NOME" CssClass="fonte0"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LabelRazaoSocial" runat="server" Text="Label" CssClass="fonte1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
