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
    public partial class PlanEscritorio : ApplicationForm
    {
        #region Propiedades
        private Plan _PlanActual;

        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }
        
        #endregion

        #region Constructores
        public PlanEscritorio()
        {
            InitializeComponent();
        }

        public PlanEscritorio(ModoForm modo) : this()
        {
            this.Modo = modo;
            this.cargarCbEspecialidades();
        }

        public PlanEscritorio(int ID, ModoForm modo): this()
        {
            this.Modo = modo;
            PlanNegocio pn = new PlanNegocio();
            PlanActual = pn.GetOne(ID);
            this.MapearDeDatos();
        } 


        #endregion

        #region Metodos
        private void cargarCbEspecialidades()
        {
            EspecialidadNegocio en = new EspecialidadNegocio();
            cbEspecialidades.DataSource = en.GetAll();
            cbEspecialidades.DisplayMember = "DescripcionEspecialidad";
            cbEspecialidades.ValueMember = "Id";
        }
        /*public Especialidad buscarEspecialidad(int ID)
        {
            EspecialidadNegocio en = new EspecialidadNegocio();
            Especialidad esp = en.GetOne(ID);
            return esp;
        }*/

        public override void MapearDeDatos()
        {
            this.txtIdPlan.Text = this.PlanActual.Id.ToString();
            this.txtDescripcionPlan.Text = this.PlanActual.DescripcionPlan;
            this.cbEspecialidades.Text = this.PlanActual.IdEspecialidad.ToString();

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

                PlanActual = new Plan();

                this.PlanActual.DescripcionPlan = this.txtDescripcionPlan.Text;
                PlanActual.IdEspecialidad = Convert.ToInt32(this.cbEspecialidades.SelectedValue);

            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.PlanActual.Id = Convert.ToInt32(this.txtIdPlan.Text);
                this.PlanActual.DescripcionPlan = this.txtDescripcionPlan.Text;
                this.PlanActual.IdEspecialidad = Convert.ToInt32(this.cbEspecialidades.SelectedValue);
               
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    PlanActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    PlanActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    PlanActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PlanNegocio pn = new PlanNegocio();
            pn.Save(PlanActual);

        }

        public override bool Validar()
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtDescripcionPlan.Text) || Convert.ToInt32(this.cbEspecialidades.SelectedValue) == -1)
            {
                Notificar("Campos vacíos", "No puede dejar campos sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            return bandera;
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
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
