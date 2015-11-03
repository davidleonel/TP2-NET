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
    public partial class RegNotaInscipcion : System.Web.UI.Page
    {
        #region Propiedades
        RegNotaInscripcionNegocio _AluInscNeg;
        
        private RegNotaInscripcionNegocio AluInscNeg
        {
            get
            {
                if (_AluInscNeg == null)
                {
                    _AluInscNeg = new RegNotaInscripcionNegocio();
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
        
        private RegNotaInscripcion RegNotaInscipcionActual
        {
            get;
            set;
        }

        private int SelectedIDRegNota
        {
            get
            {
                if (this.ViewState["SelectedIDRegNota"] != null)
                {
                    return (int)this.ViewState["SelectedIDRegNota"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedIDRegNota"] = value;
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

        private bool isRegNotaSelected
        {
            get
            {
                return (this.SelectedIDRegNota != 0);
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
            this.RegNotaInscipciongridView.DataSource = this.PerNeg.GetAllRegNotas();
            this.RegNotaInscipciongridView.DataBind();

            this.CursoInscipciongridView.DataSource = this.Curneg.GetAll();
            this.CursoInscipciongridView.DataBind();
        }

        private void LoadEntity(RegNotaInscripcion AluInsc, Persona alumSelecccionado, Curso curSeleccionado)
        {
            AluInsc.IdRegNota = alumSelecccionado.Id;
            AluInsc.IdCurso = curSeleccionado.Id;
            AluInsc.Condicion = this.condicionTextBox.Text;
           
        }

        private void SaveEntity(RegNotaInscripcion RegNotaInscipcion)
        {
            this.AluInscNeg.Save(RegNotaInscipcion);
        }

            

        #endregion 

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGrid();
            }

        }

        protected void RegNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDRegNota = (int)this.RegNotaInscipciongridView.SelectedValue;
        }
        protected void curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDCurso = (int)this.CursoInscipciongridView.SelectedValue;
        }



        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            //this.PerNeg = new PersonaNegocio();
            Persona alumSelecccionado = PerNeg.GetOne(SelectedIDRegNota);

            //this.Curneg = new CursoNegocio();
            Curso curSeleccionado = Curneg.GetOne(SelectedIDCurso);
                  
            this.RegNotaInscipcionActual = new RegNotaInscripcion();
            this.LoadEntity(this.RegNotaInscipcionActual, alumSelecccionado, curSeleccionado);
            this.SaveEntity(this.RegNotaInscipcionActual);
            
        }

        protected void inscribirLinkButton_Click(object sender, EventArgs e)
        {                                                     
            this.CursoInscipciongridPanel.Visible = true;

        }
        
        #endregion 

    }
}