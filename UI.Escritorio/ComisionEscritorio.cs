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
    public partial class ComisionEscritorio : ApplicationForm
    {
        #region Propiedades
        private Comision _ComisionActual;

        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }
        #endregion //ver si no está de mas

        #region Constructores
        public ComisionEscritorio()
        {
            InitializeComponent();
        }

        public ComisionEscritorio(ModoForm modo) : this() 
        {
            Modo = modo;   

        }

        public ComisionEscritorio(int ID, ModoForm modo):this()
        {
            Modo = modo;
            ComisionNegocio com  = new ComisionNegocio();
            ComisionActual = com.GetOne(ID);
            MapearDeDatos();

        }
        #endregion

        #region Metodos
        public override void MapearDeDatos() 
        {

            this.txtIDCom.Text = this.ComisionActual.Id.ToString();
            this.txtDescCom.Text = this.ComisionActual.DescripcionComision.ToString();
            this.txtAnioEsp.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIdPlan.Text = this.ComisionActual.IdPlan.ToString();



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
                
                ComisionActual = new Comision();

                this.ComisionActual.DescripcionComision =this.txtDescCom.Text;
                this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEsp.Text);
                this.ComisionActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);


            }
            else if (Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.Id = Convert.ToInt32(this.txtAnioEsp.Text);
                this.ComisionActual.DescripcionComision = this.txtDescCom.Text;
                this.ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEsp.Text);
                this.ComisionActual.IdPlan = Convert.ToInt32(this.txtIdPlan.Text);
            }

            switch (Modo)
            {
                case ModoForm.Alta:
                    ComisionActual.Estado = Entidad.Estados.Nuevo;
                    break;
                case ModoForm.Baja:
                    ComisionActual.Estado = Entidad.Estados.Eliminado;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.Estado = Entidad.Estados.NoModificado;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.Estado = Entidad.Estados.Modificado;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            this.MapearADatos();
            ComisionNegocio comNeg = new ComisionNegocio();
            comNeg.Save(ComisionActual);
            
        }
        public override bool Validar() 
        {
            Boolean bandera = true;
            if (string.IsNullOrEmpty(this.txtDescCom.Text) || string.IsNullOrEmpty(this.txtAnioEsp.Text) || string.IsNullOrEmpty(this.txtIdPlan.Text))
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
