<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroNota.aspx.cs" Inherits="UI.Web.RegNotaInscipcion" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>

    <asp:Panel ID="CursoNotagridPanel" runat="server" Visible="false">
           <asp:Label ID="cursoLabel" runat="server" Text="Selecione Curso:"></asp:Label>
        <asp:GridView ID="CursoNotagridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="curso_SelectedIndexChanged" Width="554px">
            <Columns>
                <asp:BoundField HeaderText="ID Curso" DataField="Id" />
                <asp:BoundField HeaderText="ID Materia" DataField="IdMateria" />
                <asp:BoundField HeaderText="ID Comision" DataField="IdComision" />
                <asp:BoundField HeaderText="Anio Calendario" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
           <br />
    </asp:Panel>
      


    <asp:Panel ID="AlumnoNotagridPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
    </asp:Panel>

     <asp:Panel ID="RegNotaInscipcionsgridPanel" runat="server">
           <asp:Label ID="NotaLabel" runat="server" Text="Alumnos:"></asp:Label>
                <asp:GridView ID="RegNotagridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="RegNota_SelectedIndexChanged" Width="488px">
                    <Columns>
                        <asp:BoundField HeaderText="ID Alumno" DataField="Id" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                        <asp:BoundField HeaderText="ID Plan" DataField="IdPlan" />
                        
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

