<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CidadesPendencia.aspx.cs" Inherits="AuditoriaParlamentar.CidadesPendencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(function () {
            //$('#frame').get(0).contentWindow
            var $frame = $('#frame');
            var heightTop = $frame.offset().top;
            $frame.height(window.innerHeight - heightTop);

            //And if the outer div has no set specific height set.. 
            $(window).resize(function () {
                $frame.css('height', window.innerHeight - heightTop);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <iframe id="frame" src="PesquisaAbas.aspx?op=C" frameborder="0" width="100%" height="100%"></iframe>
    </div>
</asp:Content>
