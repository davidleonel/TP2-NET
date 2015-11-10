<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteCursos1.aspx.cs" Inherits="UI.Web.ReporteCursos1" %>


<asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportEmbeddedResource="UI.Web.Report1.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
