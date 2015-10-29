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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
