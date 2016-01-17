<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="AuditoriaParlamentar.Oops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>404 - OPS - Operação Política Supervisionada</title>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <%--<script type="text/javascript" src="assets/js/bootstrap.min.js"></script>--%>
    <style type="text/css">
        #error_page { background: #f1f1f1 url('Figuras/logo_opaca.png') no-repeat center center}
        .error-template {padding: 40px 15px;text-align: center;}
        .error-template p { font-size: 18px }
        .error-template h1{ font-size: 90px; color: #c3c3c3}
    </style>
</head>
<body id="error_page">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="error-template">
                    <h1>404</h1>
                    <br />
                    <p>Oops, parece que a página que você estava tentando acessar não está mais aqui!</p>
                    <br /><br />
                    <div class="error-actions">
                        <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx" CssClass="btn btn-primary btn-lg">
                            <span class="glyphicon glyphicon-home"></span>&nbsp;Ir para página principal</asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>
     </div>
</body>
</html>
