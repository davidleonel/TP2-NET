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
        private void Especialidades_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }
    }
}
