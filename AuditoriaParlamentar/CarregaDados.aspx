<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarregaDados.aspx.cs" Inherits="AuditoriaParlamentar.CarregaDados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">

        .Grid
        {
            font-size: small;
            font-family: Verdana;
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
    <br />
<asp:FileUpload ID="FileUpload" runat="server" />
<br />
    <br />
    <asp:CheckBox ID="CheckBoxDiferenca" runat="server" Checked="True" 
        Text="Apenas Diferença?" />
    <br />
<br />
<asp:Button ID="ButtonEnviar" runat="server" onclick="ButtonEnviar_Click" 
    Text="Carregar Cotas Deputados" Width="200px" />
    <asp:Button ID="ButtonSenadores" runat="server" onclick="ButtonSenadores_Click" 
        Text="Carrega Cotas Senadores" Width="200px" />
    <br />
<asp:Button ID="ButtonEfetivaDep" runat="server" onclick="ButtonEfetivaDep_Click" 
    Text="Efetiva Cotas Deputados" Width="200px" />
    <asp:Button ID="ButtonEfetivaSen" runat="server" onclick="ButtonEfetivaSen_Click" 
        Text="Efetiva Cotas Senadores" Width="200px" />
    <br />
                <asp:GridView ID="GridViewAcerto" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" style="text-align: left" CssClass="Grid">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
    <br />
                <asp:GridView ID="GridViewPrevia" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" style="text-align: left" CssClass="Grid">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Left" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Ano: "></asp:Label>
    <asp:TextBox ID="TextBoxAno" runat="server"></asp:TextBox>
<asp:Button ID="ButtonCarregarRec" runat="server" onclick="ButtonCarregarRec_Click" 
    Text="Carregar Receitas Eleição" />
    <br />
    <br />
    <br />
    <br />
    <asp:Button ID="ButtonSuspeitas" runat="server" onclick="ButtonSuspeitas_Click" 
        Text="Carrega Suspeitas" />
    <br />
    <br />
    <asp:Button ID="ButtonFotos" runat="server" onclick="ButtonFotos_Click" 
        Text="Download Fotos" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
