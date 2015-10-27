using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database; 

namespace Negocios
{
    public class ComisionNegocio
    {
        private ComisionAdapter _ComisionDatos;

        public ComisionAdapter ComisionDatos
        {
            get { return _ComisionDatos; }
            set { _ComisionDatos = value; }
        }


        public ComisionNegocio()
        {
            this.ComisionDatos = new ComisionAdapter();
        }

        public void Save(Comision Com)
        {
            ComisionDatos.Save(Com);

        }

        public List<Comision> GetAll()
        {
            List<Comision> ListaComisiones = ComisionDatos.GetAll();
            return ListaComisiones;
        }

        public Comision GetOne(int Id)
        {
            Comision Com = ComisionDatos.GetOne(Id);
            return Com;
        }
        
    }
}
