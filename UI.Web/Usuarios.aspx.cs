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
            this.PersonaDropDownList.SelectedValue = this.Entity.IdPersona.ToString();
        }
        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
            usuario.IdPersona = Convert.ToInt32(this.PersonaDropDownList.SelectedValue);
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
        public void CargaDropDownList()
        {
            PersonaNegocio pn = new PersonaNegocio();

            this.PersonaDropDownList.DataSource = pn.GetAll();
            this.PersonaDropDownList.DataValueField = "Id";
            this.PersonaDropDownList.DataTextField = "NombreApe";
            this.PersonaDropDownList.DataBind();
            this.PersonaDropDownList.Items.Insert(0, new ListItem("Seleccione su nombre y apellido", "0"));


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
                    this.formPersona.Visible = false;
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
            this.formPersona.Visible = true;
            

        }
        protected void siButton_Click(object sender, EventArgs e) // si el usuario presiona este boton quiere decir que ya se dió de alta como persona
                                                                     // solo se va a dar de alta como nuevo usuario
        {
            this.formPersona.Visible = false;
            this.FormMode = FormModes.Alta;
            this.formPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(true);
            this.CargaDropDownList();

        }
        /*protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }*/

        protected void noButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:7057/Personas");
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }


        #endregion



    }
}