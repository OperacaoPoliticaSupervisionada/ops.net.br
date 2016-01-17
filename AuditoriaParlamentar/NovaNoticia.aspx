<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="NovaNoticia.aspx.cs" Inherits="AuditoriaParlamentar.NovaNoticia" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/MaxLength.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //Specifying the Character Count control explicitly
            $("[id*=TextBoxNoticia]").MaxLength(
            {
                MaxLength: 255,
                CharacterCountControl: $('#counterTexto')
            });
            $("[id*=TextBoxLink]").MaxLength(
            {
                MaxLength: 255,
                CharacterCountControl: $('#counterLink')
            });
        });

        function AnexoValidation(source, args) {
            args.IsValid = $("#FileUpload").val() != '';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" Text="Texto da Notícia:"></asp:Label>
            <asp:RequiredFieldValidator ID="TextoValidator" runat="server"
                ControlToValidate="TextBoxNoticia" SetFocusOnError="True" CssClass="small pull-right text-danger"
                ValidationGroup="ValidationGroup">* Texto não informado.</asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBoxNoticia" runat="server" MaxLength="255" Rows="5" TextMode="MultiLine"
                ValidationGroup="ValidationGroup" CssClass="form-control"></asp:TextBox>
            <div id="counterTexto" class="show small text-primary"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" Text="Link da Notícia:"></asp:Label>
            <asp:RequiredFieldValidator ID="LinkValidator" runat="server"
                ControlToValidate="TextBoxLink" SetFocusOnError="True" CssClass="small pull-right text-danger"
                ValidationGroup="ValidationGroup">* Link não informado.</asp:RequiredFieldValidator>
            <asp:TextBox ID="TextBoxLink" runat="server" MaxLength="255" CssClass="form-control"></asp:TextBox>
            <div id="counterLink" class="show small text-primary"></div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" Text="Imagem PNG (100 x 100):"></asp:Label>
            <asp:CustomValidator ID="AnexoValidator" runat="server" SetFocusOnError="True" CssClass="small pull-right text-danger"
                ValidationGroup="ValidationGroup" ClientValidationFunction="AnexoValidation();">* Imagem obrigatória</asp:CustomValidator>
            <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Incluir Notícia"
                ValidationGroup="ValidationGroup" CssClass="btn btn-success" />
            <asp:HyperLink runat="server" NavigateUrl="~/Noticias.aspx" CssClass="btn btn-default">Voltar</asp:HyperLink>
        </div>
    </div>
</asp:Content>
