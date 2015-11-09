<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarNotaDocente.aspx.cs" Inherits="UI.Web.RegistrarNotaDocente" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
        <asp:Label ID="ABMLabel" runat="server" Text="Registro de Nota"></asp:Label>
        <br />
        <br />
        <asp:Label ID="SeleccionLabel" runat="server" Text="Seleccione Curso"></asp:Label>
        <br />
        <br />
        <asp:Label ID="incorrectoLabel" runat="server" Visible="false" Text="No tiene permisos para interactuar en esta página"></asp:Label>
        <asp:Panel ID="ElegirCursogridPanel" runat="server">
            
           
        
                 <asp:GridView ID="CursosgridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Turquoise"
                    SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="curso_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="ID Curso" DataField="IdCurso" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>

        </asp:Panel>

        <br />


    <asp:Panel ID="gridActionsPanel" runat="server" Visible="false">
        <asp:LinkButton ID="ElegirAlumnaLinkButton" runat="server" OnClick="ElegirAlumnoLinkButton_Click" >Elegir Alumno</asp:LinkButton>
    </asp:Panel>
        <br />
        <br />
    
        <asp:GridView ID="AlumnosgridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Turquoise"
            SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="alumno_SelectedIndexChanged" Visible="false">
            <Columns>
                <asp:BoundField HeaderText="ID Alumno" DataField="IdAlumno" />
                <asp:BoundField HeaderText="Condicion" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />     
            </Columns>
        </asp:GridView>

       <br />
        <br />
            <asp:Panel ID="gridActionsPanel2" runat="server" Visible="false">
                <asp:LinkButton ID="cambiarNotaLinkButton" runat="server" OnClick="cambiarNotaLinkButton_Click" >Cambiar Nota</asp:LinkButton>
            </asp:Panel>
        <br />

            <asp:Panel ID="PersonaPanel" Visible="false" runat="server">
        
                    <asp:Label ID="idPersonaLabel" runat="server" Text="ID Persona: "></asp:Label>
                    <asp:TextBox ID="idPersonaTextBox" runat="server" Text="" Enabled="false"></asp:TextBox> 
                    <br />

                    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
                    <asp:TextBox ID="nombreTextBox" runat="server" Text="" Enabled="false"></asp:TextBox>
                    <br />

                     <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
                    <asp:TextBox ID="apellidoTextBox" runat="server" Text="" Enabled="false"></asp:TextBox>
                    <br />

                    <asp:Label ID="legajoLabel" runat="server" Text="Legajo: "></asp:Label>
                    <asp:TextBox ID="legajoTextBox" runat="server" Text="" Enabled="false"></asp:TextBox> 
                    <br />

                    <asp:Label ID="notaLabel" runat="server" Text="Nota: "></asp:Label>
                    <asp:TextBox ID="notaTextBox" runat="server" Text=""></asp:TextBox> 
                    <br />


                    <br />


            </asp:Panel>
    
        
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>

    </div>

        </asp:Content>

