using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocios
{
    public class DocenteCursoNegocio
    {
        #region Propiedades

        private DocenteCursoAdapter _DocenteCursoDatos;

	    public DocenteCursoAdapter DocenteCursoDatos
	    {
		    get { return _DocenteCursoDatos;}
		    set { _DocenteCursoDatos = value;}
	    }
	
        
        #endregion

        #region Constructor

        public DocenteCursoNegocio()
        {
            this.DocenteCursoDatos = new DocenteCursoAdapter();
        }
        #endregion 

        #region Metodos
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> listaDocCurso = DocenteCursoDatos.GetAll();
            return listaDocCurso;
        }

        public DocenteCurso GetOne(int id)
        {
            DocenteCurso dc = DocenteCursoDatos.GetOne(id);
            return dc;
        }

        public void Save(DocenteCurso docCur)
        {
            DocenteCursoDatos.Save(docCur);

        }

        public void Delete(int Id)
        {
            DocenteCursoDatos.Delete(Id);
        }

        #endregion
    }
}
