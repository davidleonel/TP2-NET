using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia:Entidad
    {
        #region Propiedades

        private string _DescripcionMateria;
        public string DescripcionMateria
        {
            get { return _DescripcionMateria; }
            set { _DescripcionMateria = value; }
        }

        private int _HsSemanales;
        public int HsSemanales
        {
            get { return _HsSemanales; }
            set { _HsSemanales = value; }
        }

        private int _HsTotales;
        public int HsTotales
        {
            get { return _HsTotales; }
            set { _HsTotales = value; }
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
