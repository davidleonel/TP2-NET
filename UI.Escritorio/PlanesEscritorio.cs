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


namespace UI.Escritorio
{
    public partial class PlanesEscritorio : Form
    {
        #region Constructor
        public PlanesEscritorio()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }
        
        #endregion

        #region Metodos
        private void Listar()
        {
            PlanNegocio pn = new PlanNegocio();
            this.dgvPlanes.DataSource = pn.GetAll();
            
        }
        #endregion 

        #region Eventos
        private void Planes_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanEscritorio planEsc = new PlanEscritorio(ApplicationForm.ModoForm.Alta);
            planEsc.ShowDialog();
            this.Listar();
        }

        #endregion

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                PlanEscritorio planEsc = new PlanEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                planEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un plan para elimnar");
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlanes.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).Id;
                PlanEscritorio planEsc = new PlanEscritorio(ID, ApplicationForm.ModoForm.Baja);
                planEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un plan para elimnar");
            }
        }




    }
}
