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
        private PersonaNegocio _PerNeg;

        public PersonaNegocio PerNeg
        {
            get {
                if (_PerNeg == null)
                {
                    _PerNeg = new PersonaNegocio();
                }
                    
                return _PerNeg; }
            
        }
        

        private void LoadGrid()
        {
            this.gridView.DataSource = this.LogicUsuario.GetAll();
            this.gridView.DataBind();
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
            AltaP,
            AltaU,
            Baja,
            Modificacion
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

        private Persona _Persona;

        public Persona Persona
        {
            get { return _Persona; }
            set { _Persona = value; }
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
            this.SelectedID = (int)this.gridView.SelectedValue;
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

        private void LoadPersona(Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Direccion = this.direccion.Text;
            persona.TipoPersona = Convert.ToInt32(this.tipoTextBox.Text);
        }

        private void SaveEntity(Usuario usuario)
        {
            this.LogicUsuario.Save(usuario);
        }
        private void SavePersona(int tipo, Persona persona)
        {
            this.PerNeg.Save(tipo, persona);
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
                    this.Entity = new Usuario();
                    this.Entity.Id = this.SelectedID;
                    this.Entity.Estado = Entidad.Estados.Modificado;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                case FormModes.AltaU:
                    
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                 case FormModes.AltaP:
                    
                    this.Persona = new Persona();
                    this.LoadPersona(this.Persona);
                    
                    this.SavePersona(this.Persona.TipoPersona, this.Persona);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }
            
            this.formPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;

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

        private void DeleteEntity(int id)
        {
            this.LogicUsuario.Delete(id);
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
            this.CargaDropDownList();

        }

        private void ClearForm()
        {
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
        }

        public void CargaDropDownList()
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
        }


        /*protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }*/ //preguntar si este evento es así

    }
}