﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;


namespace UI.Web
{
    public partial class Materias : System.Web.UI.Page
    {
        MateriaNegocio _MatNeg;


        private MateriaNegocio MatNeg
        {
            get
            {
                if (_MatNeg == null)
                {
                    _MatNeg = new MateriaNegocio();
                }
                return _MatNeg;
            }
        }
    
        

        private void LoadGrid()
        {
            this.MateriasgridView.DataSource = this.MatNeg.GetAll();
            this.MateriasgridView.DataBind();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.LoadGrid();
            }
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Materia MateriaActual
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.MateriasgridView.SelectedValue;
        }


        private void LoadForm(int id)
        {
            this.MateriaActual = this.MatNeg.GetOne(id);
            this.idMateriaTextBox.Text = this.MateriaActual.Id.ToString();
            this.descMateriaTextBox.Text = this.MateriaActual.DescripcionMateria;
            this.hsSemanalesTextBox.Text = this.MateriaActual.HsSemanales.ToString();
            this.hsTotalesTextBox.Text = this.MateriaActual.HsTotales.ToString();
            this.PlanesDropDownList.Text = this.MateriaActual.IdPlan.ToString();
        }

     

        private void LoadEntity(Materia Materia)
        {
            Materia.DescripcionMateria = this.descMateriaTextBox.Text;
            Materia.HsSemanales = Convert.ToInt32(this.hsSemanalesTextBox.Text);
            Materia.HsTotales = Convert.ToInt32(this.hsTotalesTextBox.Text);
            Materia.IdPlan = Convert.ToInt32(this.PlanesDropDownList.Text);
        }


        private void SaveEntity(Materia Materia)
        {
            this.MatNeg.Save(Materia);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch(this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                
                case FormModes.Modificacion:
                    this.MateriaActual = new Materia();
                    this.MateriaActual.Id = this.SelectedID;
                    this.MateriaActual.Estado = Entidad.Estados.Modificado;
                    this.LoadEntity(this.MateriaActual);
                    this.SaveEntity(this.MateriaActual);
                    this.LoadGrid();
                    break;

                case FormModes.Alta:

                    this.MateriaActual = new Materia();
                    this.LoadEntity(this.MateriaActual);
                    this.SaveEntity(this.MateriaActual);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }
            
            this.MateriaPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            
            this.descMateriaTextBox.Enabled = enable;
            this.hsSemanalesTextBox.Enabled = enable;
            this.hsTotalesTextBox.Enabled = enable;
            this.PlanesDropDownList.Enabled = enable;

        }

        public void CargaDropDownListPlanes()
        {
            PlanNegocio pn = new PlanNegocio();

            this.PlanesDropDownList.DataSource = pn.GetAll();
            this.PlanesDropDownList.DataValueField = "Id";
            this.PlanesDropDownList.DataTextField = "DescripcionPlan";
           // this.PlanesDropDownList.DataBind();
            this.PlanesDropDownList.Items.Insert(0, new ListItem("Seleccione Plan.", "0"));

        }



        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {


            this.FormMode = FormModes.Alta;
            this.MateriaPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(true);
            this.CargaDropDownListPlanes();

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.MateriaPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.MateriaPanel.Visible = true;
                this.FormMode = FormModes.Baja;      
                this.LoadForm(this.SelectedID);
                this.EnableForm(false);
            }
        }

        private void DeleteEntity(int id)
        {
            this.MatNeg.Delete(id);
        }




        private void ClearForm()
        {
            this.idMateriaTextBox.Text = string.Empty;
            this.descMateriaTextBox.Text = string.Empty;
            this.hsSemanalesTextBox.Text = string.Empty;
            this.hsTotalesTextBox.Text = string.Empty;
            this.PlanesDropDownList.Text = string.Empty;
        }

        /*

        protected void personaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (personaDropDownList.SelectedIndex != 0)

            {
                this.formPanel.Visible = true;
                this.personaPanel.Visible = false;  
                this.FormMode = FormModes.AltaU;
                this.EnableForm(true);
            }
            else if (personaDropDownList.SelectedIndex == 0)
            {
                this.FormMode = FormModes.AltaP;
                this.formPanel.Visible = true;
                this.personaPanel.Visible = true;  
            }
        }
        */

        /*protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }*/ //preguntar si este evento es así

    }
}