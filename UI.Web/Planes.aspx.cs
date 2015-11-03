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
    public partial class planes : System.Web.UI.Page
    {
        PlanNegocio _PlanNeg;


        private PlanNegocio PlanNeg
        {
            get
            {
                if (_PlanNeg == null)
                {
                    _PlanNeg = new PlanNegocio();
                }
                return _PlanNeg;
            }
        }
    
        

        private void LoadGrid()
        {
            this.planesgridView.DataSource = this.PlanNeg.GetAll();
            this.planesgridView.DataBind();
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

        private Plan planActual
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
            this.SelectedID = (int)this.planesgridView.SelectedValue;
        }


        private void LoadForm(int id)
        {
            this.planActual = this.PlanNeg.GetOne(id);
            this.idplanTextBox.Text = this.planActual.Id.ToString();
            this.descplanTextBox.Text = this.planActual.DescripcionPlan;
            this.EspecialidadesDropDownList.Items.Insert(0, new ListItem(this.planActual.IdEspecialidad.ToString(), "0"));

        }

     

        private void LoadEntity(Plan plan)
        {
            plan.DescripcionPlan = this.descplanTextBox.Text;
            plan.IdEspecialidad = Convert.ToInt32(this.EspecialidadesDropDownList.SelectedValue);
        }


        private void SaveEntity(Plan plan)
        {
            this.PlanNeg.Save(plan);
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
                    this.planActual = new Plan();
                    this.planActual.Id = this.SelectedID;
                    this.planActual.Estado = Entidad.Estados.Modificado;
                    this.LoadEntity(this.planActual);
                    this.SaveEntity(this.planActual);
                    this.LoadGrid();
                    break;

                case FormModes.Alta:

                    this.planActual = new Plan();
                    this.LoadEntity(this.planActual);
                    this.SaveEntity(this.planActual);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }
            
            this.planPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            
            this.descplanTextBox.Enabled = enable;
            this.EspecialidadesDropDownList.Enabled = enable;

        }

        public void CargaDropDownListEspecialidades()
        {
            EspecialidadNegocio en = new EspecialidadNegocio();

            this.EspecialidadesDropDownList.DataSource = en.GetAll();
            this.EspecialidadesDropDownList.DataValueField = "Id";
            this.EspecialidadesDropDownList.DataTextField = "DescripcionEspecialidad";
            this.EspecialidadesDropDownList.DataBind();
            this.EspecialidadesDropDownList.Items.Insert(0, new ListItem("Seleccione Especialidad.", "0"));

        }



        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {


            this.FormMode = FormModes.Alta;
            this.planPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(true);
            this.CargaDropDownListEspecialidades();

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.planPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.CargaDropDownListEspecialidades();
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
                
    
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.planPanel.Visible = true;
                this.FormMode = FormModes.Baja;      
                this.LoadForm(this.SelectedID);
                this.EnableForm(false);
            }
        }

        private void DeleteEntity(int id)
        {
            this.PlanNeg.Delete(id);
        }




        private void ClearForm()
        {
            this.idplanTextBox.Text = string.Empty;
            this.descplanTextBox.Text = string.Empty;

        }


        /*protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }*/ //preguntar si este evento es así

    }
}