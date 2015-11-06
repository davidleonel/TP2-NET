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
    public partial class Especialidades : System.Web.UI.Page
    {
        #region Propiedades
        EspecialidadNegocio _EspNeg;
        private EspecialidadNegocio EspNeg
        {
            get
            {
                if (_EspNeg == null)
                {
                    _EspNeg = new EspecialidadNegocio();
                }
                return _EspNeg;
            }
        }

        private Especialidad EspActual
        {
            get;
            set;
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool isEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        #endregion

        #region Enumerador
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        #endregion

        #region Metodos
        private void LoadGrid()
        {
            this.EspecialidadesgridView.DataSource = this.EspNeg.GetAll();
            this.EspecialidadesgridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.EspActual = this.EspNeg.GetOne(id);
            this.idEspecialidadTextBox.Text = this.EspActual.Id.ToString();
            this.descEspecialidadTextBox.Text = this.EspActual.DescripcionEspecialidad;
        }

        private void LoadEntity(Especialidad especialidad)
        {
            especialidad.DescripcionEspecialidad = this.descEspecialidadTextBox.Text;
        }


        private void SaveEntity(Especialidad especialidad)
        {
            this.EspNeg.Save(especialidad);
        }

        private void EnableForm(bool enable)
        {

            this.descEspecialidadTextBox.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.EspNeg.Delete(id);
        }

        private void ClearForm()
        {
            this.idEspecialidadTextBox.Text = string.Empty;
            this.descEspecialidadTextBox.Text = string.Empty;
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
                 if (UsuarioActual.IdPersona == null)
                 {
                     this.gridActionsPanel.Visible = false;
                     this.incorrectoLabel.Visible = true;
                 }

                 else
                 {
                     if (!this.IsPostBack)
                     {
                         this.LoadGrid();
                     }
                 }
             }
         }
         protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
         {
             this.SelectedID = (int)this.EspecialidadesgridView.SelectedValue;
         }

         protected void aceptarLinkButton_Click(object sender, EventArgs e)
         {
             switch (this.FormMode)
             {
                 case FormModes.Baja:
                     this.DeleteEntity(this.SelectedID);
                     this.LoadGrid();
                     break;

                 case FormModes.Modificacion:
                     this.EspActual = new Especialidad();
                     this.EspActual.Id = this.SelectedID;
                     this.EspActual.Estado = Entidad.Estados.Modificado;
                     this.LoadEntity(this.EspActual);
                     this.SaveEntity(this.EspActual);
                     this.LoadGrid();
                     break;

                 case FormModes.Alta:

                     this.EspActual = new Especialidad();
                     this.LoadEntity(this.EspActual);
                     this.SaveEntity(this.EspActual);
                     this.LoadGrid();
                     break;

                 default:
                     break;
             }

             this.EspecialidadPanel.Visible = false;
         }

         protected void nuevoLinkButton_Click(object sender, EventArgs e)
         {


             this.FormMode = FormModes.Alta;
             this.EspecialidadPanel.Visible = true;
             this.ClearForm();
             this.EnableForm(true);

         }

         protected void editarLinkButton_Click(object sender, EventArgs e)
         {
             if (this.isEntitySelected)
             {
                 this.EspecialidadPanel.Visible = true;
                 this.FormMode = FormModes.Modificacion;
                 this.LoadForm(this.SelectedID);
                 this.EnableForm(true);
             }
         }

         protected void eliminarLinkButton_Click(object sender, EventArgs e)
         {
             if (this.isEntitySelected)
             {
                 this.EspecialidadPanel.Visible = true;
                 this.FormMode = FormModes.Baja;
                 this.LoadForm(this.SelectedID);
                 this.EnableForm(false);
             }
         }

        /*protected void cancelarLinkButton_Click(object sender, EventArgs e)
            {
                this.LoadGrid();
            }*/
        //preguntar si este evento es así

         #endregion

    }
}