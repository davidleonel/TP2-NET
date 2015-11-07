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
    public partial class MateriasEscritorio : Form
    {
        #region Constructor
        public MateriasEscritorio()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        } 
        #endregion

        #region Metodos
        public void Listar()
        {
            MateriaNegocio mn = new MateriaNegocio();
            this.dgvMaterias.DataSource = mn.GetAll();
 
        }
        #endregion

        #region Eventos
        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaEscritorio me = new MateriaEscritorio(ApplicationForm.ModoForm.Alta);
            me.ShowDialog();
            this.Listar();
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Id;
                MateriaEscritorio matEsc = new MateriaEscritorio( ID, ApplicationForm.ModoForm.Modificacion);
                matEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un plan para elimnar");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMaterias.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Id;
                MateriaEscritorio matEsc = new MateriaEscritorio(ID, ApplicationForm.ModoForm.Baja);
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
