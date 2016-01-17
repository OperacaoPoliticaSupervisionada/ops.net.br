<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CidadesPendenciaGerenciar.aspx.cs" Inherits="AuditoriaParlamentar.CidadesPendenciaGerenciar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container-fluid">
        <form id="form1" runat="server">
            <p class="text-center">
                <asp:Button ID="ButtonVoltar" runat="server" Text="Voltar" CssClass="btn btn-success" OnClick="ButtonVoltar_Click" />
            </p>
            <asp:GridView ID="GridViewFornecedores" runat="server" AllowSorting="false"
                UseAccessibleHeader="true" OnRowCommand="GridViewFornecedores_RowCommand"
                CssClass="table table-hover table-striped" GridLines="None" ShowFooter="True"
                EmptyDataText="Nenhuma pendência foi incluída!" EmptyDataRowStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:CommandField SelectText="Remover" ShowSelectButton="True" />
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
        </form>
    </div>
</body>
</html>
