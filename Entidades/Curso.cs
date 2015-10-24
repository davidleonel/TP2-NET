﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso:Entidad
    {
        #region Propiedades

        private int _IdMateria;
        public int IdMateria
        {
            get { return _IdMateria; }
            set { _IdMateria = value; }
        }

        private int _IdComision;
        public int IdComision
        {
            get { return _IdComision; }
            set { _IdComision = value; }
        }

        private int _AnoCalendario;
        public int AnoCalendario
        {
            get { return _AnoCalendario; }
            set { _AnoCalendario = value; }
        }

        private int _Cupo;
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        #endregion
    }
}
