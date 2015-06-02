<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CidadesPendenciaGrid.aspx.cs"
    Inherits="AuditoriaParlamentar.CidadesPendenciaGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/themes/start/jquery.ui.all.css" />
    <link rel="stylesheet" href="Styles/Site.css">
    <style type="text/css">
        a:link, a:visited
        {
            color: #034af3;
        }
        .fonte2
        {
            text-indent: 60px;
            text-align: left;
            font-size: medium;
        }
        p
        {
            margin-bottom: 10px;
            line-height: 1.6em;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="watermark"></div>
    <table class="table100">
        <tr>
            <td>
                <div style="margin-right: 20px; margin-left: 20px">
                    <p class='fonte2'>
                        Precisamos da sua ajuda para levantar informações nas cidades relacionadas abaixo.
                        Na maioria das vezes precisamos de uma fotografia atualizada de algum endereço suspeito.
                        Em alguns poucos casos precisamos de documentos na junta comercial. Se você tiver
                        disponibilidade e for maior de 18 anos entre em contado no email <a href="mailto:luciobig@ops.net.br">
                            luciobig@ops.net.br</a> para receber as instruções.</p>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:Button ID="ButtonGerenciar" runat="server" Text="Gerenciar" CssClass="ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only"
                        Font-Size="Small" OnClick="ButtonGerenciar_Click" />
            </td>
            </center>
        </tr>
        <tr>
            <td>
                <center>
                    <asp:GridView ID="GridViewCidades" runat="server" CellPadding="4" ForeColor="#333333"
                        CssClass="Grid" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Uf" HeaderText="UF">
                                <HeaderStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                            <asp:BoundField DataField="pendencias" HeaderText="Qtd. Pendências">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
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
                <br />
                <br />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
