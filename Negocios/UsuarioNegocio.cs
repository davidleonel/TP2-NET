using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Data.Database; 

namespace Negocios
{
    public class UsuarioNegocio: Negocio
    {
        #region Propiedades
        private UsuarioAdapter _UsuarioDatos;
        public UsuarioAdapter UsuarioDatos
        {
            get { return _UsuarioDatos; }
            set { _UsuarioDatos = value; }
        }
        #endregion
     
        #region Constructor
        public UsuarioNegocio()
        {
            this.UsuarioDatos = new UsuarioAdapter();
        } 
        #endregion

        #region Metodos

        public List<Usuario> GetAll() 
        {
            List<Usuario> ListaUsuarios = UsuarioDatos.GetAll();
            return ListaUsuarios;
        }

        public Usuario GetOne(int Id)
        {
            Usuario Usu = UsuarioDatos.GetOne(Id);
            return Usu;
        }

        public Usuario GetOne(string usu, string pass)
        {
            Usuario Usu = UsuarioDatos.GetOne(usu, pass);
            return Usu;
        }

        public void Delete(int Id)
        {
            UsuarioDatos.Delete(Id);
        }
        public void Save(Usuario Usu) 
        {
            UsuarioDatos.Save(Usu);


        }



        #endregion
    }
}
