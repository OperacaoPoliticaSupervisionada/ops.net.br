<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="AuditoriaParlamentar.Noticias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css" />
    <style type="text/css">
        body
        {
            height:auto;
        }
        .main
        {
            position:static;
            width:100%;
        }
        .style2
        {
            font-size: 1em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="display: block; overflow: auto">
        <table class="table100">
            <tr>
                <td>
                    <h2>
                        Notícias
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonNova" runat="server" Text="Nova Notícia" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Size="Small" OnClick="ButtonNova_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <center>
                        <asp:GridView ID="GridViewNoticia" runat="server" CellPadding="4" ForeColor="#333333"
                            GridLines="None" CssClass="Grid" OnRowDataBound="GridViewNoticia_RowDataBound"
                            OnRowCommand="GridViewNoticia_RowCommand" ShowHeader="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField SelectText="Alterar" ShowSelectButton="True" />
                                <asp:ImageField DataImageUrlField="IdNoticia" DataImageUrlFormatString="~/Noticias/{0}.png">
                                </asp:ImageField>
                                <asp:HyperLinkField DataNavigateUrlFields="LinkNoticia" DataTextField="TextoNoticia"
                                    HeaderText="Resumo da Notícia" Target="_blank" />
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
                <td height="40">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
