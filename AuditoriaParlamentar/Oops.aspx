<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="AuditoriaParlamentar.Oops" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OPS - Operação Política Supervisionada</title>
</head>
<body>
    <h2 style="text-align: center">
        Desculpe, mas não conseguimos processar sua solicitação...</h2>
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Figuras/bandeira_erro.PNG" />
    
    </div>
    <br />

    <p style="text-align: center">
        <asp:HyperLink ID="HyperLink" runat="server" Font-Size="Large" 
            NavigateUrl="~/Default.aspx">Ir para página principal...</asp:HyperLink>
    </p>
    </form>
    
</body>
</html>
