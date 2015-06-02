<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AuditoriaParlamentar.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link type="text/css" rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css"/>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.core.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.widget.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.accordion.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.mouse.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.button.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.draggable.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.position.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.resizable.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.button.js"></script>
    <script type="text/javascript" src="Scripts/ui/jquery.ui.dialog.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#accordion1").accordion({
                collapsible: true
            });

            $("#accordion2").accordion({
                collapsible: true
            });

            $("#accordion3").accordion({
                collapsible: true
            });

            $("#accordion4").accordion({
                collapsible: true
            });

            $("#accordion5").accordion({
                collapsible: true,
                heightStyle: "content"
            });
            $("#accordion6").accordion({
                collapsible: true,
                heightStyle: "content"
            });
        });

    </script>
    <style type="text/css">
        .main
        {
            position:static;
            width:100%;
        }
        body
        {
            height:auto;
        }
        
        .style3
        {
            width: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table100">
        <tr>
            <td valign="top" width="450">
                <div id="accordion6" class="accordion" style="margin: 5px 0px 0px 5px;">
                    <p style="font-size: small">
                        Sobre</p>
                    <div class="accordion">
                        <table style="height: 65px">
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/About.aspx"
                                        >◊ Conheça a operação que está fiscalizando e denunciando dezenas de parlamentares.</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/About.aspx#doacoes"
                                        >◊ Ajude a O.P.S. financeiramente.</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="accordion4" class="accordion" style="margin: 5px 0px 0px 5px;">
                    <p style="font-size: small">
                        Tutoriais</p>
                    <div class="accordion">
                        <table>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://youtu.be/6hhHZgXRPWs"
                                        Target="_blank">◊ Utilizando a pesquisa para analisar os gastos</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://youtu.be/K7OlV7se5wg"
                                        Target="_blank">◊ Auditando fornecedores e enviando denúncias</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="http://youtu.be/DIUnWSfXB1g"
                                        Target="_blank">◊ Auditando Notas Fiscais - Parte 1</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="http://youtu.be/bdXwHV688nM"
                                        Target="_blank">◊ Auditando Notas Fiscais - Parte 2</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="accordion1" class="accordion" style="margin: 5px 0px 0px 5px; width: 470px">
                    <p style="font-size: small">
                        Investigue um Parlamentar do seu Estado</p>
                    <div class="accordion">
                        <object classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000" id="ShockwaveFlash1"
                            width="399" height="410" align="left">
                            <!-- Aqui vem Todos os Paramentros --- Ecurtei para efeito de exemplo -->
                            <param name="Movie" value="mapa-brasil.swf" />
                            <param name="FlashVars" value="AC=PesquisaInicio.aspx?UF=AC&AL=PesquisaInicio.aspx?UF=AL&AP=PesquisaInicio.aspx?UF=AP&AM=PesquisaInicio.aspx?UF=AM&BA=PesquisaInicio.aspx?UF=BA&CE=PesquisaInicio.aspx?UF=CE&DF=PesquisaInicio.aspx?UF=DF&ES=PesquisaInicio.aspx?UF=ES&GO=PesquisaInicio.aspx?UF=GO&MA=PesquisaInicio.aspx?UF=MA&MG=PesquisaInicio.aspx?UF=MG&MT=PesquisaInicio.aspx?UF=MT&MS=PesquisaInicio.aspx?UF=MS&PA=PesquisaInicio.aspx?UF=PA&PB=PesquisaInicio.aspx?UF=PB&PR=PesquisaInicio.aspx?UF=PR&PE=PesquisaInicio.aspx?UF=PE&PI=PesquisaInicio.aspx?UF=PI&RJ=PesquisaInicio.aspx?UF=RJ&RN=PesquisaInicio.aspx?UF=RN&RO=PesquisaInicio.aspx?UF=RO&RR=PesquisaInicio.aspx?UF=RR&RS=PesquisaInicio.aspx?UF=RS&SC=PesquisaInicio.aspx?UF=SC&SE=PesquisaInicio.aspx?UF=SE&SP=PesquisaInicio.aspx?UF=SP&TO=PesquisaInicio.aspx?UF=TO" />
                            <!-- Aqui vem Todos os Paramentros --- Ecurtei para efeito de exemplo -->
                            <!-- O código abaixo que é usado no FireFox -->
                            <embed src="mapa-brasil.swf?AC=PesquisaInicio.aspx?UF=AC&AL=PesquisaInicio.aspx?UF=AL&AP=PesquisaInicio.aspx?UF=AP&AM=PesquisaInicio.aspx?UF=AM&BA=PesquisaInicio.aspx?UF=BA&CE=PesquisaInicio.aspx?UF=CE&DF=PesquisaInicio.aspx?UF=DF&ES=PesquisaInicio.aspx?UF=ES&GO=PesquisaInicio.aspx?UF=GO&MA=PesquisaInicio.aspx?UF=MA&MG=PesquisaInicio.aspx?UF=MG&MT=PesquisaInicio.aspx?UF=MT&MS=PesquisaInicio.aspx?UF=MS&PA=PesquisaInicio.aspx?UF=PA&PB=PesquisaInicio.aspx?UF=PB&PR=PesquisaInicio.aspx?UF=PR&PE=PesquisaInicio.aspx?UF=PE&PI=PesquisaInicio.aspx?UF=PI&RJ=PesquisaInicio.aspx?UF=RJ&RN=PesquisaInicio.aspx?UF=RN&RO=PesquisaInicio.aspx?UF=RO&RR=PesquisaInicio.aspx?UF=RR&RS=PesquisaInicio.aspx?UF=RS&SC=PesquisaInicio.aspx?UF=SC&SE=PesquisaInicio.aspx?UF=SE&SP=PesquisaInicio.aspx?UF=SP&TO=PesquisaInicio.aspx?UF=TO"
                                width="399" height="410" devicefont="0" profileport="0">
                        </object>
                    </div>
                </div>
                <div id="accordion2" class="accordion" style="margin: 5px 0px 0px 5px;">
                    <p style="font-size: small">
                        Pesquisas Prontas</p>
                    <div class="accordion">
                        <table>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLinkParlamentar" runat="server" Font-Size="Small">Gastos por Parlamentar</asp:HyperLink>
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLinkPartido" runat="server" Font-Size="Small">Gastos por Partido</asp:HyperLink>
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLinkDespesa" runat="server" Font-Size="Small">Gastos por Despesa</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="HyperLinkFornecedor" runat="server" Font-Size="Small">Gastos por Fornecedor</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLinkEstado" runat="server" Font-Size="Small">Gastos por Estado</asp:HyperLink>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td valign="top">
                <div id="accordion3" class="accordion" style="margin: 5px 0px 0px 5px;">
                    <p style="font-size: small">
                        Estatísticas</p>
                    <div class="accordion">
                        <center>
                            <table style="height: 65px">
                                <tr>
                                    <td colspan="5">
                                        <center>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="Large" Text="Denúncias Enviadas:"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelDenunciasEnviadas" runat="server" Font-Bold="True" Font-Size="Large"
                                                            Text="0" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Large" Text="Fornecedores Suspeitos:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelFornecedoresDenunciados" runat="server" Font-Bold="True" Font-Size="Large"
                                            Text="0" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp; &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="Parlamentares Atingidos:"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelParlamentaresAtingidos" runat="server" Font-Bold="True" Font-Size="Large"
                                            Text="0" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </div>
                <div id="accordion5" class="accordion" style="margin: 5px 0px 0px 5px;">
                    <p style="font-size: small">
                        Últimas Notícias</p>
                    <div class="accordion">
                        <table class="table100">
                            <tr>
                                <td>
                                    <asp:GridView ID="GridViewNoticia" runat="server" CellPadding="4" ForeColor="#333333"
                                        GridLines="None" CssClass="Grid" OnRowDataBound="GridViewNoticia_RowDataBound"
                                        ShowHeader="False" Width="100%">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:ImageField DataImageUrlField="IdNoticia" DataImageUrlFormatString="~/Noticias/{0}.png">
                                            </asp:ImageField>
                                            <asp:HyperLinkField DataNavigateUrlFields="LinkNoticia" DataTextField="TextoNoticia"
                                                ShowHeader="False" Target="_blank" />
                                            <asp:BoundField DataField="DataNoticia" DataFormatString="{0:dd/MM/yyyy}" />
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Noticias.aspx">Ver todas...</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
