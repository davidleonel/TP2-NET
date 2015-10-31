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
    public partial class AlumnosEscritorio : Form
    {
       #region Constructor
        public AlumnosEscritorio()
        {
            InitializeComponent();
            this.dgvAlumnos.AutoGenerateColumns = false;
        }
         
	#endregion

       #region Metodos
		 public void Listar()
        {
            PersonaNegocio pn = new PersonaNegocio();
            this.dgvAlumnos.DataSource = pn.GetAllAlumnos();

        } 
        #endregion 

       #region Eventos

         private void AlumnosEscritorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academiaDataSet.Alumnos' table. You can move, or remove it, as needed.
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

        /*private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Persona)this.dgvAlumnos.SelectedRows[0].DataBoundItem).Id;
                AlumnoEscritorio perEsc = new AlumnoEscritorio(ID, ApplicationForm.ModoForm.Baja);
                perEsc.ShowDialog();
                this.Listar();
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoEscritorio perEsc = new AlumnoEscritorio(ApplicationForm.ModoForm.Alta);
            perEsc.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Persona)this.dgvAlumnos.SelectedRows[0].DataBoundItem).Id;
                AlumnoEscritorio docEsc = new AlumnoEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                docEsc.ShowDialog();
                this.Listar();
            }
        }
        #endregion 

    }
}
