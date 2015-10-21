using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona:Entidad
    {

        #region Miembros
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private string _Telefono;
        private DateTime _FechaNacimiento;
        private int _Legajo;
        private int _TipoPersona;
        private int _IdPlan;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        
        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }

        
        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }

        
        public int TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }

        #endregion
    }
}
