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
    public partial class Login : System.Web.UI.Page
    {
        #region Propiedades
        private UsuarioNegocio _UsuNegActual;

        public UsuarioNegocio UsuNegActual
        {
            get {
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
            get {
                if (_PersonaActual == null)
                {
                    _PersonaActual = new PersonaNegocio();
                }
                return _PersonaActual; }
     
        }
        
        
        
        #endregion 
        

        public Usuario GetOne()
        {
            Usuario usuarioActual = UsuNegActual.GetOne(this.usuarioTextBox.Text, this.passTextBox.Text);
            return usuarioActual;
        }
        
        public void ValidarUsuario()
        {

            Usuario UsuarioActual = this.GetOne();

            if (UsuarioActual.NombreUsuario == null)
            {
                noEncontradoLabel.Visible = true;
            }
            else
            {
                if (UsuarioActual.Clave != this.passTextBox.Text)
	                {
		               this.claveIncorrectaLabel.Visible = false;

	                }
                else
	                {
                        this.Session["UsuarioActual"] = UsuarioActual;
                        Response.Redirect("Menu.aspx?");
                    }
                }
            
        }
        
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aceptarButton_Click(object sender, EventArgs e)
        {
            this.ValidarUsuario();
        }
        
    }
}
