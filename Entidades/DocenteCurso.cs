﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DocenteCurso:Entidad
    {
        #region Propiedades

        private int _IdCurso;
        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        private int _IdDocente;
        public int IdDocente
        {
            get { return _IdDocente; }
            set { _IdDocente = value; }
        }

        private int _Cargo;
        public int Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
        #endregion
    }

}
