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
    public partial class DocenteEscritorio : ApplicationForm
    {
        #region Propiedades
        private Persona _DocenteActual;

        public Persona DocenteActual
        {
            get { return _DocenteActual; }
            set { _DocenteActual = value; }
        }
        #endregion 

        #region Constructores
        public DocenteEscritorio()
        {
            InitializeComponent();
        }

        public DocenteEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;   

        }

        public DocenteEscritorio(int ID, ModoForm modo):this()
        {
            Modo = modo;
            PersonaNegocio doc = new PersonaNegocio();
            DocenteActual = doc.GetOne(ID);
            MapearDeDatos();

        }
        #endregion

        #region Metodos
        public override void MapearDeDatos() 
        {
            this.txtIDPersona.Text = this.DocenteActual.Id.ToString();
            this.txtNombre.Text = this.DocenteActual.Nombre.ToString();
            this.txtApellido.Text = this.DocenteActual.Apellido.ToString();
            this.txtDireccion.Text = this.DocenteActual.Direccion.ToString();
            this.txtEmail.Text = this.DocenteActual.Email.ToString();
            this.txtTelefono.Text = this.DocenteActual.Telefono.ToString();
            //this.mcFecNac.DateSelected = this.DocenteActual.FechaNacimiento.ToString();
            this.txtLegajo.Text  = this.DocenteActual.Legajo.ToString();
            this.txtIdPlan.Text = this.DocenteActual.IdPlan.ToString();
            



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
                
                DocenteActual = new Persona();
                this.DocenteActual.Nombre = this.txtNombre.Text;
                this.DocenteActual.Apellido = this.txtApellido.Text;
                this.DocenteActual.Direccion = this.txtDireccion.Text;
                this.DocenteActual.Email = this.txtEmail.Text;
                this.DocenteActual.Telefono = this.txtTelefono.Text;
                //this.DocenteActual.FechaNacimiento = this.mcFecNac.DateSelected();
                this.DocenteActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                this.DocenteActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);
                

            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.DocenteActual.Id = Convert.ToInt32(this.txtIDPersona.Text);
                this.DocenteActual.Nombre = this.txtNombre.Text;
                this.DocenteActual.Apellido = this.txtApellido.Text;
                this.DocenteActual.Direccion = this.txtDireccion.Text;
                this.DocenteActual.Email = this.txtEmail.Text;
                this.DocenteActual.Telefono = this.txtTelefono.Text;
                //this.DocenteActual.FechaNacimiento = this.mcFecNac.DateSelected();
                this.DocenteActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                this.DocenteActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    DocenteActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    DocenteActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    DocenteActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    DocenteActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            PersonaNegocio perNeg = new PersonaNegocio();
            perNeg.Save(DocenteActual);
            
        }
        public override bool Validar() 
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) ||
                string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtEmail.Text) ||
                string.IsNullOrEmpty(this.txtTelefono.Text) || string.IsNullOrEmpty(this.txtLegajo.Text) || string.IsNullOrEmpty(this.txtIdPlan.Text)
                )
            {
                // string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) ||string.IsNullOrEmpty(this.txtEmail.Text
                Notificar("Campos vacíos", "No puede haber campos sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            //falta validar email!
            
            return bandera; 
        }
        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(this.Validar())
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

        private void lblFecNac_Click(object sender, EventArgs e)
        {

        }
    }
}
