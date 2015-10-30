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
    public partial class MateriaEscritorio : ApplicationForm
    {
        #region Propiedades
        private Materia _MatActual;

        public Materia MatActual
        {
            get { return _MatActual; }
            set { _MatActual = value; }
        }
        
        #endregion 

        #region Constructores
        public MateriaEscritorio()
        {
            InitializeComponent();
        }

        public MateriaEscritorio(ModoForm modo) : this()
        {
            Modo = modo;
            this.cargarCbPlanes();
        }

        public MateriaEscritorio(int ID,ModoForm modo): this()
        {
            this.Modo = modo;
            MateriaNegocio mn = new MateriaNegocio();
            MatActual = mn.GetOne(ID);
            this.cargarCbPlanes();
            this.MapearDeDatos();
        } 
        #endregion

        #region Metodos
        private void cargarCbPlanes()
        {
            PlanNegocio pn = new PlanNegocio();
            cbPlanes.DataSource = pn.GetAll();
            cbPlanes.DisplayMember = "DescripcionPlan";
            cbPlanes.ValueMember = "Id";
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MatActual.Id.ToString();
            this.txtDescripcion.Text = this.MatActual.DescripcionMateria;
            this.txtHsSem.Text = this.MatActual.HsSemanales.ToString();
            this.txtHsTot.Text = this.MatActual.HsTotales.ToString();
            this.cbPlanes.SelectedValue = this.MatActual.IdPlan;

            switch (Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;

            }

        }
        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {

                MatActual = new Materia();

                this.MatActual.DescripcionMateria = this.txtDescripcion.Text;
                this.MatActual.HsSemanales =Convert.ToInt32(this.txtHsSem.Text);
                this.MatActual.HsTotales = Convert.ToInt32(this.txtHsTot.Text);
                this.MatActual.IdPlan = Convert.ToInt32(this.cbPlanes.SelectedValue);


            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.MatActual.Id = Convert.ToInt32(this.txtID.Text);
                this.MatActual.DescripcionMateria = this.txtDescripcion.Text;
                this.MatActual.HsSemanales = Convert.ToInt32(this.txtHsSem.Text);
                this.MatActual.HsTotales = Convert.ToInt32(this.txtHsTot.Text);
                this.MatActual.IdPlan = Convert.ToInt32(this.cbPlanes.SelectedValue);

            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    MatActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    MatActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    MatActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    MatActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaNegocio matNeg = new MateriaNegocio();
            matNeg.Save(MatActual);

        }

        public override bool Validar()
        {

            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtDescripcion.Text)) //falta validar que se completen hsSemanales y hsTotales
            {
                Notificar("Campos vacíos", "No puede dejar estos campos sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            return bandera;
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        #endregion 

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
