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
    public partial class ComisionesEscritorio : Form
    {
       #region Constructor
        public ComisionesEscritorio()
        {
            InitializeComponent();
            this.dgvComisiones.AutoGenerateColumns = false;
        }
         
	#endregion

       #region Metodos
		 public void Listar()
        {
            ComisionNegocio cur = new ComisionNegocio();
            this.dgvComisiones.DataSource = cur.GetAll();
        } 
        #endregion 

       #region Eventos

         private void ComisionesEscritorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academiaDataSet.Comisiones' table. You can move, or remove it, as needed.
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

        /*private void dgvComisiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Id;
                //este constructor ya ejecuta getone
                ComisionEscritorio comEsc = new ComisionEscritorio(ID, ApplicationForm.ModoForm.Baja);
                comEsc.ShowDialog();
                this.Listar();
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionEscritorio comEsc = new ComisionEscritorio(ApplicationForm.ModoForm.Alta);
            comEsc.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

                if ( dgvComisiones.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Id;
                ComisionEscritorio curEsc = new ComisionEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                curEsc.ShowDialog();
                this.Listar();
            }
        }
        #endregion 
    }
}
