using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Escritorio
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnABMUsuario_Click(object sender, EventArgs e)
        {
            UsuariosEscritorio usuEsc = new UsuariosEscritorio();
            usuEsc.ShowDialog();
        }

        private void btnABMEspecialidades_Click(object sender, EventArgs e)
        {
            EspecialidadesEscritorio espEsc = new EspecialidadesEscritorio();
            espEsc.ShowDialog();
        }

        private void btnABMComisiones_Click(object sender, EventArgs e)
        {
            ComisionesEscritorio comEsc = new ComisionesEscritorio();
            comEsc.ShowDialog();
        }

        private void btnABMCursos_Click(object sender, EventArgs e)
        {
            CursosEscritorio curEsc = new CursosEscritorio();
            curEsc.ShowDialog();
        }

        private void btnABMPlanes_Click(object sender, EventArgs e)
        {
            PlanesEscritorio plaEsc = new PlanesEscritorio();
            plaEsc.ShowDialog();
        }

        private void btnABMMaterias_Click(object sender, EventArgs e)
        {
            MateriasEscritorio matEsc = new MateriasEscritorio();
            matEsc.ShowDialog();
        }
    }
}
