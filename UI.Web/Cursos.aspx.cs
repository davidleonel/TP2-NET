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
    public partial class Cursos : System.Web.UI.Page
    {
        #region Propiedades
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

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        private Curso CursoActual
        {
            get;
            set;
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
            this.CursosgridView.DataSource = this.CurNeg.GetAll();
            this.CursosgridView.DataBind();
        }

        private void LoadForm(int id)
        {
            this.CursoActual = this.CurNeg.GetOne(id);
            this.idCursoTextBox.Text = this.CursoActual.Id.ToString();
            this.MateriaDropDownList.SelectedValue = this.CursoActual.IdMateria.ToString();
            this.ComisionDropDownList.SelectedValue = this.CursoActual.IdComision.ToString();
            this.anioCalendarioTextBox.Text = this.CursoActual.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.CursoActual.Cupo.ToString();
        }

        private void LoadEntity(Curso Curso)
        {

            Curso.IdMateria = Convert.ToInt32(this.MateriaDropDownList.SelectedValue);
            Curso.IdComision = Convert.ToInt32(this.ComisionDropDownList.SelectedValue);
            Curso.AnioCalendario = Convert.ToInt32(this.anioCalendarioTextBox.Text);
            Curso.Cupo = Convert.ToInt32(this.cupoTextBox.Text);
        }

        private void SaveEntity(Curso Curso)
        {
            this.CurNeg.Save(Curso);
        }

        private void EnableForm(bool enable)
        {

            this.anioCalendarioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
            this.ComisionDropDownList.Enabled = enable;
            this.MateriaDropDownList.Enabled = enable;

        }

        public void CargaDropDownListMaterias()
        {
            MateriaNegocio mn = new MateriaNegocio();

            this.MateriaDropDownList.DataSource = mn.GetAll();
            this.MateriaDropDownList.DataValueField = "Id";
            this.MateriaDropDownList.DataTextField = "DescripcionMateria";
            this.MateriaDropDownList.DataBind();
            this.MateriaDropDownList.Items.Insert(0, new ListItem("Seleccione Materia.", "0"));

        }

        public void CargaDropDownListComisiones()
        {
            ComisionNegocio cn = new ComisionNegocio();

            this.ComisionDropDownList.DataSource = cn.GetAll();
            this.ComisionDropDownList.DataValueField = "Id";
            this.ComisionDropDownList.DataTextField = "DescripcionComision";
            this.ComisionDropDownList.DataBind();
            this.ComisionDropDownList.Items.Insert(0, new ListItem("Seleccione Plan.", "0"));

        }

        private void DeleteEntity(int id)
        {
            this.CurNeg.Delete(id);
        }

        private void ClearForm()
        {
            this.idCursoTextBox.Text = string.Empty;
            this.anioCalendarioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
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
            this.SelectedID = (int)this.CursosgridView.SelectedValue;
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
                    this.CursoActual = new Curso();
                    this.CursoActual.Id = this.SelectedID;
                    this.CursoActual.Estado = Entidad.Estados.Modificado;
                    this.LoadEntity(this.CursoActual);
                    this.SaveEntity(this.CursoActual);
                    this.LoadGrid();
                    break;

                case FormModes.Alta:

                    this.CursoActual = new Curso();
                    this.LoadEntity(this.CursoActual);
                    this.SaveEntity(this.CursoActual);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.CursoPanel.Visible = false;
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {


            this.FormMode = FormModes.Alta;
            this.CursoPanel.Visible = true;
            this.ClearForm();
            this.EnableForm(true);
            this.CargaDropDownListMaterias();
            this.CargaDropDownListComisiones();

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.CursoPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.CargaDropDownListMaterias();
                this.CargaDropDownListComisiones();
                this.LoadForm(this.SelectedID);
                this.EnableForm(true);

            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.CursoPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.LoadForm(this.SelectedID);
                this.EnableForm(false);
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("~/Menu.aspx");
        }



        #endregion

    }
}