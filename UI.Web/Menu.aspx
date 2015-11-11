<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="UI.Web.Menu" MasterPageFile="~/Site.Master" %>


    <asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" RunAt="server" >
    
    <div>
     
        <asp:Label ID="bienvenidolabel" runat="server" Text="" Visible="false"></asp:Label>
        <br />
        <br />
        <asp:Label ID="MenuLabel" runat="server" Text="MENU"></asp:Label> <br />
        <asp:Panel ID="menuAdminPanel" Visible="false" runat="server">

            <asp:LinkButton ID="ABMPersonas" runat="server" OnClick="ABMPersonas_Click">ABM Personas</asp:LinkButton>
            <br />
            <asp:LinkButton ID="ABMUsuarios" runat="server" OnClick="ABMUsuarios_Click">ABM Usuarios</asp:LinkButton>
            <br />
            <asp:LinkButton ID="ABMEspecialidades" runat="server" OnClick="ABMEspecialidades_Click">ABM Especialidades</asp:LinkButton>
            <br />
            <asp:LinkButton ID="ABMCursos" runat="server" OnClick="ABMCursos_Click">ABM Cursos</asp:LinkButton>
            <br />
            <asp:LinkButton ID="ABMComisiones" runat="server" OnClick="ABMComisiones_Click">ABM Comisiones</asp:LinkButton>
            <br />
            <asp:LinkButton ID="ABMMaterias" runat="server" OnClick="ABMMaterias_Click">ABM Materias</asp:LinkButton>
            <br />
            <asp:LinkButton ID="ABMPlanes" runat="server" OnClick="ABMPlanes_Click">ABM Planes</asp:LinkButton>
            <br />
            <asp:LinkButton ID="InscripcionAlumnos" runat="server" OnClick="InscripcionAlumnos_Click">Inscripcion de Alumnos</asp:LinkButton>
            <br />
            <asp:LinkButton ID="InscripcionDocentes" runat="server" OnClick="InscripcionDocentes_Click">Inscripcion de Docentes</asp:LinkButton>
            <br />
            <asp:LinkButton ID="RegistroNotas" runat="server" OnClick="RegistroNotas_Click">Registro de Notas</asp:LinkButton>
            <br />
            <asp:LinkButton ID="Reportes" runat="server" OnClick="Reportes_Click">Reportes</asp:LinkButton>
            <br />
            <br />
            <br />
            <br />
            <asp:LinkButton ID="SalirAdmin" runat="server" OnClick="Salir_Click">Cerrar Sesión</asp:LinkButton>


        </asp:Panel>

         <asp:Panel ID="menuDocentePanel" Visible="false" runat="server">

            <asp:LinkButton ID="InscripcionDocente" runat="server" OnClick="InscripcionDocente_Click">Inscripcion de Docentes</asp:LinkButton> <br />
            <asp:LinkButton ID="RegistroNotasDocente" runat="server" OnClick="RegistroNotasDocente_Click">Registro de Notas</asp:LinkButton> <br />
            <br />
            <br />
            <br />
            <br />
            <asp:LinkButton ID="SalirDoc" runat="server" OnClick="Salir_Click">Cerrar Sesión</asp:LinkButton>
        
        </asp:Panel>

         <asp:Panel ID="menuAlumnoPanel" Visible="false" runat="server">
           

            <asp:LinkButton ID="InscripcionAlumno" runat="server" OnClick="InscripcionAlumno_Click">Inscripcion de Alumnos</asp:LinkButton> <br />
            <br />
            <br />
            <br />
            <br />
            <asp:LinkButton ID="SalirAlum" runat="server" OnClick="Salir_Click">Cerrar Sesión</asp:LinkButton>
        </asp:Panel>

    </div>

        </asp:Content>

