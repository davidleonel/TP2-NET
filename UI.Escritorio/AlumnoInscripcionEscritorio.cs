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
    public partial class alumnoInscripcionEscritorio : ApplicationForm
    {
        #region Propiedades
        private AlumnoInscripcion _alumnoInscripcionActual;

        public AlumnoInscripcion alumnoInscripcionActual
        {
            get { return _alumnoInscripcionActual; }
            set { _alumnoInscripcionActual = value; }
        }
        #endregion //ver si no está de mas

        #region Constructores
        public alumnoInscripcionEscritorio()
        {
            InitializeComponent();
        }

        public alumnoInscripcionEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;
            this.cargarCbCurso();
            this.cargarCbAlumno();



        }

        public alumnoInscripcionEscritorio(int ID, ModoForm modo):this()
        {
            Modo = modo;
            alumnoInscripcionNegocio aluInsEsc  = new alumnoInscripcionNegocio();
            alumnoInscripcionActual = aluInsEsc.GetOne(ID);
            MapearDeDatos();
            this.cargarCbCurso();
            this.cargarCbAlumno();

        }
        #endregion

        #region Metodos

        private void cargarCbCurso()
        {
            CursoNegocio cn = new CursoNegocio();
            cbIdCurso.DataSource = cn.GetAll();
            cbIdCurso.DisplayMember = "Id";
            cbIdCurso.ValueMember = "Id";
        }

        private void cargarCbAlumno()
        {

            PersonaNegocio pn = new PersonaNegocio();
            cbIdAlumno.DataSource = pn.GetAllAlumnos();
            cbIdAlumno.DisplayMember = "Nombre";
            cbIdAlumno.ValueMember = "Id";
        }


        public override void MapearDeDatos() 
        {
            this.txtIdalumnoInscripcion.Text = this.alumnoInscripcionActual.Id.ToString();
            this.cbIdAlumno.SelectedValue = this.alumnoInscripcionActual.IdAlumno;
            this.txtCondicion.Text = this.alumnoInscripcionActual.Condicion.ToString();
            this.txtNota.Text = this.alumnoInscripcionActual.Nota.ToString();
            this.cbIdCurso.SelectedValue = this.alumnoInscripcionActual.IdCurso;


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
                
                alumnoInscripcionActual = new AlumnoInscripcion();

                this.alumnoInscripcionActual.IdCurso = Convert.ToInt32(this.cbIdCurso.SelectedValue);
                this.alumnoInscripcionActual.IdAlumno = Convert.ToInt32(this.cbIdAlumno.SelectedValue);
                this.alumnoInscripcionActual.Condicion = this.txtCondicion.Text;
                this.alumnoInscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);


            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.alumnoInscripcionActual.Id = Convert.ToInt32(this.txtIdalumnoInscripcion.Text);
                this.alumnoInscripcionActual.IdCurso = Convert.ToInt32(this.cbIdCurso.SelectedValue);
                this.alumnoInscripcionActual.IdAlumno = Convert.ToInt32(this.cbIdAlumno.SelectedValue);
                this.alumnoInscripcionActual.Condicion = this.txtCondicion.Text;
                this.alumnoInscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);

            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    alumnoInscripcionActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    alumnoInscripcionActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    alumnoInscripcionActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    alumnoInscripcionActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            alumnoInscripcionNegocio ain = new alumnoInscripcionNegocio();
            ain.Save(alumnoInscripcionActual);
            
        }
        public override bool Validar() 
        {
            //FALTA VALIDAR LOS COMBOS
            Boolean bandera = true;
            if ( string.IsNullOrEmpty(this.txtCondicion.Text))
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
