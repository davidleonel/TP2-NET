using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using Entidades;

namespace UI.Escritorio
{
    public partial class PersonaEscritorio : ApplicationForm
    {
        #region Propiedades 
        private Persona _PerActual;

        public Persona PerActual
        {
            get { return _PerActual; }
            set { _PerActual = value; }
        }
        
        #endregion 

        #region Constructores
        public PersonaEscritorio()
        {
            InitializeComponent();
        }
        public PersonaEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;
            this.cargarCbPlanes();
            this.cargaTipoPersonas();

        }

        public PersonaEscritorio(int ID, ModoForm modo)
            : this()
        {
            Modo = modo;
            PersonaNegocio per  = new PersonaNegocio();
            PerActual = per.GetOne(ID);
            this.cargarCbPlanes();
            this.cargaTipoPersonas();
            this.MapearDeDatos();

        }
        #endregion 

        #region Metodos
        private void cargaTipoPersonas()
        {
            List<ItemsCbTipoPersona> lista = new List<ItemsCbTipoPersona>();

            lista.Add(new ItemsCbTipoPersona("Administrador", 0));
            lista.Add(new ItemsCbTipoPersona("Alumno", 1));
            lista.Add(new ItemsCbTipoPersona("Docente", 2));

            cbTipoPersona.DisplayMember = "Name";
            cbTipoPersona.ValueMember = "Value";
            cbTipoPersona.DataSource = lista;
        }

        private void cargarCbPlanes()
        {
            PersonaNegocio pn = new PersonaNegocio();
            cbPlanes.DataSource = pn.GetAll();
            cbPlanes.DisplayMember = "DescripcionPlan";
            cbPlanes.ValueMember = "Id";
        }
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PerActual.Id.ToString();
            this.txtNombre.Text = this.PerActual.Nombre;
            this.txtApellido.Text = this.PerActual.Apellido;
            this.txtDireccion.Text = this.PerActual.Direccion;
            this.txtEmail.Text = this.PerActual.Email;
            this.txtTelefono.Text = this.PerActual.Telefono;
            this.txtLegajo.Text = this.PerActual.Legajo.ToString();
            this.cbTipoPersona.SelectedValue = this.PerActual.TipoPersona;
            this.cbPlanes.SelectedValue = this.PerActual.IdPlan;

            switch (Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;

            }

        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {

                PerActual = new Persona();

                this.PerActual.Nombre = this.txtNombre.Text  ;
                this.PerActual.Apellido = this.txtApellido.Text;
                this.PerActual.Direccion = this.txtDireccion.Text  ;
                this.PerActual.Email = this.txtEmail.Text  ;
                this.PerActual.Telefono = this.txtTelefono.Text  ;
                this.PerActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                //this.PerActual.TipoPersona = this.cbTipoPersona.SelectedValue; Preguntaaaaaaaaaaaaaaaaaaaaaar! 
                this.PerActual.IdPlan = Convert.ToInt32(this.cbPlanes.SelectedValue);

            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.PerActual.Id = Convert.ToInt32(this.txtID.Text);
                this.PerActual.Nombre = this.txtNombre.Text;
                this.PerActual.Apellido = this.txtApellido.Text;
                this.PerActual.Direccion = this.txtDireccion.Text;
                this.PerActual.Email = this.txtEmail.Text;
                this.PerActual.Telefono = this.txtTelefono.Text;
                this.PerActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                //this.PerActual.TipoPersona = this.cbTipoPersona.SelectedValue; Preguntaaaaaaaaaaaaaaaaaaaaaar! 
                this.PerActual.IdPlan = Convert.ToInt32(this.cbPlanes.SelectedValue);

            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    PerActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    PerActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    PerActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    PerActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaNegocio pn = new PersonaNegocio();
            pn.Save(PerActual);

        }
        public override bool Validar()
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) 
                || Convert.ToInt32(this.cbTipoPersona.SelectedValue) == -1 || Convert.ToInt32(this.cbPlanes.SelectedValue) == -1)
            {
                Notificar("Campos vacíos", "No puede dejar campos sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            return bandera;
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        #endregion 

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 
    }
}
