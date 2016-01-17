<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Revisao.aspx.cs" Inherits="AuditoriaParlamentar.Revisao" %>

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
    <div style="height: 100%; margin-right: 5px; margin-left: 5px;">
        <iframe id="frame" src="PesquisaAbas.aspx?op=R" frameborder="0" width="100%" height="100%"></iframe>
    </div>
</asp:Content>
