<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditoriaPF.aspx.cs" Inherits="AuditoriaParlamentar.AuditoriaPF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#dialog-message").dialog({
                modal: true,
                autoOpen: false,
                height: 500,
                width: 800,
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
        });

        function ExibeOqueProcurar() {
            $("#dialog-message").dialog("open");
        }

        function Denunciar() {
            window.parent.TabDenuncia(
                    '<%= LabelCNPJ.Text %>',
                    '<%= LabelRazaoSocial.Text %>');
        }

        function Doacoes() {
            window.parent.TabDoacoes(
                    '<%= LabelCNPJ.Text %>',
                    '<%= LabelRazaoSocial.Text %>');
        }

    </script>
</head>
<body>
    <div class="modal fade" id="dvQueProcurar" title="Auditar" style="display: none" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel">O que Procurar?</h4>
                </div>
                <div class="modal-body">
                    <p>
                        A primeira coisa que você pode fazer para começar a investigar este fornecedor é
                        analisar seu endereço. Empresas localizadas em áreas residênciais ou em regiões
                        pobres da cidade podem ser consideradas estranhas. Você pode utilizar o Google Maps
                        e o Street View (se estiver disponível) para avaliar a localização da empresa. Você
                        poderá inclusive visitar a região se tiver condições.
                    </p>
                    <p>
                        Outra opção é pesquisa pela internet se a empresa possui uma página na internet
                        e se ela realmente fornece o serviço prestado ao parlamentar. Empresas sérias não
                        se escondem e são facilmente localizadas.
                    </p>
                    <p>
                        Para descobrir os donos da empresa você poderá ir até a Junta Comercial da cidade
                        onde a empresa está localizada para solicitar as informações. Será uma informação
                        muito importante porque será possível investigar se é algum conhecido do Parlamentar.
                        A Junta Comercial irá cobrar uma taxa para fornecer esta informação.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>
    <br />
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <a class="btn btn-primary btn-sm" data-toggle="modal" data-target="#dvQueProcurar">O Que Procurar?</a>
                    <asp:Button ID="ButtonPesquisa" runat="server" Text="Pesquisar Pessoa no Google" CssClass="btn btn-default btn-sm" />
                    <asp:Button ID="ButtonListarDocumentos" runat="server" Text="Solicitar/Listar Documentos" CssClass="btn btn-default btn-sm" />
                    <asp:Button ID="ButtonListarDeputados" runat="server" Text="Listar Parlamentares" CssClass="btn btn-default btn-sm" />
                    <asp:Button ID="ButtonDenunciar" runat="server" Text="Denunciar" CssClass="btn btn-success btn-sm" />
                    <asp:Button ID="ButtonListarDoacoes" runat="server" Text="Listar Doações Eleitorais" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
            <asp:Panel ID="PanelExisteDenuncia" runat="server" Visible="False" CssClass="row">
                <div class="col-md-12 text-center">
                    <div class="alert alert-warning" runat="server" id="dvDenuncias"></div>
                </div>
                <div class="col-md-12 text-center">
                    <asp:GridView ID="GridViewDenuncias" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                        UseAccessibleHeader="true" EmptyDataText="Nenhuma denuncia foi incluída" EmptyDataRowStyle-HorizontalAlign="Center">
                        <RowStyle CssClass="cursor-pointer" />
                    </asp:GridView>
                </div>
            </asp:Panel>
            <hr />
            <div class="row">
                <div class="col-md-12 text-center">
                    <h4>Pessoa Fisica</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label class="control-label">CPF</label>
                    <asp:Label ID="LabelCNPJ" runat="server" Text="Label" Font-Bold="True" CssClass="show"></asp:Label>
                </div>
                <div class="col-md-6">
                    <label class="control-label">Nome</label>
                    <asp:Label ID="LabelRazaoSocial" runat="server" Text="Label" CssClass="show"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
