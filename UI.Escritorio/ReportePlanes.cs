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
    public partial class ReportePlanes : Form
    {
        public ReportePlanes()
        {
            InitializeComponent();
        }

        private void ReportePlanes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tP2DataSetPlanes.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.tP2DataSetPlanes.planes);

            this.reportViewer1.RefreshReport();
        }
    }
}
