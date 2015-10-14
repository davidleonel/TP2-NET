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
    }
}