﻿<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="UI.Web.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
   <asp:Panel ID="OpcionesReportes" runat="server">
    <asp:HyperLink ID="rpCursos" runat="server" NavigateUrl="~/ReporteCursos.aspx">Cursos</asp:HyperLink>
    <br />
    <asp:HyperLink ID="rpPlanes" runat="server" NavigateUrl="~/ReportePlanes.aspx">Planes</asp:HyperLink>
    <br />
   </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Volver a Menu</asp:LinkButton>
    </asp:Panel>
</asp:Content>