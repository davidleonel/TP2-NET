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

        private int _AnoEspecialidad;
        public int AnoEspecialidad
        {
            get { return _AnoEspecialidad; }
            set { _AnoEspecialidad = value; }
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
