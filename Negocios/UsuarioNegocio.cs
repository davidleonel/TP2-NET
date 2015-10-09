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
        public UsuarioNegocio()
        {
            //UsuarioNegocio UsuNeg = new UsuarioNegocio();
            this.UsuarioDatos = new UsuarioAdapter();
        }
        
        private UsuarioAdapter _UsuarioDatos;
        public UsuarioAdapter UsuarioDatos
        {
            get{return _UsuarioDatos;}
            set{_UsuarioDatos= value; }
        }

        public Usuario GetOne(int Id) 
        {
            Usuario Usu = UsuarioDatos.GetOne(Id);
            return Usu;
        }
        public List<Usuario> GetAll() 
        {
            List<Usuario> ListaUsuarios = UsuarioDatos.GetAll();
            return ListaUsuarios;
        }
        public void Save(Usuario Usu) 
        {
            UsuarioDatos.Save(Usu);
        }
        public void Delete(int Id) 
        {
            UsuarioDatos.Delete(Id);
        }   
    }
}
