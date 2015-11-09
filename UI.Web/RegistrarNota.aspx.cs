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
    public partial class RegistrarNota : System.Web.UI.Page
    {
        #region Propiedades

        PersonaNegocio _PerNeg;
        private PersonaNegocio PerNeg
        {
            get
            {
                if (_PerNeg == null)
                {
                    _PerNeg = new PersonaNegocio();
                }
                return _PerNeg;
            }
        }

        private Persona PersonaActual
        {
            get;
            set;
        }

        AlumnoInscripcionNegocio _AluInscNeg;
        private AlumnoInscripcionNegocio AluInscNeg
        {
            get
            {
                if (_AluInscNeg == null)
                {
                    _AluInscNeg = new AlumnoInscripcionNegocio();
                }
                return _AluInscNeg;
            }
        }

        private AlumnoInscripcion AluInscActual
        {
            get;
            set;
        }
   

        CursoNegocio _CurNeg;
        private CursoNegocio CurNeg
        {
            get
            {
                if (_CurNeg == null)
                {
                    _CurNeg = new CursoNegocio();
                }
                return _CurNeg;
            }
        }
        

        private Curso CursoActual
        {
            get;
            set;
        }

        private int SelectedIDCurso
        {
            get
            {
                if (this.ViewState["SelectedIDCurso"] != null)
                {
                    return (int)this.ViewState["SelectedIDCurso"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedIDCurso"] = value;
            }
        }

        private bool isEntitySelectedCurso
        {
            get
            {
                return (this.SelectedIDCurso != 0);
            }
        }

        private int SelectedIDAlumno
        {
            get
            {
                if (this.ViewState["SelectedIDAlumno"] != null)
                {
                    return (int)this.ViewState["SelectedIDAlumno"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedIDAlumno"] = value;
            }
        }

        private bool isEntitySelectedAlumno
        {
            get
            {
                return (this.SelectedIDAlumno != 0);
            }
        }

        #endregion 




        #region Metodos
        private void LoadGrid()
        {
            
            this.CursosgridView.DataSource = this.CurNeg.GetAll();
            this.CursosgridView.DataBind();
        }



        private void LoadForm(int id)
        {
            this.PersonaActual = this.PerNeg.GetOne(id);
            this.idPersonaTextBox.Text = this.AluInscActual.IdAlumno.ToString();
            this.nombreTextBox.Text = this.PersonaActual.Nombre;
            this.apellidoTextBox.Text = this.PersonaActual.Apellido;
            this.legajoTextBox.Text = this.PersonaActual.Legajo.ToString();
            this.notaTextBox.Text = this.AluInscActual.Nota.ToString();

        }


        #endregion 

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario UsuarioActual = (Usuario)(Session["UsuarioActual"]);

            if (UsuarioActual == null)
            {
                this.Page.Response.Redirect("~/Login.aspx");
            }
            else
            {
                Persona p = PerNeg.GetOne(UsuarioActual.IdPersona);

                if (p.TipoPersona != 0)
                {
                    this.gridActionsPanel.Visible = false;
                    this.incorrectoLabel.Visible = true;
                    this.aceptarLinkButton.Visible = false;
                }

                else
                {
                    if (!this.IsPostBack)
                    {
                        this.LoadGrid();
                    }
                }
            }
        }





        protected void curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDCurso = (int)this.CursosgridView.SelectedValue;
        }

        protected void alumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDAlumno = (int)this.AlumnosgridView.SelectedValue;
        }

   


        protected void ElegirAlumnoLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelectedCurso)
            {
                this.AlumnosgridView.DataSource = this.AluInscNeg.GetAll(SelectedIDCurso);
                this.AlumnosgridView.DataBind();

                this.AlumnosgridView.Visible = true;

            }
        }

        protected void cambiarNotaLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelectedAlumno)
            {

                this.AluInscActual = this.AluInscNeg.GetOne(SelectedIDAlumno);
                this.LoadForm(SelectedIDAlumno);
                this.PersonaPanel.Visible = true;
            }
        }



        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            this.AluInscActual = this.AluInscNeg.GetOne(SelectedIDAlumno);
            this.AluInscActual.Nota = Convert.ToInt32(this.notaTextBox.Text);

            this.AluInscActual.Estado = Entidad.Estados.Modificado;
            this.AluInscNeg.Save(AluInscActual);


        }


        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }



        #endregion

    }
}