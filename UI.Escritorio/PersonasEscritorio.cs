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
    public partial class PersonasEscritorio : Form
    {
        #region Constructor
        public PersonasEscritorio()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;
        }
        #endregion 

        #region Metodos
        public void Listar()
        {
            PersonaNegocio pn = new PersonaNegocio();
            this.dgvPersonas.DataSource = pn.GetAll();
        }
        #endregion 

        #region Eventos
        private void PersonasEscritorio_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).Id;
                PersonaEscritorio PerEsc = new PersonaEscritorio(ID, ApplicationForm.ModoForm.Baja);
                PerEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Persona si desea eliminar");
            }

        }
    }
}
