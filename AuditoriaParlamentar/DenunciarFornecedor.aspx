<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DenunciarFornecedor.aspx.cs" Inherits="AuditoriaParlamentar.DenunciarFornecedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/bootstrap.min.js"></script>
    <style type="text/css">
        .fonte0 { font-family: Verdana; font-size: small; }

        .fonte1 { font-family: Verdana; font-weight: bold; font-size: small; }

        .style3 { height: 23px; }
        .style4 { height: 24px; }
    </style>
</head>
<body>
    <div class="container-fluid">
        <form id="form2" runat="server">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">CNPJ/CPF:</label>
                        <span runat="server" id="lblCNPJ" class="control-label show"></span>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Razão Social:</label>
                        <span runat="server" id="lblRazaoSocial" class="control-label show"></span>
                    </div>
                </div>
            </div>
            <div class="alert alert-warning">Informe um pequeno resumo da denúncia. Você poderá anexar um documento mais completo com imagens e fotos.            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Denúncia:</label>
                        <asp:TextBox ID="TextBoxDenuncia" runat="server" Rows="5" TextMode="MultiLine" ValidationGroup="DenunciaGroup" CssClass="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="DenunciaValidator" runat="server" ControlToValidate="TextBoxDenuncia" CssClass="text-danger"
                            ErrorMessage="" SetFocusOnError="True" ValidationGroup="DenunciaGroup">Texto da denúncia não informado.</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Anexo (ZIP):</label>
                        <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control input-sm" />
                        <asp:CustomValidator ID="AnexoValidator" runat="server" CssClass="text-danger"
                            ValidationGroup="DenunciaGroup">O anexo deverá estar compactado no formato .zip</asp:CustomValidator>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Enviar Denuncia" ValidationGroup="DenunciaGroup" CssClass="btn btn-success" />
                    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" ValidationGroup="DenunciaGroup" CssClass="btn btn-default" OnClientClick="window.parent.closeTab();return false;" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
