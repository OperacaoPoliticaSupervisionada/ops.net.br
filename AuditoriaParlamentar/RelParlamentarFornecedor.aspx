<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelParlamentarFornecedor.aspx.cs" Inherits="AuditoriaParlamentar.RelParlamentarFornecedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/assets/css/style.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
</head>
<body>
    <div id="container" class="container-fluid">
        <p class="text-center">Lista de Parlamentares associados com Fornecedores denunciados (denúncia dossiê).</p>
        <br />
        <form id="form1" runat="server">
            <asp:GridView ID="GridViewDenuncias" runat="server" AllowSorting="True" UseAccessibleHeader="true" OnRowDataBound="GridViewDenuncias_RowDataBound"
                CssClass="table table-hover table-striped" GridLines="None" ShowFooter="True" OnSorting="GridViewDenuncias_Sorting">
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
        </form>
    </div>
</body>
</html>
