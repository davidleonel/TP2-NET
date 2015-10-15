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
    public partial class UsuariosEscritorio : Form
    {
        public UsuariosEscritorio()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            UsuarioNegocio ul = new UsuarioNegocio();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void UsuariosEscritorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academiaDataSet.usuarios' table. You can move, or remove it, as needed.
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

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // FALTA PASO 24
        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    UsuarioEscritorio usrEsc = new UsuarioEscritorio(ApplicationForm.ModoForm.Alta);
        //    usrEsc.ShowDialog();
       //   this.Listar();    
       // }

       /* private void toolStripButton2_Click(object sender, EventArgs e)
        {


            int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
            UsuarioEscritorio usrEsc = new UsuarioEscritorio(ApplicationForm.ModoForm.Modificacion);


            usrEsc.ShowDialog();
            this.Listar();
        }
        */
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                UsuarioEscritorio usrEsc = new UsuarioEscritorio(ID, ApplicationForm.ModoForm.Baja);
                usrEsc.ShowDialog();
                this.Listar();
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioEscritorio usrEsc = new UsuarioEscritorio(ApplicationForm.ModoForm.Alta);
            usrEsc.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

             if ( dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                UsuarioEscritorio usrEsc = new UsuarioEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                usrEsc.ShowDialog();
                this.Listar();
            }
        }
    }
}
