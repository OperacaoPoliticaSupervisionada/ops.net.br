﻿<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Sobre.aspx.cs" Inherits="AuditoriaParlamentar.Sobre" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .main
        {
            position:static;
            width:100%;
        }
        body
        {
            height:auto;
        }
        .style2
        {
            text-indent: 30px;
            text-align: left;
        }
        .style3
        {
            text-align: center;
        }
        .style4
        {
            text-align: center;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <center>
        <table width="90%">
            <tr>
                <td colspan="3" class="style4">
                    CONHEÇA A O.P.S.
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table class="table100">
                        <tr>
                            <td width="240px">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Figuras/logo_grande.png" />
                            </td>
                            <td>
                                <p class="style2">
                                    A Operação Política Supervisionada (O.P.S.) foi fundada para mostrar à todos os
                                    brasileiros que existem muitas &quot;coisas estranhas&quot; acontecendo nos bastidores
                                    da política e que nem sempre são flagradas pela mídia.
                                </p>
                                <p class="style2">
                                    Fazendo-se do uso da Lei de Acesso a Informação e de algumas ferramentas disponíveis
                                    na Internet, alguns internautas passaram a formar uma importante ferramenta de combate
                                    a corrupção. Este grupo passou a investigar gastos públicos seguindo uma série de
                                    tutoriais criados por um pequeno comerciante da cidade de Brasília.
                                </p>
                                <p class="style2">
                                    O foco primário foi a Cota para o Exercício da Atividade Parlamentar (CEAP) a qual
                                    todos os deputados federais têm direito e visa ao custeio de despesas típicas do
                                    exercício do mandato parlamentar.
                                </p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="~/Figuras/tutorial1.jpg"
                        NavigateUrl="http://www.youtube.com/watch?v=ESenZF_G1qI" Target="_blank">HyperLink</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="~/Figuras/tutorial2.jpg"
                        NavigateUrl="http://www.youtube.com/watch?v=RY9wiZ-Wfz8" Target="_blank">HyperLink</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/Figuras/tutorial3.jpg"
                        NavigateUrl="http://www.youtube.com/watch?v=OQTyD9Ta4lk" Target="_blank">HyperLink</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <p class="style2">
                        Não demorou muito para chegar várias denúncias de todas as partes do Brasil demonstrando
                        que alguns fornecedores utilizados pelos deputados eram, na verdade, empresas de
                        fachada. Estas denúncias deram origem ao Dôssie I com vinte parlamentares que foi
                        entregue ao Tribunal de Contas da União e veiculado em vários telejornais.</p>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="style3">
                    <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="~/Figuras/tutorial4.jpg"
                        NavigateUrl="http://www.youtube.com/watch?v=UmSL6_8IAaE" Target="_blank">HyperLink</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="style3">
                    <p class="style2">
                        A criação da ops.net.br trouxe mais dinâmica ao processo de denúncias. Além de permitir
                        uma análise mais abrangente nos gastos da CEP, todas as ferramentas utilizadas para
                        identificar empresas suspeitas foram reunidas facilitando assim o processo de investigação.</p>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="style4">
                    <a name="doacoes">DOAÇÕES</a>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="style3">
                    <p class="style2">
                        Não precisamos de muito, mas o seu pouco vai nos ajudar bastante. Além dos custos
                        para manter o portal muitas vezes solicitamos notas fiscais à Câmara do Deputados
                        ou gastamos combustível para investigar algum endereço suspeito. Ajude a O.P.S.
                        adquirindo o <a href="http://produto.mercadolivre.com.br/MLB-531788283-cd-util-e-futil-_JM"
                            target="_blank">CD Útil E Fútil</a> ou uma <a href="http://eshops.mercadolivre.com.br/didi+madeira/"
                                target="_blank">Camiseta da OPS</a> através do Mercado Livre. Criamos também
                        uma conta no Patreon, que é um site especializado em doações. São doações mensais
                        a partir de 2 dólares. <a href="http://www.patreon.com/operacaopoliticasupervisionada"
                            target="_blank">Acesse aqui nossa página no Patreon.</a></p>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="style3">
                    <p class="style2">
                        Caso tenha alguma dúvida sobre a O.P.S. acesse nossa <a href="https://www.facebook.com/groups/538224459571284/"
                            target="_blank">comunidade no Facebook.</a> Ou envie um e-mail para <a href="mailto:luciobig@ops.net.br">
                                luciobig@ops.net.br</a>.</p>
                </td>
            </tr>
            <tr>
                <td colspan="3" class="style3">
                    <p class="style2">
                        Para dúvidas, sugestões ou reclamações sobre o site envie um e-mail para <a href="mailto:suporte@ops.net.br">
                            suporte@ops.net.br</a></p>
                </td>
            </tr>
            <tr>
                <td colspan="3" height="40px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
        </table>
    </center>
</asp:Content>
