using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AlumnoInscripcion:Entidad
    {
        #region Miembros
        private int _IdAlumno;
        private int _IdCurso;
        private string _Condicion;
        private int _Nota;
        #endregion 
        
        #region Propiedades
        public int IdAlumno
        {
            get { return _IdAlumno; }
            set { _IdAlumno = value; }
        }

        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        #endregion 
    }
}
