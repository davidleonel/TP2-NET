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
    public partial class EspecialidadEscritorio_ : ApplicationForm
    {
        #region Propiedad
        private Especialidad _EspActual;

        public Especialidad EspActual
        {
            get { return _EspActual; }
            set { _EspActual = value; }
        } 
        #endregion

        #region Constructores
        public EspecialidadEscritorio_()
        {
            InitializeComponent();
        }

        public EspecialidadEscritorio_(ModoForm modo) : this() 
        {
            Modo = modo;   

        }

        public EspecialidadEscritorio_(int ID, ModoForm modo):this()
        {
            Modo = modo;
            EspecialidadNegocio esp  = new EspecialidadNegocio();
            EspActual = esp.GetOne(ID);
            this.MapearDeDatos();

        }
        #endregion 

        #region Metodos

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspActual.Id.ToString();
            this.txtDesc.Text = this.EspActual.DescripcionEspecialidad;

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

                EspActual = new Especialidad();

                this.EspActual.DescripcionEspecialidad = this.txtDesc.Text;

            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.EspActual.Id = Convert.ToInt32(this.txtID.Text);
                this.EspActual.DescripcionEspecialidad = this.txtDesc.Text;

            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    EspActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    EspActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    EspActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    EspActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadNegocio espNeg = new EspecialidadNegocio();
            espNeg.Save(_EspActual);

        }

        public override bool Validar()
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtDesc.Text))
            {
                Notificar("Campo vacío", "No puede dejar este campo sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
