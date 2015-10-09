﻿using System;
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

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        public UsuarioEscritorio()
        {
            InitializeComponent();
        }

        public UsuarioEscritorio(ModoForm modo) : this()         {
            Modo = modo;           }
        public UsuarioEscritorio(int ID, ModoForm modo):this()        {            Modo = modo;
            UsuarioNegocio usr  = new UsuarioNegocio();
            UsuarioActual = usr.GetOne(ID);
            MapearDeDatos();

        }

        public virtual void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.Id.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido.ToString();
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario.ToString();
            this.txtEmail.Text = this.UsuarioActual.Email.ToString();
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
        public virtual void MapearADatos() 
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario usuario  = new Usuario();
                UsuarioActual = usuario;

                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Email =  this.txtEmail.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.Id = Convert.ToInt32(this.txtID.Text);
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
                this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
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
        public virtual void GuardarCambios() 
        {
            MapearDeDatos();
            UsuarioNegocio usrNeg = new UsuarioNegocio();
            usrNeg.Save(UsuarioActual);
        }
        public virtual bool Validar() 
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtUsuario.Text) || string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) ||
                string.IsNullOrEmpty(this.txtClave.Text) ||string.IsNullOrEmpty(this.txtConfirmarClave.Text) ||string.IsNullOrEmpty(this.txtEmail.Text) )
            {
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
        public void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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
    }
}
