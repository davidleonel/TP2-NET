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
    public partial class DocentesEscritorio : Form
    {
       #region Constructor
        public DocentesEscritorio()
        {
            InitializeComponent();
            this.dgvDocentes.AutoGenerateColumns = false;
        }
         
	#endregion

       #region Metodos
		 public void Listar()
        {
            PersonaNegocio pn = new PersonaNegocio();
            this.dgvDocentes.DataSource = pn.GetAllDocentes();

        } 
        #endregion 

       #region Eventos

         private void DocentesEscritorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academiaDataSet.Docentes' table. You can move, or remove it, as needed.
            this.Listar();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void dgvDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).Id;
                DocenteEscritorio perEsc = new DocenteEscritorio(ID, ApplicationForm.ModoForm.Baja);
                perEsc.ShowDialog();
                this.Listar();
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteEscritorio perEsc = new DocenteEscritorio(ApplicationForm.ModoForm.Alta);
            perEsc.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if (dgvDocentes.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).Id;
                DocenteEscritorio docEsc = new DocenteEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                docEsc.ShowDialog();
                this.Listar();
            }
        }
        #endregion 

    }
}
