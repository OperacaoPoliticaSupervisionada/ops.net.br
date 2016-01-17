<%@ Page Language="C#" ViewStateMode="Enabled" AutoEventWireup="true" CodeBehind="PesquisaPrincipal.aspx.cs"
    Inherits="AuditoriaParlamentar.PesquisaPrincipal" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/assets/css/bootstrap-select.min.css" rel="stylesheet" />
    <link href="~/assets/css/style.css" rel="stylesheet" />
    <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/bootstrap-select.min.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            //var $frame = $('#frame');
            //var heightTop = $frame.offset().top;
            //$frame.height(window.innerHeight - heightTop - 5);

            ////And if the outer div has no set specific height set.. 
            //$(window).resize(function () {
            //   $frame.css('height', window.innerHeight - heightTop - 5);
            //});

            $('#<%= DropDownListPerido.ClientID %>').change(function(){
                if($(this).val() == 'Informar Período'){ 
                    $('.periodo').show();
                } else { 
                    $('.periodo').hide();
                }
            }).trigger('change');

            $('.selectpicker').selectpicker({
                width: '100%'
            });
        });

        function NovoNivel(value, descricao) {
            var desc = $('#<%= DropDownListAgrupamento.ClientID %>').val().substring(4).toUpperCase() + ": " + descricao;

            window.parent.TabPesquisa(
                value,
                desc,
                $("#<%= DropDownListGrupo.ClientID %>").val(),
                $("#<%= DropDownListAgrupamento.ClientID %>").val(),
                $("#<%= CheckBoxSepararMes.ClientID %>").is(':checked'),
                $("#<%= DropDownListPerido.ClientID %>").val(),
                $("#<%= DropDownListAnoInicial.ClientID %>").val(),
                $("#<%= DropDownListMesInicial.ClientID %>").val(),
                $("#<%= DropDownListAnoFinal.ClientID %>").val(),
                $("#<%= DropDownListMesFinal.ClientID %>").val(),
                $("#<%= DropDownListParlamentar.ClientID %>").val(),
                $("#<%= DropDownListDespesa.ClientID %>").val(),
                $("#<%= DropDownListFornecedor.ClientID %>").val(),
                $("#<%= DropDownListUF.ClientID %>").val(),
                $("#<%= DropDownListPartido.ClientID %>").val(),
                '',
                ''
            );
        }

        function UpdateGridView(row, column, value) {
            var grd = document.getElementById('<%= GridViewResultado.ClientID %>');
            grd.rows[row].cells[column].textContent = value;
        }

    </script>
    <style type="text/css">
        label { margin-bottom: 2px; }

        .form-group { margin-bottom: 10px; }

        .watermark { background-image: url(figuras/logo_opaca.png); background-repeat: no-repeat; position: fixed; bottom: 5px; right: 5px; width: 600px; height: 365px; z-index: -1; }
    </style>
</head>
<body>
    <form id="form_auditoria" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

        <div id="conteudo" class="container-fluid" style="overflow:auto">
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Cargo</label>
                        <asp:DropDownList ID="DropDownListGrupo" runat="server" Width="100%"
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownListGrupo_SelectedIndexChanged" CssClass="form-control input-sm">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Período</label>
                        <asp:DropDownList ID="DropDownListPerido" runat="server" Width="100%" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="form-group periodo">
                        <label>Inicial</label>
                        <div class="row">
                            <div class="col-xs-6">
                                <asp:DropDownList ID="DropDownListMesInicial" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                            </div>
                            <div class="col-xs-6">
                                <asp:DropDownList ID="DropDownListAnoInicial" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group periodo">
                        <label>Final</label>
                        <div class="row">
                            <div class="col-xs-6">
                                <asp:DropDownList ID="DropDownListMesFinal" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                            </div>
                            <div class="col-xs-6">
                                <asp:DropDownList ID="DropDownListAnoFinal" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Parlamentares</label>
                        <asp:ListBox ID="DropDownListParlamentar" runat="server" CssClass="form-control input-sm selectpicker" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                    <div class="form-group">
                        <label>Despesas</label>
                        <asp:ListBox ID="DropDownListDespesa" runat="server" CssClass="form-control input-sm selectpicker" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                    <div class="form-group">
                        <label>Fornecedores</label>
                        <asp:ListBox ID="DropDownListFornecedor" runat="server" CssClass="form-control input-sm selectpicker" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                    <div class="form-group">
                        <label>UF (Parlamentar)</label>
                        <asp:ListBox ID="DropDownListUF" runat="server" CssClass="form-control input-sm selectpicker" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Partido</label>
                        <asp:ListBox ID="DropDownListPartido" runat="server" CssClass="form-control input-sm selectpicker" SelectionMode="Multiple"></asp:ListBox>
                    </div>
                    <div class="form-group">
                        <label>Agrupar</label>
                        <asp:DropDownList ID="DropDownListAgrupamento" runat="server" Width="100%" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="CheckBoxSepararMes" runat="server" />
                            Exibir mês a mês?
                        </label>
                    </div>
                    <asp:Button ID="ButtonPesquisar" runat="server" OnClick="ButtonPesquisar_Click" Text="Clique para Pesquisar" CssClass="btn btn-success btn-block btn-sm" UseSubmitBehavior="false" />
                    <asp:Button ID="ButtonShare" runat="server" OnClick="ButtonShare_Click" Text="Compartilhar" CssClass="btn btn-default btn-block" Visible="false" />
                    <br />
                    <a href="javascript:void(0);" class="text-center" style="display: block;" onclick="__doPostBack('ButtonExportar_Click', '');">Exportar Consulta em CSV</a>
                    <asp:UpdatePanel ID="UpdatePanelUltimaAtualizacao" runat="server"
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <center>
                                <asp:Label ID="LabelUltimaAtualizacao" runat="server" Text="Última Atualização:"></asp:Label>
                            </center>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DropDownListGrupo" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="col-md-12">
                    <hr />
                    <div id="LabelMaximo" runat="server" class="alert alert-warning" visible="false">
                        O resultado está limitado a 1.000 registros para evitar sobrecarga.
                    </div>
                    <asp:GridView ID="GridViewResultado" runat="server" AllowSorting="True"
                        OnRowDataBound="GridViewResultado_RowDataBound" OnSorting="GridViewResultado_Sorting"
                        ShowFooter="True" ViewStateMode="Disabled" UseAccessibleHeader="true"
                        CssClass="table table-hover table-striped table-responsive" GridLines="None" EnableViewState="false">
                        <Columns>
                            <asp:TemplateField>
                                <FooterTemplate>
                                    <asp:Label ID="LabelTotal" runat="server" Text="Total Geral:"></asp:Label>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <input value="Detalhar" type="button" onclick="NovoNivel('<%# Eval("codigo") %>    ','<%# Eval("[1]") %>    ')" class="btn btn-primary btn-sm" />
                                    <asp:Button ID="ButtonAuditar" runat="server" Text="Auditar" CssClass="btn btn-default btn-sm" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="cursor-pointer" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
