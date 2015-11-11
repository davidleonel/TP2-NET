using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace UI.Web
{
    public partial class Menu : System.Web.UI.Page
    {


        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
            set { Session["UsuarioActual"] = value; }
        }

        private PersonaNegocio _PersonaNegActual;

        public PersonaNegocio PersonaNegActual
        {
            get
            {
                if (_PersonaNegActual == null)
                {
                    _PersonaNegActual = new PersonaNegocio();
                }
                return _PersonaNegActual;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (UsuarioActual == null)
            {
                this.Page.Response.Redirect("~/Login.aspx");
            }
            else
            {
                Persona p = PersonaNegActual.GetOne(UsuarioActual.IdPersona);
                this.bienvenidolabel.Visible = true;
                this.bienvenidolabel.Text = ("Bienvenido: " + p.Nombre + " " + p.Apellido);
                switch (p.TipoPersona)
                {
                    case Persona.TiposPersona.Administrador:
                        this.menuAdminPanel.Visible = true;
                       
                        break;
                    case Persona.TiposPersona.Alumno:
                        this.menuAlumnoPanel.Visible = true;

                        break;
                    case Persona.TiposPersona.Docente:
                        this.menuDocentePanel.Visible = true;

                        break;
                    default:
                        break;
                }
                
            }


        }

        protected void ABMPersonas_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/Personas.aspx");
        }

        protected void ABMUsuarios_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/Usuarios.aspx");
        }

        protected void ABMEspecialidades_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/Especialidades.aspx");
        }

        protected void ABMCursos_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/Cursos.aspx");
        }

        protected void ABMComisiones_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/Comisiones.aspx");
        }

        protected void ABMMaterias_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/Materias.aspx");
        }

        protected void ABMPlanes_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/Planes.aspx");
        }

        protected void InscripcionAlumnos_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/InscribirAlumno.aspx");
        }

        protected void InscripcionDocentes_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/InscribirDocente.aspx");
        }

        protected void RegistroNotas_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/RegistrarNota.aspx");
        }
      

        protected void InscripcionDocente_Click(object sender, EventArgs e)
        {

            Page.Response.Redirect("~/InscripcionDocente.aspx");
        }

        protected void RegistroNotasDocente_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/RegistrarNotaDocente.aspx");
        }

        protected void InscripcionAlumno_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/InscripcionAlumno.aspx");
        }

        protected void Reportes_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Reportes.aspx");
        }

        protected void Salir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Page.Response.Redirect("~/Login.aspx");
        }
    }
}