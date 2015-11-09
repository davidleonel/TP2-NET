using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
/*
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

*/

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

        CursoNegocio _CurNeg;
        private CursoNegocio CurNeg
        {
            get
            {
                if (_CurNeg == null)
                {
                    _CurNeg = new CursoNegocio();
                }
                return _CurNeg;
            }
        }
        #endregion


        #region Metodos
        private void LoadGrid()
        {
            this.ReporteCursosgridView.DataSource = this.CurNeg.GetAll();
            this.ReporteCursosgridView.DataBind();
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
                    this.ReporteCursosgridPanel.Visible = false;
                    this.incorrectoLabel.Visible = true;
                    this.aceptarLinkButton.Visible = false;
                }

                else
                {
                    if (!this.IsPostBack)
                    {
                        this.LoadGrid();
                    }

                    //CrystalReportSource.ReportDocument.SetDatabaseLogon("", "", "localhost", "TP2");
                }
            }
        }





    
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

        

        }



        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }



        #endregion

    }
}