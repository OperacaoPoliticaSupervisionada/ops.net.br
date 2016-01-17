<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DenunciasGrid.aspx.cs"
    Inherits="AuditoriaParlamentar.DenunciasGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewDenuncias" runat="server" AllowSorting="True" UseAccessibleHeader="true"
            CssClass="table table-hover table-striped" GridLines="None"
            OnRowCommand="GridViewDenuncias_RowCommand" OnRowDataBound="GridViewDenuncias_RowDataBound"
            EmptyDataText="Você não fez nenhuma denúncia." EmptyDataRowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:CommandField SelectText="Detalhes" ShowSelectButton="True" />
                <asp:ImageField DataImageUrlField="nova_msg" DataImageUrlFormatString="~/Figuras/{0}">
                </asp:ImageField>
            </Columns>
            <RowStyle CssClass="cursor-pointer" />
        </asp:GridView>
    </form>
</body>
</html>
