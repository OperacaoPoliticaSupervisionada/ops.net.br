<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CidadesPendenciaGrid.aspx.cs"
   Inherits="AuditoriaParlamentar.CidadesPendenciaGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title></title>
   <link href="~/assets/css/bootstrap.min.css" rel="stylesheet" />
   <script type="text/javascript" src="assets/js/jquery-1.11.3.min.js"></script>
   <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
   <style type="text/css">
      a:link, a:visited { color: #034af3; }

      .fonte2 { text-indent: 40px; }
   </style>
</head>
<body>
   <form id="form1" runat="server">
      <div class="panel panel-default">
         <div class="panel-body">
            <p class='fonte2 text-justify'>
               Precisamos da sua ajuda para levantar informações nas cidades relacionadas abaixo.
                    Na maioria das vezes precisamos de uma fotografia atualizada de algum endereço suspeito.
                    Em alguns poucos casos precisamos de documentos na junta comercial. Se você tiver
                    disponibilidade e for maior de 18 anos entre em contado no email <a href="mailto:luciobig@ops.net.br">luciobig@ops.net.br</a> para receber as instruções.
            </p>
            <p class="text-center">
               <asp:Button ID="ButtonGerenciar" runat="server" Text="Gerenciar" CssClass="btn btn-success" OnClick="ButtonGerenciar_Click" />
            </p>
         </div>
      </div>
      <div class="table-responsive">
         <asp:GridView ID="GridViewCidades" runat="server" CssClass="table table-hover table-striped" GridLines="None"
            AutoGenerateColumns="False" UseAccessibleHeader="true"
            EmptyDataText="Nenhuma pendência foi incluída" EmptyDataRowStyle-HorizontalAlign="Center">
            <Columns>
               <asp:BoundField DataField="Uf" HeaderText="UF" />
               <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
               <asp:BoundField DataField="pendencias" HeaderText="Qtde. Pendências" />
            </Columns>
            <RowStyle CssClass="cursor-pointer" />
         </asp:GridView>
      </div>
   </form>
</body>
</html>
