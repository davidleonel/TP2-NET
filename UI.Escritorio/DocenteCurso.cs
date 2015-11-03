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
    public partial class DocenteCursoEscritorio : ApplicationForm
    {
        #region Propiedades
        private DocenteCurso _DocenteCursoActual;

        public DocenteCurso DocenteCursoActual
        {
            get { return _DocenteCursoActual; }
            set { _DocenteCursoActual = value; }
        }
        #endregion //ver si no está de mas

        #region Constructores
        public DocenteCursoEscritorio()
        {
            InitializeComponent();
        }

        public DocenteCursoEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;
            this.cargarCbCurso();
           // this.cargarCbDocente();



        }

        public DocenteCursoEscritorio(int ID, ModoForm modo):this()
        {
            Modo = modo;
            DocenteCursoNegocio docCurEsc  = new DocenteCursoNegocio();
            DocenteCursoActual = docCurEsc.GetOne(ID);
            MapearDeDatos();
            this.cargarCbCurso();
            //this.cargarCbDocente();

        }
        #endregion

        #region Metodos

        private void cargarCbCurso()
        {
            CursoNegocio cn = new CursoNegocio();
            cbIdDocente.DataSource = cn.GetAll();
            cbIdDocente.DisplayMember = "Id";
            cbIdDocente.ValueMember = "Id";
        }

       /* private void cargarCbDocente()
        {
            P dcn = new DocenteCursoNegocio();
            cbIdCurso.DataSource = dcn.GetAll();
            cbIdCurso.DisplayMember = "DescripcionComision";
            cbIdCurso.ValueMember = "Id";
        }*/


        public override void MapearDeDatos() 
        {
            this.txtIdDocenteCurso.Text = this.DocenteCursoActual.Id.ToString();
            this.cbIdCurso.SelectedValue = this.DocenteCursoActual.IdCurso;
            this.txtCargo.Text = this.DocenteCursoActual.Cargo.ToString();
            this.cbIdDocente.SelectedValue = this.DocenteCursoActual.IdDocente;


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
                
                DocenteCursoActual = new DocenteCurso();

                this.DocenteCursoActual.IdDocente = Convert.ToInt32(this.cbIdDocente.SelectedValue);
                this.DocenteCursoActual.IdCurso = Convert.ToInt32(this.cbIdCurso.SelectedValue);
                this.DocenteCursoActual.Cargo = Convert.ToInt32(this.txtCargo.Text);


            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.DocenteCursoActual.Id = Convert.ToInt32(this.txtIdDocenteCurso.Text);
                this.DocenteCursoActual.IdDocente = Convert.ToInt32(this.cbIdDocente.SelectedValue);
                this.DocenteCursoActual.IdCurso = Convert.ToInt32(this.cbIdCurso.SelectedValue);
                this.DocenteCursoActual.Cargo = Convert.ToInt32(this.txtCargo.Text);

            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    DocenteCursoActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    DocenteCursoActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    DocenteCursoActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    DocenteCursoActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            DocenteCursoNegocio dcn = new DocenteCursoNegocio();
            dcn.Save(DocenteCursoActual);
            
        }
        public override bool Validar() 
        {
            //FALTA VALIDAR LOS COMBOS
            Boolean bandera = true;
            if ( string.IsNullOrEmpty(this.txtCargo.Text))
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
