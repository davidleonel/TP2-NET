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
    public partial class Comisiones : System.Web.UI.Page
    {
        #region Propiedades
        ComisionNegocio _ComNeg;
        private ComisionNegocio ComNeg
        {
            get
            {
                if (_ComNeg == null)
                {
                    _ComNeg = new ComisionNegocio();
                }
                return _ComNeg;
            }
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Comision ComActual
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

        #region Enumerador
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        #endregion

        #region Metodos
        private void LoadGrid()
        {
            this.ComisionesgridView.DataSource = this.ComNeg.GetAll();
            this.ComisionesgridView.DataBind();
        }


        private void LoadForm(int id)
        {
            this.ComActual = this.ComNeg.GetOne(id);
            this.idComisionTextBox.Text = this.ComActual.Id.ToString();
            this.descComisionTextBox.Text = this.ComActual.DescripcionComision;
            this.anioTextBox.Text = this.ComActual.AnioEspecialidad.ToString();          
            this.PlanesDropDownList.SelectedValue = this.ComActual.IdPlan.ToString();
        }
        private void LoadEntity(Comision comision)
        {
            comision.DescripcionComision = this.descComisionTextBox.Text;
            comision.AnioEspecialidad = Convert.ToInt32(this.anioTextBox.Text); 
            comision.IdPlan = Convert.ToInt32(this.PlanesDropDownList.SelectedValue);
            

        }

        private void SaveEntity(Comision comision)
        {
            this.ComNeg.Save(comision);
        }

        private void EnableForm(bool enable)
        {

            this.descComisionTextBox.Enabled = enable;
            this.anioTextBox.Enabled = enable;
            this.PlanesDropDownList.Enabled = enable;

        }

        public void CargaDropDownListPlanes()
        {
            PlanNegocio pn = new PlanNegocio();

            this.PlanesDropDownList.DataSource = pn.GetAll();
            this.PlanesDropDownList.DataValueField = "Id";
            this.PlanesDropDownList.DataTextField = "DescripcionPlan";
            this.PlanesDropDownList.DataBind();
            this.PlanesDropDownList.Items.Insert(0, new ListItem("Seleccione Plan.", "0"));

        }

        private void DeleteEntity(int id)
        {
            this.ComNeg.Delete(id);
        }

        private void ClearForm()
        {
            this.idComisionTextBox.Text = string.Empty;
            this.descComisionTextBox.Text = string.Empty;
            this.anioTextBox.Text = string.Empty;

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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.ComisionesgridView.SelectedValue;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;

                case FormModes.Modificacion:
                    this.ComActual = new Comision();
                    this.ComActual.Id = this.SelectedID;
                    this.ComActual.Estado = Entidad.Estados.Modificado;
                    this.LoadEntity(this.ComActual);
                    this.SaveEntity(this.ComActual);
                    this.LoadGrid();
                    break;

                case FormModes.Alta:

                    this.ComActual = new Comision();
                    this.LoadEntity(this.ComActual);
                    this.SaveEntity(this.ComActual);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.ComisionPanel.Visible = false;
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {


            this.FormMode = FormModes.Alta;
            this.ComisionPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(true);
            this.CargaDropDownListPlanes();

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.ComisionPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.CargaDropDownListPlanes();
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.ComisionPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.LoadForm(this.SelectedID);
                this.EnableForm(false);
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }


        #endregion
    }
}