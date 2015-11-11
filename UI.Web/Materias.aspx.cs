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
    public partial class Materias : System.Web.UI.Page
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
            this.MateriasgridView.DataSource = this.MatNeg.GetAll();
            this.MateriasgridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.MateriaActual = this.MatNeg.GetOne(id);
            this.idMateriaTextBox.Text = this.MateriaActual.Id.ToString();
            this.descMateriaTextBox.Text = this.MateriaActual.DescripcionMateria;
            this.hsSemanalesTextBox.Text = this.MateriaActual.HsSemanales.ToString();
            this.hsTotalesTextBox.Text = this.MateriaActual.HsTotales.ToString();
            this.PlanesDropDownList.SelectedValue = this.MateriaActual.IdPlan.ToString();
        }

        private void LoadEntity(Materia Materia)
        {
            Materia.DescripcionMateria = this.descMateriaTextBox.Text;
            Materia.HsSemanales = Convert.ToInt32(this.hsSemanalesTextBox.Text);
            Materia.HsTotales = Convert.ToInt32(this.hsTotalesTextBox.Text);
            Materia.IdPlan = Convert.ToInt32(this.PlanesDropDownList.SelectedValue);
        }

        private void SaveEntity(Materia Materia)
        {
            this.MatNeg.Save(Materia);
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
            this.PlanesDropDownList.DataBind();
            this.PlanesDropDownList.Items.Insert(0, new ListItem("Seleccione Plan.", "0"));

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
                    else
                    {
                        this.CargaDropDownListPlanes();

                    }
                }
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.MateriasgridView.SelectedValue;
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
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {


            this.FormMode = FormModes.Alta;
            this.MateriaPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(true);

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

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }

        #endregion 

    }
}