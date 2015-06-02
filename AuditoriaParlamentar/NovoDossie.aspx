<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovoDossie.aspx.cs" Inherits="AuditoriaParlamentar.NovoDossie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css"/>
    <link rel="stylesheet" href="Styles/Master.css"/>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <style type="text/css">

        body   
        {
            background: #b6b7bc;
            font-size: .80em;
            font-family: Verdana;
            margin: 0px;
            padding: 0px;
            color: #696969;
            height: auto;
        }
        
        .Grid
        {
            font-size: small;
            font-family: Verdana;
        }

        .style2
        {
            color: #333333;
            border-collapse: collapse;
            text-align: left;
            font-size: 1em;
        }
    </style>
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
                <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Salvar Dossiê"
                    ValidationGroup="ValidationGroup" 
                                CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                                Font-Size="Small" />
                <asp:Button ID="ButtonExcluir" runat="server" Text="Excluir Dossiê" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonExcluir_Click" />
            </td>
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
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nome do Dossiê:"></asp:Label>
            </td>
            <td>
                            <asp:RequiredFieldValidator ID="TextoValidator" runat="server" 
                                ControlToValidate="TextBoxNome" CssClass="failureNotification" 
                                ErrorMessage="Nome não informado." SetFocusOnError="True" 
                                ValidationGroup="ValidationGroup">*</asp:RequiredFieldValidator>
                            </td>
            <td>
                <asp:TextBox ID="TextBoxNome" runat="server" MaxLength="255" Width="200px">Dossiê X</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HiddenField ID="HiddenFieldIdDossie" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" Text="Parlamentares:"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                        <asp:GridView ID="GridViewResultado" runat="server" CellPadding="4" ForeColor="#333333"
                            GridLines="None" Style="text-align: left" CssClass="Grid" 
                            OnRowDataBound="GridViewResultado_RowDataBound" AllowSorting="True" 
                            OnSorting="GridViewResultado_Sorting">
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
                    </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
