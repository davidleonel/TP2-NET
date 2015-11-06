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
       #region Constructor
        public UsuariosEscritorio()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }
         
	#endregion

       #region Metodos
		 public void Listar()
        {
            UsuarioNegocio ul = new UsuarioNegocio();
            this.dgvUsuarios.DataSource = ul.GetAll();

        } 
        #endregion 

       #region Eventos

         private void UsuariosEscritorio_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academiaDataSet.usuarios' table. You can move, or remove it, as needed.
            this.Listar();
        }

         private void btnVerDatosPersonales_Click(object sender, EventArgs e)
         {
             if (dgvUsuarios.SelectedRows.Count > 0)
             {
                 int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                 UsuarioNegocio un = new UsuarioNegocio();
                 Usuario u = un.GetOne(ID);
                 int idPer = u.IdPersona;
                 PersonaNegocio pn = new PersonaNegocio();
                 Persona p = pn.GetOne(idPer);
                 MessageBox.Show("Id " + idPer + "\nNombre y apellido: " + p.NombreApe + "\nFecha de Nacimiento: " + p.FechaNacimiento +
                                 "\nDirección:  " + p.Direccion + "\nE-mail: " + p.Email + "\nTelefono: " + p.Telefono +
                                 "\nLegajo: " + p.Legajo + "\nCargo: " + p.TipoPersona);
             }
             else
             {
                 MessageBox.Show("Debe seleccionar una especialidad si desea editar");
             }
         }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                UsuarioEscritorio usrEsc = new UsuarioEscritorio(ID, ApplicationForm.ModoForm.Baja);
                usrEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una especialidad si desea editar");
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ha cargado sus datos personales alguna vez en este sistema?", "Datos Personales?", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                UsuarioEscritorio usrEsc = new UsuarioEscritorio(ApplicationForm.ModoForm.Alta);
                usrEsc.ShowDialog();
            }
            else if (result == DialogResult.No)
            {
                //PersonaEscritorio perEsc = PersonaEscritorio(ApplicationForm.ModoForm.Alta);
                //perEsc.ShowDialog;
            }
            else if (result == DialogResult.Cancel)
            {
                this.Close();
            }
           
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).Id;
                UsuarioEscritorio usrEsc = new UsuarioEscritorio(ID, ApplicationForm.ModoForm.Modificacion);
                usrEsc.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una especialidad si desea editar");
            }
        }
        #endregion 



    }
}
