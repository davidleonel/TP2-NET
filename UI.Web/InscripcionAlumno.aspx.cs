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
    public partial class InscripcionAlumno : System.Web.UI.Page
    {
        #region Propiedades

        private Usuario _UsuAct;

        public Usuario UsuAct
        {
            get { return _UsuAct; }
            set { _UsuAct = value; }
        }
        
        private AlumnoInscripcionNegocio _NuevaInscNeg;

        public AlumnoInscripcionNegocio NuevaInscNeg
        {
            get 
            {
                if (_NuevaInscNeg == null)
                {
                    _NuevaInscNeg = new AlumnoInscripcionNegocio();
                }
                return _NuevaInscNeg; 
            }

        }

        private PersonaNegocio _PersonaActNeg;

        public PersonaNegocio PersonaActNeg
        {
            get
            {
                if (_PersonaActNeg == null)
                {
                    _PersonaActNeg = new PersonaNegocio();
                }
                return _PersonaActNeg;
            }

        }
        
        CursoNegocio _CurNeg;
        private CursoNegocio CurNeg
        {
            get {
                if (_CurNeg == null)
                {
                    _CurNeg = new CursoNegocio();
                }
                return _CurNeg; 
            }
        }

        private AlumnoInscripcion NuevaInsc
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool isEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
        #endregion 

      

        #region Metodos
        private void LoadGrid()
        {
            this.InscripcionAlumnogridView.DataSource = this.CurNeg.GetAll();
            this.InscripcionAlumnogridView.DataBind();
        }


        private void LoadEntity(AlumnoInscripcion NuevaInscripcion)
        {
            Persona PersonaActual = this.PersonaActNeg.GetOne(UsuAct.IdPersona);
            NuevaInscripcion.IdAlumno = PersonaActual.Id;
            NuevaInscripcion.IdCurso = this.SelectedID;
            NuevaInscripcion.Condicion = "Inscripto";
            
        }

        private void SaveEntity(AlumnoInscripcion NuevaInscripcion)
        {
            this.NuevaInscNeg.Save(NuevaInscripcion);
        }

        #endregion 

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
           this.UsuAct = (Usuario)(Session["UsuarioActual"]);

           if (UsuAct == null)
            {
                this.Page.Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (UsuAct.IdPersona == null)
                {
                    this.formActionsPanel.Visible = false;
                    this.incorrectoLabel.Visible = true;
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


        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.InscripcionAlumnogridView.SelectedValue;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

                    this.NuevaInsc = new AlumnoInscripcion();
                    this.LoadEntity(this.NuevaInsc);
                    this.SaveEntity(this.NuevaInsc);
                    this.LoadGrid();

        }

       

        /*protected void cancelarLinkButton_Click(object sender, EventArgs e)
            {
                this.LoadGrid();
            }*/
        //preguntar si este evento es así
        #endregion

    }
}