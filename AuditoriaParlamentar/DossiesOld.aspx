<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DossiesOld.aspx.cs" Inherits="AuditoriaParlamentar.DossiesOld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css"/>
    <style type="text/css">
        .style2
        {
            text-indent: 30px;
            text-align: left;
        }
        
        .Grid
        {
            margin-right: 0px;
        }
        
        a:link, a:visited
        {
            color:inherit;
            text-decoration: none;
        }

        a:hover
        {
            color:inherit;
            text-decoration: underline;
        }

        a:active
        {
            color: #034af3;
        }
        
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table100">
        <tr>
            <td>
                <h2>
        Dossiês
                <asp:Button ID="ButtonNova" runat="server" Text="Novo Dossiê" 
                    CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only" 
                    Font-Size="Small" onclick="ButtonNova_Click" />
                </h2>
            </td>
        </tr>
        <tr>
            <td>
            <div style="width: 70%; margin: auto">
                        <asp:Label ID="LabelSel" runat="server" Font-Size="Medium" ForeColor="#0066FF" 
                            
                            
                            
                            Text="<p class='style2'>O Dossiê é um documento contendo uma série de suspeitas relacionadas aos gastos da Cota do Exercício da Atividade Parlamentar (CEAP) que são submetidos para investigação no Tribula de Contas da União (TCU) e Ministério Público Federal (MPF). Ressaltamos que a decisão final sobre a procedência das denúncias cabe a estes órgãos.</p>"></asp:Label>
            </div>
            </td>
        </tr>
        <tr>
            <td>
            <center>
                    <asp:GridView ID="GridViewDossie" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None"
                        CssClass="Grid" onrowdatabound="GridViewDossie_RowDataBound" 
                        onrowcommand="GridViewDossie_RowCommand" ShowHeader="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:ImageField DataImageUrlField="FotoParlamentar" 
                                DataImageUrlFormatString="{0}">
                                <ControlStyle Height="100px" Width="64px" />
                            </asp:ImageField>
                            <asp:HyperLinkField 
                                DataTextField="parlamentar" HeaderText="Parlamentar" 
                                DataNavigateUrlFields="UrlParlamentar" Target="_blank" />
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
            <td>
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
    </table>
</asp:Content>
