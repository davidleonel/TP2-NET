<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InscripcionAlumno.aspx.cs" Inherits="UI.Web.InscripcionAlumno" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
       <asp:Panel ID="InscripcionAlumnogridPanel" runat="server">
            <asp:Label ID="incorrectoLabel" runat="server" Visible="false" Text="No tiene permisos para interactuar en esta página"></asp:Label>
        <asp:GridView ID="InscripcionAlumnogridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="ID Curso" DataField="Id" />
                <asp:BoundField HeaderText="ID Materia" DataField="IdMateria" />
                <asp:BoundField HeaderText="ID Comision" DataField="IdComision" />
                <asp:BoundField HeaderText="Anio Calendario" DataField="AnioCalendario" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
      
    <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>

    </div>

        </asp:Content>

