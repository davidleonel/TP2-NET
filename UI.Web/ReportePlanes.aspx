<%@ Page Title="ReportePlanes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportePlanes.aspx.cs" Inherits="UI.Web.ReportePlanes" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <asp:Label ID="incorrectoLabel" runat="server" Text="Usted no tiene permiso Para estar aqui." Visible="false"></asp:Label>

    <asp:Panel ID="OpcionesReportes" runat="server">

        <rsweb:ReportViewer ID="PlanesReportViewer1" runat="server" Height="413px" Width="874px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="InformePlanes.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="InformePlanes" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="UI.Web.TP2DataSetPlanesTableAdapters.planesTableAdapter"></asp:ObjectDataSource>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Volver</asp:LinkButton>
        <br />
        <asp:LinkButton ID="cancelarLinkButton2" runat="server" OnClick="cancelarLinkButton2_Click" Visible="false">Volver</asp:LinkButton>
    </asp:Panel>
</asp:Content>