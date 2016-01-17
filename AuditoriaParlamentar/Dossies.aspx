<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Dossies.aspx.cs" Inherits="AuditoriaParlamentar.Dossies1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #dossie-page .style2 { text-indent: 30px; text-align: justify; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div id="dossie-page" class="container-fluid">
        <ul id="tabs" class="nav nav-tabs" data-tabs="tabs">
            <li class="active"><a href="#tabs-1" data-toggle="tab">Dossiê 1</a></li>
            <li><a href="#tabs-2" data-toggle="tab">Dossiê 2</a></li>
        </ul>
        <br />
        <div class="tab-content">
            <div class="tab-pane active" id="tabs-1">
                <p class='style2'>A Lista dos Vinte é o primeiro documento elaborado pela OPS (Operação Política Supervisionada) que contém informações públicas de transações financeiras entre diversas empresas com deputados federais e senadores. Durante todo o processo de investigação, nós encontramos indícios de falsidade ideológica e documental. Porém, isso não quer dizer que todas as informações aqui constantes fazem dos parlamentares citados, corruptos. Torcemos para que estejamos errados e que as inconstâncias encontradas sejam meros enganos. Entretanto, é imperativo que investigações oficiais sejam feitas a fim de dirimir quaisquer dúvidas que possam pairar sobre a honra e honestidade de cada um dos políticos aqui citados.</p>
                <p class='style2'>A denúncia feita em junho de 2013 no TCU - Tribunal de Contas da União, foi aceita por este tribunal e em maio deste ano confirmou que realmente há indícios dos crimes acima citados. <a target="_blank" href="/Documentos/Acórdão 1312_2014 (Ref. à Demanda 143887).pdf" style="color: #0000FF; font-weight: bold;">Este é o documento expedido pelo TCU ao Congresso Nacional.</a></p>
                <p class='style2'>Reafirmamos o nosso compromisso em nos mantermos incondicionalmente imparciais na apuração de todos os casos até agora levantados e dos outros que ainda virão, assim como rechaçamos qualquer comentário que venha a nos ligar a qualquer partido político que seja. Somos apartidários e independentes.</p>
                <div class="row">
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">ABELARDO CAMARINHA</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image1" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/141463.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label17" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" Text="PSB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" Text="SP" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.camara.leg.br/Internet/Deputado/dep_Detalhe.asp?id=141463"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">ADRIAN MUSSI</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image2" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/160577.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label18" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="PMDB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label7" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label8" runat="server" Text="RJ" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.camara.leg.br/Internet/Deputado/dep_Detalhe.asp?id=160577"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">ANTÔNIO ROBERTO SOARES</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image3" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/141390.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label19" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label9" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label10" runat="server" Text="PV" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label11" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label12" runat="server" Text="MG" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.camara.gov.br/internet/deputado/dep_Detalhe.asp?id=525549"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">ARNALDO FARIA DE SÁ</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image4" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/73434.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label20" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label13" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label14" runat="server" Text="PTB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label15" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text="SP" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=73434"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">ARNON BEZERRA</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image12" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/74291.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label56" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label57" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label58" runat="server" Text="PTB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label59" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label60" runat="server" Text="CE" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="http://www.camara.gov.br/internet/deputado/dep_Detalhe.asp?id=520515"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">ASSIS CARVALHO</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image5" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/159237.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label21" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label22" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label23" runat="server" Text="PT" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label24" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label25" runat="server" Text="PI" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=159237"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">CLEBER VERDE</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image6" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/141408.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label26" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label27" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label28" runat="server" Text="PRB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label29" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label30" runat="server" Text="MA" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=141408"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">DOMINGOS SÁVIO</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image7" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/160758.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label31" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label32" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label33" runat="server" Text="PSDB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label34" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label35" runat="server" Text="MG" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=160758"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">FÉLIX MENDONÇA JÚNIOR</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image9" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/160666.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label41" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label42" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label43" runat="server" Text="PDT" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label44" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label45" runat="server" Text="BA" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=160666"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">GIM ARGELLO</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image10" runat="server" ImageUrl="~/Figuras/Parlamentares/SENADOR/bemv4776.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label46" runat="server" Text="Senador"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label47" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label48" runat="server" Text="PTB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label49" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label50" runat="server" Text="DF" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://www.senado.leg.br/senadores/dinamico/paginst/senador4776a.asp"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">JAIME MARTINS</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image11" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/74665.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label51" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label52" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label53" runat="server" Text="PSD" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label54" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label55" runat="server" Text="MG" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=74665"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">LAEL VARELLA</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image13" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/74742.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label61" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label62" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label63" runat="server" Text="DEM" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label64" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label65" runat="server" Text="MG" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=74742"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">MANDETTA</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image14" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/160633.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label66" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label67" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label68" runat="server" Text="DEM" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label69" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label70" runat="server" Text="MS" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="http://www.camara.gov.br/internet/deputado/dep_Detalhe.asp?id=530084"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">MANOEL SALVIANO</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image15" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/74456.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label71" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label72" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label73" runat="server" Text="PSD" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label74" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label75" runat="server" Text="CE" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=74456"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">MARCELO MATOS</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image16" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/76287.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label76" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label77" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label78" runat="server" Text="PDT" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label79" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label80" runat="server" Text="RJ" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=76287"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">PAULO BAUER</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image17" runat="server" ImageUrl="~/Figuras/Parlamentares/SENADOR/bemv3741.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label81" runat="server" Text="Senador"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label82" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label83" runat="server" Text="PSDB" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label84" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label85" runat="server" Text="SC" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="http://www.senado.leg.br/senadores/dinamico/paginst/senador3741a.asp"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">RICARDO BERZOINI</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image18" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/74793.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label86" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label87" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label88" runat="server" Text="PT" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label89" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label90" runat="server" Text="SP" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="http://www.camara.gov.br/internet/deputado/dep_Detalhe.asp?id=523547"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">RUBENS OTONI</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image19" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/74371.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label91" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label92" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label93" runat="server" Text="PT" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label94" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label95" runat="server" Text="GO" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="http://www.camara.gov.br/internet/deputado/Dep_Detalhe.asp?id=520760"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">TONINHO PINHEIRO</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image20" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/160611.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label96" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label97" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label98" runat="server" Text="PP" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label99" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label100" runat="server" Text="MG" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=160611"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">ZOINHO</div>
                            <div class="panel-body">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image CssClass="img-thumbnail" ID="Image21" runat="server" ImageUrl="~/Figuras/Parlamentares/DEPFEDERAL/160625.jpg"
                                                Height="152px" Width="114px" Style="margin-right: 10px" />
                                        </td>
                                        <td valign="top">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="Label101" runat="server" Text="Deputado Federal"
                                                            CssClass="fonte1"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label102" runat="server" Text="Partido:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label103" runat="server" Text="PR" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label104" runat="server" Text="UF:" CssClass="fonte1"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label105" runat="server" Text="RJ" CssClass="fonte0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="http://www.camara.gov.br/internet/Deputado/dep_Detalhe.asp?id=160625"
                                                            Target="_blank" CssClass="fonte0">site</asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="tab-pane" id="tabs-2">
                <p class="text-center">O Dossiê 2 será divulgado em breve.</p>
            </div>
        </div>
    </div>
</asp:Content>
