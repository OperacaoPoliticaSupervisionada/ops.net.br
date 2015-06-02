<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="AuditarSenador.aspx.cs" Inherits="AuditoriaParlamentar.AuditarSenador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css" />
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
        
        .watermark
        {
            background-image: url(Figuras/parlamentares/senadores.png);
            background-repeat: no-repeat;
            width: 200px;
            height: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-image: url('Figuras/parlamentares/senadores1.jpg'); background-repeat: repeat-y;
        background-position: left top;">
        <table class="table100" style="background-image: url('Figuras/parlamentares/senadores2.jpg');
            background-repeat: repeat-y; background-position: right top;">
            <tr>
                <td>
                <center>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <a href="http://youtu.be/_f5zUlpcq1U" target="_blank">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Figuras/senado_transparente.png"
                                        ToolTip="Assista ao vídeo" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <a href="http://youtu.be/_f5zUlpcq1U" target="_blank">   
                                <asp:Label ID="Label3" runat="server" Font-Size="Smaller" 
                                    Text="Clique para assistir"></asp:Label>
                                </a>
   
                            </td>
                        </tr>
                    </table>
                </center>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <div style="width: 60%; margin: auto">
                        <p style="font-size: medium; color: #0000FF; font-weight: bold;">
                            Selecione os senadores que deseja auditar e clique em Gravar. Esta informação ficará
                            dispoível para os demais membros da OPS saberem quem já está sendo auditado.</p>
                        <p style="font-size: medium; color: #0000FF">
                            <a href="http://luciobig.blogspot.com.br/p/operacao-senado-transparente.html" target="_blank">
                                Para acessar o formulário clique aqui.</a></p>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="ButtonGravar" runat="server" Text="Gravar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        OnClick="ButtonGravar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <center>
                        <asp:GridView ID="GridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                            Style="text-align: left" CssClass="Grid" OnRowDataBound="GridView_RowDataBound"
                            Font-Size="Small" AllowSorting="True" OnSorting="GridView_Sorting" PageSize="100"
                            AutoGenerateColumns="False" OnRowCommand="GridView_RowCommand">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Selecionar">
                                    <ItemTemplate>
                                        <center>
                                            <asp:CheckBox ID="CheckBoxSelecionar" runat="server" /></center>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="UserName" HeaderText="Usuário" SortExpression="UserName" />
                                <asp:BoundField DataField="NomeParlamentar" HeaderText="Senador" SortExpression="NomeParlamentar" />
                                <asp:BoundField DataField="CodigoParlamentar" HeaderText="CodigoParlamentar" />
                                <asp:BoundField DataField="SiglaPartido" HeaderText="Partido" SortExpression="SiglaPartido" />
                                <asp:BoundField DataField="SiglaUf" HeaderText="UF" SortExpression="SiglaUf" />
                                <asp:HyperLinkField DataNavigateUrlFields="url" HeaderText="Site" Target="_blank"
                                    Text="Site" />
                                <asp:BoundField DataField="DespesasMandato" HeaderText="Gastos no Mandato" SortExpression="DespesasMandato">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" SelectText="Auditar" ShowSelectButton="True" />
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
                <td style="text-align: center">
                    <asp:Button ID="ButtonGravar0" runat="server" Text="Gravar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        OnClick="ButtonGravar_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
