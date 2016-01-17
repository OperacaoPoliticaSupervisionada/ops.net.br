<%@ Page Title="OPS - Operação Política Supervisionada" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Membros.aspx.cs" Inherits="AuditoriaParlamentar.Membros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <fieldset>
            <legend>Membros da O.P.S.</legend>
            <div class="row">
                <div class="col-md-5 col-xs-12">
                    <object classid="clsid:D27CDB6E-AE6D-11CF-96B8-444553540000" id="ShockwaveFlash1"
                        width="399" height="410" align="left">
                        <!-- Aqui vem Todos os Paramentros --- Ecurtei para efeito de exemplo -->
                        <param name="Movie" value="mapa-brasil.swf" />
                        <param name="FlashVars" value="AC=Membros.aspx?UF=AC&AL=Membros.aspx?UF=AL&AP=Membros.aspx?UF=AP&AM=Membros.aspx?UF=AM&BA=Membros.aspx?UF=BA&CE=Membros.aspx?UF=CE&DF=Membros.aspx?UF=DF&ES=Membros.aspx?UF=ES&GO=Membros.aspx?UF=GO&MA=Membros.aspx?UF=MA&MG=Membros.aspx?UF=MG&MT=Membros.aspx?UF=MT&MS=Membros.aspx?UF=MS&PA=Membros.aspx?UF=PA&PB=Membros.aspx?UF=PB&PR=Membros.aspx?UF=PR&PE=Membros.aspx?UF=PE&PI=Membros.aspx?UF=PI&RJ=Membros.aspx?UF=RJ&RN=Membros.aspx?UF=RN&RO=Membros.aspx?UF=RO&RR=Membros.aspx?UF=RR&RS=Membros.aspx?UF=RS&SC=Membros.aspx?UF=SC&SE=Membros.aspx?UF=SE&SP=Membros.aspx?UF=SP&TO=Membros.aspx?UF=TO" />
                        <!-- Aqui vem Todos os Paramentros --- Ecurtei para efeito de exemplo -->
                        <!-- O código abaixo que é usado no FireFox -->
                        <embed src="mapa-brasil.swf?AC=Membros.aspx?UF=AC&AL=Membros.aspx?UF=AL&AP=Membros.aspx?UF=AP&AM=Membros.aspx?UF=AM&BA=Membros.aspx?UF=BA&CE=Membros.aspx?UF=CE&DF=Membros.aspx?UF=DF&ES=Membros.aspx?UF=ES&GO=Membros.aspx?UF=GO&MA=Membros.aspx?UF=MA&MG=Membros.aspx?UF=MG&MT=Membros.aspx?UF=MT&MS=Membros.aspx?UF=MS&PA=Membros.aspx?UF=PA&PB=Membros.aspx?UF=PB&PR=Membros.aspx?UF=PR&PE=Membros.aspx?UF=PE&PI=Membros.aspx?UF=PI&RJ=Membros.aspx?UF=RJ&RN=Membros.aspx?UF=RN&RO=Membros.aspx?UF=RO&RR=Membros.aspx?UF=RR&RS=Membros.aspx?UF=RS&SC=Membros.aspx?UF=SC&SE=Membros.aspx?UF=SE&SP=Membros.aspx?UF=SP&TO=Membros.aspx?UF=TO"
                            width="399" height="410" devicefont="0" profileport="0">
                    </object>
                </div>
                <div class="col-md-7 col-xs-12">
                    <div class="table-responsive">
                        <asp:GridView ID="GridViewMembros" runat="server" UseAccessibleHeader="true"
                            CssClass="table table-hover table-striped" GridLines="None"
                            EmptyDataText="Não há nenhum membro cadastrado neste estado." EmptyDataRowStyle-HorizontalAlign="Center">
                            <RowStyle CssClass="cursor-pointer" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
