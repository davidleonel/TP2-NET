using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database; 

namespace Negocios
{
    class EspecialidadNegocio
    {
        private EspecialidadAdapter _EspecialidadDatos;

        public EspecialidadAdapter EspecialidadDatos
        {
            get { return _EspecialidadDatos; }
            set { _EspecialidadDatos = value; }
        }

        

        public void Save(Especialidad Esp)
        {
            EspecialidadDatos.Save(Esp);

        }
    }
}
