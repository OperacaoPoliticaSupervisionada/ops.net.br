<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditoriaFornecedor.aspx.cs"
    Inherits="AuditoriaParlamentar.AuditoriaFornecedor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family: Verdana;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="dialog-message" title="Sobre o Aplicativo Java" style="display: none">
        <p>
            Após você consultar os dados do fornecedor pelo aplicativo java as indormações serão
            salvar para as próximas consulas e para os próximos usuários que auditarem este
            fornecedor. Como não temos um certificado digital para assinar o aplicativo uma
            mensagem de segurança é exibida.
        </p>
    </div>
    <div class="style1" 
        style="margin-right: 10px; margin-left: 10px; font-size: small;">
        Está página irá carregar um aplicativo Java para você consultar os dados do fornecedor
        na página da Receita. Desta forma os dados ficarão salvos para a próxima consulta.
        Caso tenha alguma dúvida entre em <a href="mailto:suporte@ops.net.br">contato</a>.
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" 
            NavigateUrl="~/CertificadoJava.aspx" Target="_blank">Para evitar as mensagens de segurança do Java e executar a consulta de forma automática siga este procedimento.</asp:HyperLink>
    </div>
    <script src="https://www.java.com/js/deployJava.js"></script>
    <script>
        var attributes = {width:'100%', height:450} ;
        <!-- Base64 encoded string truncated below for readability -->
        var parameters = {jnlp_href:'DadosReceita.jnlp', id:'<%= Id %>', cnpj:'<%= Cnpj %>', usuario:'<%= UserName %>'
        } ;
        deployJava.runApplet(attributes, parameters, '1.6');
    </script>
    </form>
</body>
</html>
