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
    public partial class UsuarioEscritorio : ApplicationForm
    {
        #region Propiedades
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        #endregion 

        #region Constructores
        public UsuarioEscritorio()
        {
            InitializeComponent();
        }

        public UsuarioEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;   

        }

        public UsuarioEscritorio(int ID, ModoForm modo):this()
        {
            Modo = modo;
            UsuarioNegocio usr  = new UsuarioNegocio();
            UsuarioActual = usr.GetOne(ID);
            MapearDeDatos();

        }
        #endregion

        #region Metodos
        private void cargaTipoPersonas()
        {
            cbTipoPersonas.Items.Clear();

            cbTipoPersonas.Items.Add(new KeyValuePair<int, string>(0, "Administrador"));
            cbTipoPersonas.Items.Add(new KeyValuePair<int, string>(1, "Alumno"));
            cbTipoPersonas.Items.Add(new KeyValuePair<int, string>(2, "Docente"));
 
        }
        private void cargarCbPersonas()
        {
            EspecialidadNegocio en = new EspecialidadNegocio();
            cbPersonas.DataSource = en.GetAll();
            cbPersonas.DisplayMember = "NombreApe";
            cbPersonas.ValueMember = "Id";
        }


        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.Id.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.cbPersonas.SelectedValue = this.UsuarioActual.IdPersona;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario.ToString();
            this.txtClave.Text = this.UsuarioActual.Clave.ToString();
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave.ToString();


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
                
                UsuarioActual = new Usuario();

                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
                this.UsuarioActual.IdPersona = Convert.ToInt32(this.cbPersonas.SelectedValue);
            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Id = Convert.ToInt32(this.txtID.Text);
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
                this.UsuarioActual.IdPersona = Convert.ToInt32(this.cbPersonas.SelectedValue);

            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            UsuarioNegocio usrNeg = new UsuarioNegocio();
            usrNeg.Save(UsuarioActual);
            
        }
        public override bool Validar() 
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtUsuario.Text) ||
                string.IsNullOrEmpty(this.txtClave.Text) ||string.IsNullOrEmpty(this.txtConfirmarClave.Text) ) 
            {
                // string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) ||string.IsNullOrEmpty(this.txtEmail.Text
                Notificar("Campos vacíos", "No puede haber campos sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            else if (txtClave.Text != txtConfirmarClave.Text)
            {
                Notificar("Claves erróneas", "La clave debe coincidir con Confirmar Clave", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            else if (txtClave.Text.Length < 8)
            {
                Notificar("Clave inválida", "La clave debe poseer al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
