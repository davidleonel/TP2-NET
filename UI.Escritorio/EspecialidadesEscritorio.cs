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
    public partial class EspecialidadesEscritorio : Form
    {
        #region Constructor
        public EspecialidadesEscritorio()
        {
            InitializeComponent();
            this.dgvEspecialidades.AutoGenerateColumns = false;

        }
        #endregion

        #region Metodos

        public void Listar()
        {
            EspecialidadNegocio en = new EspecialidadNegocio();
            this.dgvEspecialidades.DataSource = en.GetAll();
        }

        #endregion

        #region Eventos
        private void EspecialidadesEscritorio_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadEscritorio_ espEsc = new EspecialidadEscritorio_(ApplicationForm.ModoForm.Alta);
            espEsc.ShowDialog();
            this.Listar();
        }

        private void btnEditar_CLick(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
                EspecialidadEscritorio_ EspEsc = new EspecialidadEscritorio_(ID, ApplicationForm.ModoForm.Modificacion);
                EspEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una especialidad si desea editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEspecialidades.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).Id;
                EspecialidadEscritorio_ EspEsc = new EspecialidadEscritorio_(ID, ApplicationForm.ModoForm.Baja);
                EspEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una especialidad si desea eliminar");
            }

        }
        #endregion 
    }
}
