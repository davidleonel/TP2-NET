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
    public partial class CursoEscritorio : ApplicationForm
    {
        #region Propiedades
        private Curso _CursoActual;

        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }
        #endregion //ver si no está de mas

        #region Constructores
        public CursoEscritorio()
        {
            InitializeComponent();
        }

        public CursoEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;   

        }

        public CursoEscritorio(int ID, ModoForm modo):this()
        {
            Modo = modo;
            CursoNegocio usr  = new CursoNegocio();
            CursoActual = usr.GetOne(ID);
            MapearDeDatos();

        }
        #endregion

        #region Metodos
        public override void MapearDeDatos() 
        {
            this.txtIdCurso.Text = this.CursoActual.Id.ToString();
            this.txtIdMateria.Text = this.CursoActual.IdMateria.ToString(); ;
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.txtIdComision.Text = this.CursoActual.IdComision.ToString();



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
                
                CursoActual = new Curso();

                this.CursoActual.IdMateria = Convert.ToInt32(this.txtIdMateria.Text);
                this.CursoActual.IdComision = Convert.ToInt32(this.txtIdComision.Text);
                this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
                this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);

            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.CursoActual.Id = Convert.ToInt32(this.txtIdCurso.Text);
                this.CursoActual.IdMateria = Convert.ToInt32(this.txtIdMateria.Text);
                this.CursoActual.IdComision = Convert.ToInt32(this.txtIdComision.Text);
                this.CursoActual.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
                this.CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    CursoActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    CursoActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            CursoNegocio usrNeg = new CursoNegocio();
            usrNeg.Save(CursoActual);
            
        }
        public override bool Validar() 
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtIdMateria.Text) || string.IsNullOrEmpty(this.txtIdComision.Text) || string.IsNullOrEmpty(this.txtAnioCalendario.Text) ||
                string.IsNullOrEmpty(this.txtCupo.Text)  )
            {
                Notificar("Campos vacíos", "No puede haber campos sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            
            return bandera; 
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(this.Validar())
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
