using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database; 

namespace Negocios
{
    public class CursoNegocio
    {
        private CursoAdapter _CursoDatos;

        public CursoAdapter CursoDatos
        {
            get { return _CursoDatos; }
            set { _CursoDatos = value; }
        }
        
        #region Constructor
        public CursoNegocio()
        {
            this.CursoDatos = new CursoAdapter();
        } 
        #endregion

        public void Save(Curso Cur)
        {
            CursoDatos.Save(Cur);

        }
        public List<Curso> GetAll()
        {
            List<Curso> ListaCursos = CursoDatos.GetAll();
            return ListaCursos;
        }

        public Curso GetOne(int Id)
        {
            Curso Cur = CursoDatos.GetOne(Id);
            return Cur;
        }

        public void Delete(int Id)
        {
            CursoDatos.Delete(Id);
        }

    }
}
