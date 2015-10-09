using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan:Entidad
    {
        private string _DescripcionPlan;
        public string DescripcionPlan
        {
            get { return _DescripcionPlan; }
            set { _DescripcionPlan = value; }
        }

        private int _IdEspecialidad;
        public int IdEspecialidad
        {
            get { return _IdEspecialidad; }
            set { _IdEspecialidad = value; }
        }
    }
}
