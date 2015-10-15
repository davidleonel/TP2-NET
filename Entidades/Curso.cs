using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso:Entidad
    {
        #region Miembros
        private int _IdMateria;
        private int _IdComision;
        private int _AnoCalendario;
        private int _Cupo;
        #endregion
        
        #region Propiedades
        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }

        
        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }

        
        public int AnoCalendario
        {
            get { return _AnoCalendario; }
            set { _AnoCalendario = value; }
        }

        
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        #endregion
    }
}
