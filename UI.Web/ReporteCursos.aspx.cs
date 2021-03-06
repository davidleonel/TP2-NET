﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace UI.Web
{
    
    public partial class ReporteCursos : System.Web.UI.Page
    {
        #region Propiedades
        PersonaNegocio _PerNeg;
        private PersonaNegocio PerNeg
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
                    this.OpcionesReportes.Visible = false;
                    this.incorrectoLabel.Visible = true;
                    this.cancelarLinkButton.Visible = false;
                    this.cancelarLinkButton2.Visible = true;
                }

            }

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Reportes.aspx");
        }
        protected void cancelarLinkButton2_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }
    }

        #endregion

}