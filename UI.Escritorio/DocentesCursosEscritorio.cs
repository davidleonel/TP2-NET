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
    public partial class DocentesCursosEscritorio : Form
    {
        #region Constructor
        public DocentesCursosEscritorio()
        {
            InitializeComponent();
            this.dgvDocentesCursos.AutoGenerateColumns = false;
        } 
        #endregion

        #region Metodos
        public void Listar()
        {
            DocenteCursoNegocio dcn = new DocenteCursoNegocio();
            this.dgvDocentesCursos.DataSource = dcn.GetAll();
 
        }
        #endregion

        #region Eventos
        private void DocentesCursos_Load(object sender, EventArgs e)
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
            DocenteCursoEscritorio dce = new DocenteCursoEscritorio(ApplicationForm.ModoForm.Alta);
            dce.ShowDialog();
            this.Listar();
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDocentesCursos.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).Id;
                DocenteCursoEscritorio docCurEsc = new DocenteCursoEscritorio( ID, ApplicationForm.ModoForm.Modificacion);
                docCurEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un docente para elimnar");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDocentesCursos.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).Id;
                DocenteCursoEscritorio matEsc = new DocenteCursoEscritorio(ID, ApplicationForm.ModoForm.Baja);
                matEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un plan para elimnar");
            }

        }
        #endregion
    }
}
