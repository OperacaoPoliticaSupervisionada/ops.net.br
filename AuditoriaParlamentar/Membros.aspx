<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Membros.aspx.cs" Inherits="AuditoriaParlamentar.Membros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .main
        {
            position:static;
            width:100%;
            min-height:700px;
        }
        body
        {
            height:auto;
        }
        .Grid
        {
            font-size: small;
            font-family: Verdana;
        }
        .style2
        {
            color: #333333;
            width: 800px;
            border-collapse: collapse;
            text-align: left;
            font-size: 1em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table100" 
        style="background-image: url('Figuras/logo_opaca.png'); background-repeat: no-repeat; background-position: right bottom">
        <tr>
            <td>
                <h2>
                    Membros da O.P.S.
                </h2>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" width="420px" height="550px">
                <object classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000" id="ShockwaveFlash1"
                    width="399" height="410" align="left">
                    <!-- Aqui vem Todos os Paramentros --- Ecurtei para efeito de exemplo -->
                    <param name="Movie" value="mapa-brasil.swf" />
                    <param name="FlashVars" value="AC=Membros.aspx?UF=AC&AL=Membros.aspx?UF=AL&AP=Membros.aspx?UF=AP&AM=Membros.aspx?UF=AM&BA=Membros.aspx?UF=BA&CE=Membros.aspx?UF=CE&DF=Membros.aspx?UF=DF&ES=Membros.aspx?UF=ES&GO=Membros.aspx?UF=GO&MA=Membros.aspx?UF=MA&MG=Membros.aspx?UF=MG&MT=Membros.aspx?UF=MT&MS=Membros.aspx?UF=MS&PA=Membros.aspx?UF=PA&PB=Membros.aspx?UF=PB&PR=Membros.aspx?UF=PR&PE=Membros.aspx?UF=PE&PI=Membros.aspx?UF=PI&RJ=Membros.aspx?UF=RJ&RN=Membros.aspx?UF=RN&RO=Membros.aspx?UF=RO&RR=Membros.aspx?UF=RR&RS=Membros.aspx?UF=RS&SC=Membros.aspx?UF=SC&SE=Membros.aspx?UF=SE&SP=Membros.aspx?UF=SP&TO=Membros.aspx?UF=TO" />
                    <!-- Aqui vem Todos os Paramentros --- Ecurtei para efeito de exemplo -->
                    <!-- O código abaixo que é usado no FireFox -->
                    <embed src="mapa-brasil.swf?AC=Membros.aspx?UF=AC&AL=Membros.aspx?UF=AL&AP=Membros.aspx?UF=AP&AM=Membros.aspx?UF=AM&BA=Membros.aspx?UF=BA&CE=Membros.aspx?UF=CE&DF=Membros.aspx?UF=DF&ES=Membros.aspx?UF=ES&GO=Membros.aspx?UF=GO&MA=Membros.aspx?UF=MA&MG=Membros.aspx?UF=MG&MT=Membros.aspx?UF=MT&MS=Membros.aspx?UF=MS&PA=Membros.aspx?UF=PA&PB=Membros.aspx?UF=PB&PR=Membros.aspx?UF=PR&PE=Membros.aspx?UF=PE&PI=Membros.aspx?UF=PI&RJ=Membros.aspx?UF=RJ&RN=Membros.aspx?UF=RN&RO=Membros.aspx?UF=RO&RR=Membros.aspx?UF=RR&RS=Membros.aspx?UF=RS&SC=Membros.aspx?UF=SC&SE=Membros.aspx?UF=SE&SP=Membros.aspx?UF=SP&TO=Membros.aspx?UF=TO"
                        width="399" height="410" devicefont="0" profileport="0">
                </object>
            </td>
            <td valign="top">
                <asp:GridView ID="GridViewMembros" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" Style="text-align: left" CssClass="Grid" Width="100%" AllowSorting="True">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    </table>
</asp:Content>
