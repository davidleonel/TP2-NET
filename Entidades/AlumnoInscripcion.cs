using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInscripcion:Entidad
    {
        #region Propiedades

        private int _IdAlumno;
        public int IdAlumno
        {
            get { return _IdAlumno; }
            set { _IdAlumno = value; }
        }

        private int _IdCurso;
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        private string _Condicion;
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private int _Nota;
        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        #endregion 
    }
}
