using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocios
{
    public class alumnoInscripcionNegocio
    {
        #region Propiedades

        private AlumnoInscripcionAdapter _alumnoInscripcionDatos;

	    public AlumnoInscripcionAdapter alumnoInscripcionDatos
	    {
		    get { return _alumnoInscripcionDatos;}
		    set { _alumnoInscripcionDatos = value;}
	    }
	
        
        #endregion

        #region Constructor

        public alumnoInscripcionNegocio()
        {
            this.alumnoInscripcionDatos = new AlumnoInscripcionAdapter();
        }
        #endregion 

        #region Metodos
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> listaDocCurso = alumnoInscripcionDatos.GetAll();
            return listaDocCurso;
        }

        public AlumnoInscripcion GetOne(int id)
        {
            AlumnoInscripcion dc = alumnoInscripcionDatos.GetOne(id);
            return dc;
        }

        public void Save(AlumnoInscripcion docCur)
        {
            alumnoInscripcionDatos.Save(docCur);

        }

        public void Delete(int Id)
        {
            alumnoInscripcionDatos.Delete(Id);
        }

        #endregion
    }
}
