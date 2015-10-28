using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database;

namespace Negocios
{
    public class PlanNegocio
    {
        #region Propiedades
        private PlanAdapter _PlanDatos;

        public PlanAdapter PlanDatos
        {
            get { return _PlanDatos; }
            set { _PlanDatos = value; }
        } 
        #endregion

        #region Constructor
        public PlanNegocio()
        {
            this.PlanDatos = new PlanAdapter();
        } 
        #endregion

        #region Metodos
        public List<Plan> GetAll()
        {
            List<Plan> listaPlanes = new List<Plan>();
            listaPlanes = PlanDatos.GetAll();
            return listaPlanes;
        }

        public Plan GetOne(int ID) 
        {
            Plan p = new Plan();
            p = PlanDatos.GetOne(ID);
            return p;
        }

        public void Delete(int Id)
        {
            PlanDatos.Delete(Id);
        }

        public void Save(Plan plan) 
        {
            PlanDatos.Save(plan);
        }
        #endregion 
    }
}
