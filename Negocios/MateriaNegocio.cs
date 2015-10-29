﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocios
{
    public class MateriaNegocio: Negocio
    {
        #region Propiedades
        private MateriaAdapter _MateriaDatos;

        public MateriaAdapter MateriaDatos
        {
            get { return _MateriaDatos; }
            set { _MateriaDatos = value; }
        }
        
        #endregion

        #region Constructor
        public MateriaNegocio()
        {
            this.MateriaDatos = new MateriaAdapter();
        }
        #endregion 

        #region Metodos
        public List<Materia> GetAll()
        {
            List<Materia> listaMaterias = MateriaDatos.GetAll();
            return listaMaterias;
        }
        #endregion
    }
}
