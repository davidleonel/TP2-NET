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
    public partial class InscripcionDocente : System.Web.UI.Page
    {
        #region Propiedades
        
        private Usuario _UsuAct;

        public Usuario UsuAct
        {
            get { return _UsuAct; }
            set { _UsuAct = value; }
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
        private DocenteCursoNegocio _NuevaInscNeg;

        public DocenteCursoNegocio NuevaInscNeg
        {
            get 
            {
                if (_NuevaInscNeg == null)
                {
                    _NuevaInscNeg = new DocenteCursoNegocio();
                }
                return _NuevaInscNeg; 
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

        private DocenteCurso NuevaInsc
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
            this.InscripcionDocentegridView.DataSource = this.CurNeg.GetAll();
            this.InscripcionDocentegridView.DataBind();
        }


        private void LoadEntity(DocenteCurso NuevaInscripcion)
        {
            Persona PersonaActual = this.PersonaActNeg.GetOne(UsuAct.IdPersona);
            NuevaInscripcion.IdDocente = PersonaActual.Id;
            NuevaInscripcion.IdCurso = this.SelectedID;
            NuevaInscripcion.Cargo = this.CargoDropDownList.SelectedIndex;
            
        }

        private void SaveEntity(DocenteCurso NuevaInscripcion)
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
                Persona p = PersonaActNeg.GetOne(UsuAct.IdPersona);

                if (Convert.ToInt32(p.TipoPersona) != 2)
                {
                    this.InscripcionDocentegridView.Visible = false;
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


        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.InscripcionDocentegridView.SelectedValue;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

                    this.NuevaInsc = new DocenteCurso();
                    this.LoadEntity(this.NuevaInsc);
                    this.SaveEntity(this.NuevaInsc);
                    this.LoadGrid();

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }

       
        #endregion

    }
}