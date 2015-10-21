using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan:Entidad
    {

        #region Miembros
        private string _DescripcionPlan;
        private int _IdEspecialidad;
        #endregion

        #region Propiedades
        public string DescripcionPlan
        {
            get { return _DescripcionPlan; }
            set { _DescripcionPlan = value; }
        }

        
        public int IdEspecialidad
        {
            get { return _IdEspecialidad; }
            set { _IdEspecialidad = value; }
        }
        #endregion
    }
}
