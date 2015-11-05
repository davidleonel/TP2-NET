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
    public partial class Usuarios : System.Web.UI.Page
    {
        #region  Propiedades
        UsuarioNegocio _logicUsuario;
        private UsuarioNegocio LogicUsuario
        {
            get
            {
                if (_logicUsuario == null)
                {
                    _logicUsuario = new UsuarioNegocio();
                }
                return _logicUsuario;
            }
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Usuario Entity
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
            this.gridView.DataSource = this.LogicUsuario.GetAll();
            this.gridView.DataBind();
        }
        private void LoadForm(int id)
        {
            this.Entity = this.LogicUsuario.GetOne(id);
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
        }
        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
        }
        private void SaveEntity(Usuario usuario)
        {
            this.LogicUsuario.Save(usuario);
        }
        private void EnableForm(bool enable)
        {
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;

        }
        private void DeleteEntity(int id)
        {
            this.LogicUsuario.Delete(id);
        }
        private void ClearForm()
        {
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
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
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
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
                    this.Entity = new Usuario();
                    this.Entity.Id = this.SelectedID;
                    this.Entity.Estado = Entidad.Estados.Modificado;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.Alta:

                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.formPanel.Visible = false;
        }
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                //this.EnableForm(true);
            }
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

            this.PersonaDropDown.Visible = true;
            //this.FormMode = FormModes.Alta;
            this.ClearForm();
            //this.EnableForm(true);
            //this.CargaDropDownList();

        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        } //preguntar si este evento es así

        #endregion


        /*public void CargaDropDownList()
        {
            PersonaNegocio pn = new PersonaNegocio();

            this.personaDropDownList.DataSource = pn.GetAll();
            this.personaDropDownList.DataValueField = "Id";
            this.personaDropDownList.DataTextField = "Nombre";
            this.personaDropDownList.DataBind();
            this.personaDropDownList.Items.Insert(0, new ListItem("Nunca me registre...", "0"));

        }

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
        }*/




    }
}