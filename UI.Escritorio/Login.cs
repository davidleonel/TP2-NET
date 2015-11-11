using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace UI.Escritorio
{
    public partial class Login : Form
    {
        #region Propiedades
        private UsuarioNegocio _UsuNegActual;

        public UsuarioNegocio UsuNegActual
        {
            get
            {
                if (_UsuNegActual == null)
                {
                    _UsuNegActual = new UsuarioNegocio();
                }

                return _UsuNegActual;
            }
        }
        
        private PersonaNegocio _PersonaActual;

        public PersonaNegocio PersonaActual
        {
            get
            {
                if (_PersonaActual == null)
                {
                    _PersonaActual = new PersonaNegocio();
                }
                return _PersonaActual;
            }

        }
        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
        } 
        #endregion
        public Usuario GetOne()
        {
            Usuario usuarioActual = UsuNegActual.GetOne(this.txtUsuario.Text, this.txtPass.Text);
            return usuarioActual;
        }
        public void ValidarUsuario()
        {

            Usuario UsuarioActual = this.GetOne();

            if (UsuarioActual.NombreUsuario == null)
            {
                MessageBox.Show("Usuario no registrado");
            }
            else
            {
                if (UsuarioActual.Clave != this.txtPass.Text)
                {
                    MessageBox.Show("Contraseña Incorrecta");

                }
                else
                {
                    this.Acceso(UsuarioActual.IdPersona);
                }
            }

        }

        public void Acceso(int idPersona)
        {
            Persona p = PersonaActual.GetOne(idPersona);
            switch (p.TipoPersona)
            {
                case Persona.TiposPersona.Administrador:
                    MenuAdmin mad = new MenuAdmin();
                    mad.ShowDialog();
                    break;
                case Persona.TiposPersona.Alumno:
                    MenuAlum mal = new MenuAlum();
                    mal.ShowDialog();
                    break;
                case Persona.TiposPersona.Docente:
                    MenuDoc mdo = new MenuDoc();
                    mdo.ShowDialog();
                    break;
                default:
                    break;
            }
 
        }
    
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.ValidarUsuario();
        }
    }
}
