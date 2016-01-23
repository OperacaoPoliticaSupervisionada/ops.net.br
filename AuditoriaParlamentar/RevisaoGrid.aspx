<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevisaoGrid.aspx.cs" Inherits="AuditoriaParlamentar.RevisaoGrid" %>

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
        <div id="container" class="container-fluid">
            <div class="text-center">
                <label class="checkbox-inline">
                    <asp:CheckBox ID="CheckBoxNaoLidas" runat="server" Checked="True" Text="Mensagens não Lidas" />
                </label>
                <label class="checkbox-inline">
                    <asp:CheckBox ID="CheckBoxAguardando" runat="server" Checked="True" Text="Aguardando Revisão" />
                </label>
                <label class="checkbox-inline">
                    <asp:CheckBox ID="CheckBoxPendenteInformacao" runat="server" Text="Pendente Informação" Checked="True" />
                </label>
                <label class="checkbox-inline">
                    <asp:CheckBox ID="CheckBoxDuvidoso" runat="server" Text="Duvidoso" Checked="True" />
                </label>
                <label class="checkbox-inline">
                    <asp:CheckBox ID="CheckBoxDossie" runat="server" Text="Dossiê" />
                </label>
                <label class="checkbox-inline">
                    <asp:CheckBox ID="CheckBoxRepetido" runat="server" Text="Repetido" />
                </label>
                <label class="checkbox-inline">
                    <asp:CheckBox ID="CheckBoxNaoProcede" runat="server" Text="Não Procede" />
                </label>
            </div>
            <br />
            <div class="text-center">
                <asp:Button ID="ButtonEnviar" runat="server" OnClick="ButtonEnviar_Click" Text="Filtrar"
                    ValidationGroup="DenunciaGroup" CssClass="btn btn-success btn-sm" />
            </div>
            <br />
            <asp:GridView ID="GridViewRevisao" runat="server" AllowSorting="false"
                UseAccessibleHeader="true" OnRowCommand="GridViewDenuncias_RowCommand" OnRowDataBound="GridViewDenuncias_RowDataBound"
                CssClass="table table-hover table-striped" GridLines="None" ShowFooter="True"
                EmptyDataText="Nenhum denúncia encontrada para os filtros informados!" EmptyDataRowStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:CommandField SelectText="Detalhes" ShowSelectButton="True" />
                    <asp:ImageField DataImageUrlField="nova_msg" DataImageUrlFormatString="~/Figuras/{0}">
                    </asp:ImageField>
                </Columns>
                <RowStyle CssClass="cursor-pointer" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
