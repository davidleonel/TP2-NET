using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comision:Entidad
    {
        #region Propiedades

        private string _DescripcionComision;
        public string DescripcionComision
        {
            get { return _DescripcionComision; }
            set { _DescripcionComision = value; }
        }

        private int _AnioEspecialidad;
        public int AnioEspecialidad
        {
            get { return _AnioEspecialidad; }
            set { _AnioEspecialidad = value; }
        }

        private int _IdPlan;
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
        #endregion 
    }
}
