<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InscribirDocente.aspx.cs" Inherits="UI.Web.DocenteInscipcion" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
      
         <asp:Panel ID="DocenteInscipcionsgridPanel" runat="server">
           <asp:Label ID="incorrectoLabel" runat="server" Visible="false" Text="No tiene permisos para interactuar en esta página"></asp:Label>
           <asp:Label ID="docInscLabel" runat="server" Text="Selecione Docente a inscribir:"></asp:Label>
                <asp:GridView ID="DocenteInscipciongridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="Docente_SelectedIndexChanged" Width="488px">
                    <Columns>
                        <asp:BoundField HeaderText="ID Docente" DataField="Id" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                        <asp:BoundField HeaderText="ID Plan" DataField="IdPlan" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />               
                    </Columns>
                 </asp:GridView>
          </asp:Panel>

    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="inscribirLinkButton" runat="server" OnClick="inscribirLinkButton_Click" >Inscribir</asp:LinkButton>
    </asp:Panel>

    

       
    <asp:Panel ID="CursoInscipciongridPanel" runat="server" Visible="false">
           <asp:Label ID="curInscLabel" runat="server" Text="Selecione Curso a inscribir el Docente:"></asp:Label>
        <asp:GridView ID="CursoInscipciongridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black"
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
           <asp:Label ID="cargoLabel" runat="server" Text="Cargo:"></asp:Label>
           <asp:TextBox ID="cargoTextBox" runat="server" Width="209px"></asp:TextBox>
    </asp:Panel>

   
       
    <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>

    </div>

        </asp:Content>

