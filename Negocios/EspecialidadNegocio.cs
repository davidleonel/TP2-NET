using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database; 

namespace Negocios
{
    public class EspecialidadNegocio: Negocio
    {
        #region Propiedades
        private EspecialidadAdapter _EspecialidadDatos;

        public EspecialidadAdapter EspecialidadDatos
        {
            get { return _EspecialidadDatos; }
            set { _EspecialidadDatos = value; }
        } 
        #endregion

        #region Constructor
        public EspecialidadNegocio()
        {
            this.EspecialidadDatos = new EspecialidadAdapter();

        } 
        #endregion

        #region Metodos
        public List<Especialidad> GetAll()
        {
            List<Especialidad> listaEspecialidades = EspecialidadDatos.GetAll();
            return listaEspecialidades;

        }

        public Especialidad GetOne(int Id)
        {
            Especialidad esp = EspecialidadDatos.GetOne(Id);
            return esp;
        }

        public void Delete(int Id)
        {
            EspecialidadDatos.Delete(Id);
        }
        public void Save(Especialidad Esp)
        {
            EspecialidadDatos.Save(Esp);

        } 
        #endregion
    }
}
