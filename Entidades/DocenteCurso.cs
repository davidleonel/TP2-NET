using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DocenteCurso:Entidad
    {
        #region Miembros
        private int _IdCurso;
        private int _IdDocente;
        private int _Cargo;
        #endregion

        #region Propiedades
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        
        public int IdDocente
        {
            get { return _IdDocente; }
            set { _IdDocente = value; }
        }

        
        public int Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        #endregion
    }

}
