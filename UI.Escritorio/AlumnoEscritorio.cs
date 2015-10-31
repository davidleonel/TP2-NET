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
    public partial class AlumnoEscritorio : ApplicationForm
    {
        #region Propiedades
        private Persona _AlumnoActual;

        public Persona AlumnoActual
        {
            get { return _AlumnoActual; }
            set { _AlumnoActual = value; }
        }
        #endregion 

        #region Constructores
        public AlumnoEscritorio()
        {
            InitializeComponent();
        }

        public AlumnoEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;   

        }

        public AlumnoEscritorio(int ID, ModoForm modo):this()
        {
            Modo = modo;
            PersonaNegocio alu = new PersonaNegocio();
            AlumnoActual = alu.GetOne(ID);
            MapearDeDatos();

        }
        #endregion

        #region Metodos
        public override void MapearDeDatos() 
        {
            this.txtIDPersona.Text = this.AlumnoActual.Id.ToString();
            this.txtNombre.Text = this.AlumnoActual.Nombre.ToString();
            this.txtApellido.Text = this.AlumnoActual.Apellido.ToString();
            this.txtDireccion.Text = this.AlumnoActual.Direccion.ToString();
            this.txtEmail.Text = this.AlumnoActual.Email.ToString();
            this.txtTelefono.Text = this.AlumnoActual.Telefono.ToString();
            //this.mcFecNac.DateSelected = this.AlumnoActual.FechaNacimiento.ToString();
            this.txtLegajo.Text  = this.AlumnoActual.Legajo.ToString();
            



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
                
                AlumnoActual = new Persona();


                this.AlumnoActual.Nombre = this.txtNombre.Text;
                this.AlumnoActual.Apellido = this.txtApellido.Text;
                this.AlumnoActual.Direccion = this.txtDireccion.Text;
                this.AlumnoActual.Email = this.txtEmail.Text;
                this.AlumnoActual.Telefono = this.txtTelefono.Text;
                //this.AlumnoActual.FechaNacimiento = this.mcFecNac.DateSelected();
                this.AlumnoActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);


            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.AlumnoActual.Id = Convert.ToInt32(this.txtIDPersona.Text);
                this.AlumnoActual.Nombre = this.txtNombre.Text;
                this.AlumnoActual.Apellido = this.txtApellido.Text;
                this.AlumnoActual.Direccion = this.txtDireccion.Text;
                this.AlumnoActual.Email = this.txtEmail.Text;
                this.AlumnoActual.Telefono = this.txtTelefono.Text;
                //this.AlumnoActual.FechaNacimiento = this.mcFecNac.DateSelected();
                this.AlumnoActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    AlumnoActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    AlumnoActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    AlumnoActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    AlumnoActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            PersonaNegocio perNeg = new PersonaNegocio();
            perNeg.Save(AlumnoActual);
            
        }
        public override bool Validar() 
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) ||
                string.IsNullOrEmpty(this.txtDireccion.Text) || string.IsNullOrEmpty(this.txtEmail.Text) ||
                string.IsNullOrEmpty(this.txtTelefono.Text) || string.IsNullOrEmpty(this.txtLegajo.Text) 
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
