using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad:Entidad
    {
        #region Miembros
        private string _DescripcionEspecialidad;
        #endregion

        #region Propiedades
        public string DescripcionEspecialidad
        {
            get { return _DescripcionEspecialidad; }
            set { _DescripcionEspecialidad = value; }
        }
        #endregion
    }
}
