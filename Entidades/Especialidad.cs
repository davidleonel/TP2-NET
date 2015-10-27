using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad:Entidad
    {
        #region Propiedades
   
        private string _DescripcionEspecialidad;

        public string DescripcionEspecialidad
        {
            get { return _DescripcionEspecialidad; }
            set { _DescripcionEspecialidad = value; }
        }
        #endregion
    }
}
