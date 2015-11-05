using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database; 

namespace Negocios
{
    public class PersonaNegocio: Negocio
    {
        #region Propiedades
        private PersonaAdapter _PersonaDatos;
        public PersonaAdapter PersonaDatos
        {
            get { return _PersonaDatos; }
            set { _PersonaDatos = value; }
        }
        #endregion
     
        #region Constructor
        public PersonaNegocio()
        {
            this.PersonaDatos = new PersonaAdapter();
        } 
        #endregion

        #region Metodos

        public List<Persona> GetAll() 
        {
            List<Persona> ListaPersonas = PersonaDatos.GetAll();
            return ListaPersonas;
        }

        public List<Persona> GetAllAlumnos()
        {
            List<Persona> ListaPersonas = PersonaDatos.GetAllAlumnos();
            return ListaPersonas;
        }


        public List<Persona> GetAllDocentes()
        {
            List<Persona> ListaPersonas = PersonaDatos.GetAllDocentes();
            return ListaPersonas;
        }

        public Persona GetOne(int Id)
        {
            Persona per = PersonaDatos.GetOne(Id);
            return per;
        }

        public void Delete(int Id)
        {
            PersonaDatos.Delete(Id);
        }
        public void Save(Persona per) 
        {
            PersonaDatos.Save(per);

        }



        #endregion
    }
}
