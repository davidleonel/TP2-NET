using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comision:Entidad
    {
        #region Miembros
        private string _DescripcionComision;
        private int _AnoEspecialidad;
        private int _IdPlan;
        #endregion

        #region Propiedades
        public string DescripcionComision
        {
            get { return _DescripcionComision; }
            set { _DescripcionComision = value; }
        }

        
        public int AnoEspecialidad
        {
            get { return _AnoEspecialidad; }
            set { _AnoEspecialidad = value; }
        }

        
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
        #endregion 
    }
}
