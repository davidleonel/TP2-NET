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
    public partial class Personas : System.Web.UI.Page
    {
        #region Propiedades
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
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Persona PersonaActual
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
            this.PersonasgridView.DataSource = this.PerNeg.GetAll();
            this.PersonasgridView.DataBind();
        }
        private void LoadForm(int id)
        {
            this.PersonaActual = this.PerNeg.GetOne(id);
            this.idPersonaTextBox.Text = this.PersonaActual.Id.ToString();
            this.nombreTextBox.Text = this.PersonaActual.Nombre;
            this.apellidoTextBox.Text = this.PersonaActual.Apellido;
            this.direccionTextBox.Text = this.PersonaActual.Direccion;
            this.emailTextBox.Text = this.PersonaActual.Email;
            this.telefonoTextBox.Text = this.PersonaActual.Telefono;
            this.fechaNacimientoCalendar.SelectedDate = this.PersonaActual.FechaNacimiento;
            this.legajoTextBox.Text = this.PersonaActual.Legajo.ToString();
            //this.TipoPersonaDropDownList.SelectedValue = this.PersonaActual.TipoPersona.ToString();
            //como hacer que funcione esto cuando el dropdownlist está compuesto por un tipo enumerado
            this.PlanDropDownList.SelectedValue = this.PersonaActual.IdPlan.ToString();
        }
        private void LoadPersona(Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.Telefono = this.telefonoTextBox.Text;
            persona.FechaNacimiento = this.fechaNacimientoCalendar.SelectedDate;
            persona.Legajo = Convert.ToInt32(this.legajoTextBox.Text);
            int tipo = Convert.ToInt32(this.TipoPersonaDropDownList.SelectedValue);
            persona.TipoPersona = this.SeleccionaTipoPersona(tipo);
            persona.IdPlan = Convert.ToInt32(this.PlanDropDownList.SelectedValue);
        }

        private Persona.TiposPersona SeleccionaTipoPersona(int tipoPersonaSelected)
        {
            Persona.TiposPersona tipoPersona;
            switch (tipoPersonaSelected)
            {
                case 0: tipoPersona = Persona.TiposPersona.Administrador;
                    break;
                case 1: tipoPersona = Persona.TiposPersona.Alumno;
                    break;
                case 2: tipoPersona = Persona.TiposPersona.Docente;
                    break;
                default: tipoPersona = Persona.TiposPersona.Administrador;
                    break;
            }
            return tipoPersona;
        }
        private void SavePersona(Persona persona)
        {
            this.PerNeg.Save(persona);
        }
        private void EnableForm(bool enable)
        {

            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.fechaNacimientoCalendar.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.TipoPersonaDropDownList.Enabled = enable;
            this.PlanDropDownList.Enabled = enable;

        }

        public void CargaDropDownListPlanes()
        {
            PlanNegocio pn = new PlanNegocio();

            this.PlanDropDownList.DataSource = pn.GetAll();
            this.PlanDropDownList.DataValueField = "Id";
            this.PlanDropDownList.DataTextField = "DescripcionPlan";
            this.PlanDropDownList.DataBind();
            this.PlanDropDownList.Items.Insert(0, new ListItem("Seleccione Materia.", "0"));

        }

        private void DeleteEntity(int id)
        {
            this.PerNeg.Delete(id);
        }

        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
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
            this.SelectedID = (int)this.PersonasgridView.SelectedValue;
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
                    this.PersonaActual = new Persona();
                    this.PersonaActual.Id = this.SelectedID;
                    this.PersonaActual.Estado = Entidad.Estados.Modificado;
                    this.LoadPersona(this.PersonaActual);
                    this.SavePersona(this.PersonaActual);
                    this.LoadGrid();
                    break;

                case FormModes.Alta:

                    this.PersonaActual = new Persona();
                    this.LoadPersona(this.PersonaActual);
                    this.SavePersona(this.PersonaActual);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.PersonaPanel.Visible = false;
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.FormMode = FormModes.Alta;
            this.PersonaPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(true);

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.PersonaPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);

            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.PersonaPanel.Visible = true;
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