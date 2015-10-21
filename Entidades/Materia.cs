using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia:Entidad
    {
        #region Miembros
        private string _DescripcionMateria;
        private int _HsSemanales;
        private int _HsTotales;
        private int _IdPlan;
        #endregion

        #region Propiedades

        
        public string DescripcionMateria
        {
            get { return _DescripcionMateria; }
            set { _DescripcionMateria = value; }
        }

        
        public int HsSemanales
        {
            get { return _HsSemanales; }
            set { _HsSemanales = value; }
        }

        
        public int HsTotales
        {
            get { return _HsTotales; }
            set { _HsTotales = value; }
        }

        
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
        #endregion
    }
}
