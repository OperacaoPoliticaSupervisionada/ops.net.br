<%@ Page Language="C#" ViewStateMode="Disabled" AutoEventWireup="true" CodeBehind="PesquisaPrincipal.aspx.cs"
    Inherits="AuditoriaParlamentar.PesquisaPrincipal" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css">
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/ui/jquery.ui.core.js"></script>
    <script src="Scripts/ui/jquery.ui.widget.js"></script>
    <script src="Scripts/ui/jquery.ui.accordion.js"></script>
    <script src="Scripts/ui/jquery.ui.mouse.js"></script>
    <script src="Scripts/ui/jquery.ui.button.js"></script>
    <script src="Scripts/ui/jquery.ui.draggable.js"></script>
    <script src="Scripts/ui/jquery.ui.position.js"></script>
    <script src="Scripts/ui/jquery.ui.resizable.js"></script>
    <script src="Scripts/ui/jquery.ui.button.js"></script>
    <script src="Scripts/ui/jquery.ui.dialog.js"></script>
    <link rel="stylesheet" href="Styles/Site.css">
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#accordion1").accordion({
                collapsible: true
            });

            if ($("#<%= ListBoxParlamentar.ClientID %> option").size() == 0) {
                $("#accordion2").accordion({ collapsible: true, active: false });
            }
            else {
                $("#accordion2").accordion({ collapsible: true });
            }

            if ($("#<%= ListBoxDespesa.ClientID %> option").size() == 0) {
                $("#accordion3").accordion({ collapsible: true, active: false });
            }
            else {
                $("#accordion3").accordion({ collapsible: true });
            }

            if ($("#<%= ListBoxFornecedor.ClientID %> option").size() == 0) {
                $("#accordion4").accordion({ collapsible: true, active: false });
            }
            else {
                $("#accordion4").accordion({ collapsible: true });
            }

            if ($("#<%= ListBoxUF.ClientID %> option").size() == 0) {
                $("#accordion5").accordion({ collapsible: true, active: false });
            }
            else {
                $("#accordion5").accordion({ collapsible: true });
            }

            if ($("#<%= ListBoxPartido.ClientID %> option").size() == 0) {
                $("#accordion6").accordion({ collapsible: true, active: false });
            }
            else {
                $("#accordion6").accordion({ collapsible: true });
            }

            $('#<%= ButtonPesquisar.ClientID %>').addClass('ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only');
            $('#<%= ButtonShare.ClientID %>').addClass('ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only');
        });

        $(document).ready(function () {
            showHiddenPeriodo(document.getElementById("<%= DropDownListPerido.ClientID %>"));

        });

        function NovoNivel(value, descricao) {
            var desc = $("#<%= HiddenFieldAgrupamentoAtual.ClientID %>").val().substring(4).toUpperCase() + ": " + descricao;

            window.parent.TabPesquisa(
                value,
                desc,
                $("#<%= HiddenFieldGrupo.ClientID %>").val(),
                $("#<%= HiddenFieldAgrupamentoAtual.ClientID %>").val(),
                $("#<%= CheckBoxSepararMes.ClientID %>").is(':checked'),
                $("#<%= DropDownListPerido.ClientID %>").val(),
                $("#<%= DropDownListAnoInicial.ClientID %>").val(),
                $("#<%= DropDownListMesInicial.ClientID %>").val(),
                $("#<%= DropDownListAnoFinal.ClientID %>").val(),
                $("#<%= DropDownListMesFinal.ClientID %>").val(),
                $("#<%= hidListBoxParlamentar.ClientID %>").val(),
                $("#<%= hidListBoxDespesa.ClientID %>").val(),
                $("#<%= hidListBoxFornecedor.ClientID %>").val(),
                $("#<%= hidListBoxUF.ClientID %>").val(),
                $("#<%= hidListBoxPartido.ClientID %>").val(),
                '',
                '');
        }

        function UpdateGridView(row, column, value) {
            var grd = document.getElementById('<%= GridViewResultado.ClientID %>');
            grd.rows[row].cells[column].textContent = value;
        }
    </script>
    <style type="text/css">
        .ui-accordion .ui-accordion-content
        {
            padding: 1em 0;
        }
        .style1
        {
            height: 23px;
        }
        .style2
        {
            width: 100%;
        }
        .watermark
        {
            background-image: url(figuras/logo_opaca.png);
            background-repeat: no-repeat;
            position: fixed;
            bottom: 5px;
            right: 5px;
            width: 600px;
            height: 365px;
            z-index: -1;
        }        
        .maxWidthGrid
        {
            max-width: 350px;
            overflow: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="watermark"></div>
    <table class="style2">
        <tr>
            <td valign="top">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="ButtonPesquisar" runat="server" OnClick="ButtonPesquisar_Click" Text="Clique para Pesquisar"
                                Width="200px" />
                            <asp:ScriptManager ID="ScriptManager" runat="server">
                            </asp:ScriptManager>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="accordion1" class="accordion">
                                <h3>
                                    Básico</h3>
                                <div class="accordion">
                                    <table class="style2">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Cargo:" 
                                                    Style="text-align: center"></asp:Label>
                                            </td>
                                            <td width="90%">
                                                <asp:DropDownList ID="DropDownListGrupo" runat="server" Width="100%" ViewStateMode="Enabled"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DropDownListGrupo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="HiddenFieldGrupo" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Agrupar:" Style="text-align: center"></asp:Label>
                                            </td>
                                            <td width="90%">
                                                <asp:DropDownList ID="DropDownListAgrupamento" runat="server" Width="100%" ViewStateMode="Enabled">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="HiddenFieldAgrupamentoAtual" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:CheckBox ID="CheckBoxSepararMes" runat="server" Font-Bold="True" Text="Exibir mês a mês?"
                                                    ViewStateMode="Enabled" TextAlign="Left" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Período:" Style="text-align: center"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListPerido" runat="server" Width="100%" ViewStateMode="Enabled">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="50px" valign="top">
                                                <table class="style1" width="100%" id="tablePeriodo">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Inicial:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListMesInicial" runat="server" ViewStateMode="Enabled">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListAnoInicial" runat="server" ViewStateMode="Enabled">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Final:"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListMesFinal" runat="server" ViewStateMode="Enabled">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListAnoFinal" runat="server" ViewStateMode="Enabled">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="accordion2" class="accordion">
                                <h3>
                                    Parlamentares</h3>
                                <div class="accordion">
                                    <table class="style2">
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanelParlamentar" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="DropDownListParlamentar" runat="server" ViewStateMode="Enabled"
                                                                        Width="100%">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td width="1%" align="center">
                                                            <asp:ImageButton ID="ImageButtonAddParlamentar" runat="server" ImageUrl="~/Figuras/add.png"
                                                                Height="20px" Width="20px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanelParlamentarList" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:ListBox ID="ListBoxParlamentar" runat="server" Rows="3" Width="200px" SelectionMode="Multiple"
                                                            ViewStateMode="Enabled"></asp:ListBox>
                                                        <asp:HiddenField ID="hidListBoxParlamentar" runat="server" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="accordion3" class="accordion">
                                <h3>
                                    Despesas</h3>
                                <div class="accordion">
                                    <table class="style2">
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanelDespesa" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="DropDownListDespesa" runat="server" Width="100%" ViewStateMode="Enabled">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td width="1%" align="center">
                                                            <asp:ImageButton ID="ImageButtonAddDespesa" runat="server" ImageUrl="~/Figuras/add.png"
                                                                Height="20px" Width="20px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanelDespesaList" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:ListBox ID="ListBoxDespesa" runat="server" Rows="3" Width="200px" SelectionMode="Multiple"
                                                            ViewStateMode="Enabled"></asp:ListBox>
                                                        <asp:HiddenField ID="hidListBoxDespesa" runat="server" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="accordion4" class="accordion">
                                <h3>
                                    Fornecedores</h3>
                                <div class="accordion">
                                    <table class="style2">
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="1%">
                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="CNPJ/CPF: "></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="TextBoxFornecedor" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                        <td width="1%" align="center">
                                                            <asp:ImageButton ID="ImageButtonAddFornecedor" runat="server" ImageUrl="~/Figuras/add.png"
                                                                Height="20px" Width="20px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ListBox ID="ListBoxFornecedor" runat="server" Rows="3" Width="200px" SelectionMode="Multiple"
                                                    ViewStateMode="Enabled"></asp:ListBox>
                                                <asp:HiddenField ID="hidListBoxFornecedor" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="accordion5" class="accordion">
                                <h3>
                                    UF (Parlamentar)</h3>
                                <div class="accordion">
                                    <table class="style2">
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownListUF" runat="server" Width="100%" ViewStateMode="Enabled">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="1%" align="center">
                                                            <asp:ImageButton ID="ImageButtonAddUF" runat="server" ImageUrl="~/Figuras/add.png"
                                                                Height="20px" Width="20px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ListBox ID="ListBoxUF" runat="server" Rows="3" Width="200px" SelectionMode="Multiple"
                                                    ViewStateMode="Enabled"></asp:ListBox>
                                                <asp:HiddenField ID="hidListBoxUF" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="accordion6" class="accordion">
                                <h3>
                                    Partido</h3>
                                <div class="accordion">
                                    <table class="style2">
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanelPartido" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="DropDownListPartido" runat="server" Width="100%" ViewStateMode="Enabled">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td width="1%" align="center">
                                                            <asp:ImageButton ID="ImageButtonAddPartido" runat="server" ImageUrl="~/Figuras/add.png"
                                                                Height="20px" Width="20px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanelPartidoList" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:ListBox ID="ListBoxPartido" runat="server" Rows="3" Width="200px" SelectionMode="Multiple"
                                                            ViewStateMode="Enabled"></asp:ListBox>
                                                        <asp:HiddenField ID="hidListBoxPartido" runat="server" />
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Button ID="ButtonShare" runat="server" OnClick="ButtonShare_Click" Text="Compartilhar"
                                Width="200px" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:UpdatePanel ID="UpdatePanelUltimaAtualizacao" runat="server" 
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <center>
                                        <asp:Label ID="LabelUltimaAtualizacao" runat="server" Text="Última Atualização:"
                                            ViewStateMode="Enabled"></asp:Label>
                                    </center>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="100%">
                <table cellpadding="0" cellspacing="0" class="style2">
                    <tr>
                        <td>
                            <center>
                                <asp:Label ID="LabelMaximo" runat="server" Text="O resultado está limitado a 1.000 registros para evitar sobrecarga."
                                    Font-Bold="True" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label></center>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridViewResultado" runat="server" AllowSorting="True" CellPadding="4"
                                ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowDataBound="GridViewResultado_RowDataBound" OnSorting="GridViewResultado_Sorting"
                                ShowFooter="True">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField>
                                        <FooterTemplate>
                                            <asp:Label ID="LabelTotal" runat="server" Text="Total Geral:"></asp:Label>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <input value="Detalhar" type="button" onclick="NovoNivel('<%# Eval("codigo") %>','<%# Eval("[1]") %>')"
                                                class="fonte" />
                                            <asp:Button ID="ButtonAuditar" runat="server" Text="Auditar" CssClass="fonte" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" CssClass="fonte" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                    CssClass="fonte" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" CssClass="fonte" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
