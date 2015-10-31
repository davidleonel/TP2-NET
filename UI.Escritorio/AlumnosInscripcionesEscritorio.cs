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
    public partial class alumnosInscripcionesEscritorio : Form
    {
        #region Constructor
        public alumnosInscripcionesEscritorio()
        {
            InitializeComponent();
            this.dgvalumnosInscripciones.AutoGenerateColumns = false;
        } 
        #endregion

        #region Metodos
        public void Listar()
        {
            alumnoInscripcionNegocio ain = new alumnoInscripcionNegocio();
            this.dgvalumnosInscripciones.DataSource = ain.GetAll();
 
        }
        #endregion

        #region Eventos
        private void alumnosInscripciones_Load(object sender, EventArgs e)
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
            alumnoInscripcionEscritorio aie = new alumnoInscripcionEscritorio(ApplicationForm.ModoForm.Alta);
            aie.ShowDialog();
            this.Listar();
        }


        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvalumnosInscripciones.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.AlumnoInscripcion)this.dgvalumnosInscripciones.SelectedRows[0].DataBoundItem).Id;
                alumnoInscripcionEscritorio aluInsEsc = new alumnoInscripcionEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                aluInsEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un docente para elimnar");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvalumnosInscripciones.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.AlumnoInscripcion)this.dgvalumnosInscripciones.SelectedRows[0].DataBoundItem).Id;
                alumnoInscripcionEscritorio matEsc = new alumnoInscripcionEscritorio(ID, ApplicationForm.ModoForm.Baja);
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
