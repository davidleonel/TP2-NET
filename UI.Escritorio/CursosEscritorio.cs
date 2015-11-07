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
    public partial class CursosEscritorio : Form
    {
       #region Constructor
        public CursosEscritorio()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }
         
	#endregion

       #region Metodos
		 public void Listar()
        {
            CursoNegocio cur = new CursoNegocio();
            this.dgvCursos.DataSource = cur.GetAll();
        } 
        #endregion 

       #region Eventos

         private void CursosEscritorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academiaDataSet.Cursos' table. You can move, or remove it, as needed.
            this.Listar();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }*/

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).Id;
                //este constructor ya ejecuta getone
                CursoEscritorio curEsc = new CursoEscritorio(ID, ApplicationForm.ModoForm.Baja);
                curEsc.ShowDialog();
                this.Listar();
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursoEscritorio curEsc = new CursoEscritorio(ApplicationForm.ModoForm.Alta);
            curEsc.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

                if ( dgvCursos.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).Id;
                CursoEscritorio curEsc = new CursoEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                curEsc.ShowDialog();
                this.Listar();
            }
        }
        #endregion 
    }
}
