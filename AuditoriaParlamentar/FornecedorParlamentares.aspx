<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FornecedorParlamentares.aspx.cs"
    Inherits="AuditoriaParlamentar.FornecedorParlamentares" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/jquery-1.11.3.min.js"></script>
    <script type="text/javascript" src="<%= ResolveClientUrl("~/") %>assets/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container-fluid">
        <form id="form2" runat="server">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">CNPJ/CPF:</label>
                        <span runat="server" id="lblCNPJ" class="control-label show"></span>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Razão Social:</label>
                        <span runat="server" id="lblrazaoSocial" class="control-label show"></span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                        <asp:GridView ID="GridViewResultado" runat="server" AllowSorting="True" UseAccessibleHeader="true" OnRowDataBound="GridViewResultado_RowDataBound"
                            CssClass="table table-hover table-striped" GridLines="None" ShowFooter="True" OnSorting="GridViewResultado_Sorting">
                            <Columns>
                            </Columns>
                            <RowStyle CssClass="cursor-pointer" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
