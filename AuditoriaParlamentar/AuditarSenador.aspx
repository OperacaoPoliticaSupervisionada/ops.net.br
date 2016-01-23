<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="AuditarSenador.aspx.cs" Inherits="AuditoriaParlamentar.AuditarSenador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12 text-center">
                <a href="http://youtu.be/_f5zUlpcq1U" target="_blank">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Figuras/senado_transparente.png"
                        ToolTip="Assista ao vídeo" /></a>
            </div>
            <div class="col-md-12 text-center">
                <a href="http://youtu.be/_f5zUlpcq1U" target="_blank">
                    <asp:Label ID="Label3" runat="server" Font-Size="Smaller"
                        Text="Clique para assistir"></asp:Label>
                </a>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <p class="text-center">
                    Selecione os senadores que deseja auditar e clique em Gravar. Esta informação ficará
                            dispoível para os demais membros da OPS saberem quem já está sendo auditado.
                </p>
                <p class="text-center">
                    <a href="http://luciobig.com.br/2014/07/31/operacao-senado-transparente-2/" target="_blank">Para acessar o formulário clique aqui.</a>
                </p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="ButtonGravar" runat="server" Text="Gravar" CssClass="btn btn-success" OnClick="ButtonGravar_Click" />
            </div>
            <br />
            <br />
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="GridView" runat="server" AllowSorting="false" AutoGenerateColumns="false"
                        UseAccessibleHeader="true" OnRowCommand="GridView_RowCommand" OnRowDataBound="GridView_RowDataBound"
                        CssClass="table table-hover table-striped" GridLines="None"
                        EmptyDataText="Nenhum Anexo Adicionado!" EmptyDataRowStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField HeaderText="Selecionar">
                                <ItemTemplate>
                                    <center><asp:CheckBox ID="CheckBoxSelecionar" runat="server" /></center>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="Usuário" SortExpression="UserName" />
                            <asp:BoundField DataField="NomeParlamentar" HeaderText="Senador" SortExpression="NomeParlamentar" />
                            <asp:BoundField DataField="CodigoParlamentar" HeaderText="CodigoParlamentar" />
                            <asp:BoundField DataField="SiglaPartido" HeaderText="Partido" SortExpression="SiglaPartido" />
                            <asp:BoundField DataField="SiglaUf" HeaderText="UF" SortExpression="SiglaUf" />
                            <asp:HyperLinkField DataNavigateUrlFields="url" HeaderText="Site" Target="_blank" Text="Site" />
                            <asp:BoundField DataField="DespesasMandato" HeaderText="Gastos no Mandato" SortExpression="DespesasMandato" />
                            <asp:CommandField ButtonType="Button" SelectText="Auditar" ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary btn-sm" />
                        </Columns>
                        <RowStyle CssClass="cursor-pointer" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Button ID="ButtonGravar0" runat="server" Text="Gravar" CssClass="btn btn-success" OnClick="ButtonGravar_Click" />
            </div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
