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
    public partial class AlumnoInscipcion : System.Web.UI.Page
    {
        #region Propiedades


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

        private PersonaNegocio _PerNeg;

        public PersonaNegocio PerNeg
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

        private CursoNegocio _CurNeg;

        public CursoNegocio Curneg
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
        
        private AlumnoInscripcion AlumnoInscipcionActual
        {
            get;
            set;
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

        private bool isAlumnoSelected
        {
            get
            {
                return (this.SelectedIDAlumno != 0);
            }
        }

        private bool isCursoSelected
        {
            get
            {
                return (this.SelectedIDCurso != 0);
            }
        }
        #endregion 


        #region Metodos
        private void LoadGrid()
        {
            this.CursoInscipciongridView.DataSource = this.Curneg.GetAll();
            this.CursoInscipciongridView.DataBind();

            this.AlumnoInscipciongridView.DataSource = this.PerNeg.GetAllAlumnos();
            this.AlumnoInscipciongridView.DataBind();
        }

        private void LoadEntity(AlumnoInscripcion AluInsc, Persona alumSelecccionado, Curso curSeleccionado)
        {
            AluInsc.IdAlumno = alumSelecccionado.Id;
            AluInsc.IdCurso = curSeleccionado.Id;
            AluInsc.Condicion = this.condicionTextBox.Text;
           
        }

        private void SaveEntity(AlumnoInscripcion AlumnoInscipcion)
        {
            this.AluInscNeg.Save(AlumnoInscipcion);
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

        protected void alumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDAlumno = (int)this.AlumnoInscipciongridView.SelectedValue;
        }
        protected void curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDCurso = (int)this.CursoInscipciongridView.SelectedValue;
        }



        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            
            Persona alumSelecccionado = PerNeg.GetOne(SelectedIDAlumno);

            
            Curso curSeleccionado = Curneg.GetOne(SelectedIDCurso);
                  
            this.AlumnoInscipcionActual = new AlumnoInscripcion();
            this.LoadEntity(this.AlumnoInscipcionActual, alumSelecccionado, curSeleccionado);
            this.SaveEntity(this.AlumnoInscipcionActual);
            
        }

        protected void inscribirLinkButton_Click(object sender, EventArgs e)
        {                                                     
            this.CursoInscipciongridPanel.Visible = true;

        }
        
        

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }
        #endregion
    }
}