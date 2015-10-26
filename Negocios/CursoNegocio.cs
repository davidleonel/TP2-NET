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
        
        public void Save(Curso Cur)
        {
            CursoDatos.Save(Cur);

        }
        public List<Curso> GetAll()
        {
            List<Curso> ListaUsuarios = CursoDatos.GetAll();
            return ListaUsuarios;
        }

        public Curso GetOne(int Id)
        {
            Curso Cur = CursoDatos.GetOne(Id);
            return Cur;
        }


    }
}
