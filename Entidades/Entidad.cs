using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidad
    {

        #region Propiedades

        private int _Id;
        public int Id 
        {
            get {return _Id;}
            set {_Id = value;}
        }

        private Estados _Estado;
        public Estados Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        #endregion

        #region Constructores
        public Entidad()
        {
            this._Estado = Estados.Nuevo;
        }
        #endregion

        #region Enumeradores
        public enum Estados
        {
            Eliminado,
            Nuevo,
            Modificado,
            NoModificado
        } 
        #endregion

    }
}
