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
    public partial class DocenteInscipcion : System.Web.UI.Page
    {
        #region Propiedades
        DocenteCursoNegocio _DocInscNeg;

        private DocenteCursoNegocio DocInscNeg
        {
            get
            {
                if (_DocInscNeg == null)
                {
                    _DocInscNeg = new DocenteCursoNegocio();
                }
                return _DocInscNeg;
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

        private DocenteCurso DocenteCursoActual
        {
            get;
            set;
        }

        private int SelectedIDDocente
        {
            get
            {
                if (this.ViewState["SelectedIDDocente"] != null)
                {
                    return (int)this.ViewState["SelectedIDDocente"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedIDDocente"] = value;
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

        private bool isDocenteSelected
        {
            get
            {
                return (this.SelectedIDDocente != 0);
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
            this.DocenteInscipciongridView.DataSource = this.PerNeg.GetAll();
            this.DocenteInscipciongridView.DataBind();

            this.CursoInscipciongridView.DataSource = this.Curneg.GetAll();
            this.CursoInscipciongridView.DataBind();
        }

        private void LoadEntity(DocenteCurso DocInsc, Persona alumSelecccionado, Curso curSeleccionado)
        {
            DocInsc.IdDocente = alumSelecccionado.Id;
            DocInsc.IdCurso = curSeleccionado.Id;
            DocInsc.Cargo = Convert.ToInt32(this.cargoTextBox.Text);
           
        }

        private void SaveEntity(DocenteCurso DocenteInscipcion)
        {
            this.DocInscNeg.Save(DocenteInscipcion);
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
                if (UsuarioActual.IdPersona == null)
                {
                    this.gridActionsPanel.Visible = false;
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

        protected void Docente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDDocente = (int)this.DocenteInscipciongridView.SelectedValue;
        }
        protected void curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDCurso = (int)this.CursoInscipciongridView.SelectedValue;
        }



        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            
            Persona alumSelecccionado = PerNeg.GetOne(SelectedIDDocente);
            Curso curSeleccionado = Curneg.GetOne(SelectedIDCurso);
                  
            this.DocenteCursoActual = new DocenteCurso();
            this.LoadEntity(this.DocenteCursoActual, alumSelecccionado, curSeleccionado);
            this.SaveEntity(this.DocenteCursoActual);
            
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