using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidad
    {
        #region Constructores
        public Entidad()
        {
            this._Estado = Estados.Nuevo;
        }
        #endregion

        #region Miembros
        private int _Id;
        private Estados _Estado;
        #endregion

        #region Propiedades

        public int Id 
        {
            get {return _Id;}
            set {_Id = value;}
        }

        
        public Estados Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        #endregion


        public enum Estados
        {
            Eliminado,
            Nuevo,
            Modificado,
            NoModificado
        }

    }
}
