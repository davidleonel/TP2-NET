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
    public partial class RegistrarNotaDocente : System.Web.UI.Page
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

        DocenteCursoNegocio _DocCurcNeg;
        private DocenteCursoNegocio DocCurcNeg
        {
            get
            {
                if (_DocCurcNeg == null)
                {
                    _DocCurcNeg = new DocenteCursoNegocio();
                }
                return _DocCurcNeg;
            }
        }
        private DocenteCurso DocCurActual
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
        private void LoadGrid(int idDoc)
        {

            this.CursosgridView.DataSource = this.DocCurcNeg.GetAll(idDoc);
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

                if (Convert.ToInt32(p.TipoPersona) != 2)
                {
                    this.ElegirCursogridPanel.Visible = false;
                    this.incorrectoLabel.Visible = true;
                    this.aceptarLinkButton.Visible = false;
                }

                else
                {
                    if (!this.IsPostBack)
                    {
                        this.LoadGrid(p.Id);
                        this.gridActionsPanel.Visible = true;
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
                this.DocCurActual = this.DocCurcNeg.GetOne(SelectedIDCurso);

                this.AlumnosgridView.DataSource = this.AluInscNeg.GetAll(DocCurActual.IdCurso);
                this.AlumnosgridView.DataBind();

                this.AlumnosgridView.Visible = true;
                this.gridActionsPanel2.Visible = true;

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

            if ((Convert.ToInt32(this.notaTextBox.Text)) < 0 || (Convert.ToInt32(this.notaTextBox.Text)) > 10)
            {
                this.lblMsj.Text = "Nota Incorrecta, debe ser un nro entre 0 y 10.";
                this.lblMsj.Visible = true;

            }
            else
            {
                this.AluInscActual = this.AluInscNeg.GetOne(SelectedIDAlumno);
                this.AluInscActual.Nota = Convert.ToInt32(this.notaTextBox.Text);

                this.AluInscActual.Estado = Entidad.Estados.Modificado;
                this.AluInscNeg.Save(AluInscActual);
                this.lblMsj.Text = "Nota registrada";
                this.lblMsj.Visible = true;
            }


        }


        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }



        #endregion

    }
}