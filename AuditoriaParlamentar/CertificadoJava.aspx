<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertificadoJava.aspx.cs" Inherits="AuditoriaParlamentar.CertificadoJava" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OPS - Operação Política Supervisionada</title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
        }
        .style2
        {
            color: #000000;
        }
        .style3
        {
            color: #000000;
        }
        .style4
        {
            color: #FF3300;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        Instalação do Certificado Digital da OPS</div>
    <p>
        Este procedimento é opcional e visa somente a remoção do aviso de seguranção ao 
        executar o aplicativo de consulta de CNPJ.</p>
    <p>
        1) Fazer o download do certificado digital da OPS (<strong>ops.crt</strong>).
    </p>
    <p>
        <asp:Button ID="Button" runat="server" onclick="Button_Click" 
            Text="Download do Certificado" />
    </p>
    <p>
        2) Acessar as configurações do Java</p>
    <ul>
        <li>Windows: Abrir o Painel de Controle e dar duplo clique no ícone Java</li>
        <li>Mac: Acessar o Launchpad, Preferências do Sistema e clicar no ícone Java</li>
    </ul>
    <p>
        3) Neste ponto você estará vendo uma janela parecida com a imagem abaixo. Agora 
        clique em <span class="style4">Segurança</span>.</p>
    <p>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Figuras/java01.png" />
    </p>
    <p>
        4) Clique em <span class="style4">Gerenciar Certificados...</span></p>
    <p>
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Figuras/java02.png" />
    </p>
    <p>
        5) No Tipo de Certificado selecione o item <span class="style4">CA de Signatário</span><span 
            class="style2">. Depois clique em </span><span class="style4">Importar</span><span 
            class="style3">.</span></p>
    <p>
        <asp:Image ID="Image3" runat="server" ImageUrl="~/Figuras/java03.png" />
    </p>
    <p>
        6) Na janela de seleção de arquivo deverá ser selecionado <span class="style3">
        Todos os Arquivos (All Files)</span>. E então você deverá navegar até o 
        diretório onde foi salvo o arquivo <span class="style4">ops.crt</span> e abri-lo<span 
            class="style3"> (Open)</span>.</p>
    <p>
        <asp:Image ID="Image4" runat="server" ImageUrl="~/Figuras/java04.png" />
    </p>
    <p>
        7) Agora que você importou o certificado conforme a imagem abaixo poderá
        <span class="style4">Fechar</span> as configurações do Java.</p>
    <p>
        <asp:Image ID="Image5" runat="server" ImageUrl="~/Figuras/java05.png" />
    </p>
    <p>
        8) Quando você executar novamente a consulta de CNPJ no portal da OPS será 
        exibida um aviso parecido com o da imagem abaixo. Agora basta marcar a opção 
        <span class="style4">Não mostrar novamente para aplicações do editor e local 
        acima</span><span class="style3"> para o aplicativo sempre iniciar de forma 
        automática.</span></p>
    <p>
        <asp:Image ID="Image6" runat="server" ImageUrl="~/Figuras/java06.png" />
    </p>
    <p>
        &nbsp;</p>
    </form>
</body>
</html>
