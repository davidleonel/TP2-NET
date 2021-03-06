using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
      /*  #region DatosEnMemoria
        // Esta regi�n solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta ser� eliminada
        private static List<Entidades.Usuario> _Usuarios;

        private static List<Entidades.Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Entidades.Usuario>();
                    Entidades.Usuario usr;
                    usr = new Entidades.Usuario();
                    usr.Id = 1;
                    usr.Estado = Entidades.Entidad.Estados.NoModificado;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Entidades.Usuario();
                    usr.Id = 2;
                    usr.Estado = Entidades.Entidad.Estados.NoModificado;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Entidades.Usuario();
                    usr.Id = 3;
                    usr.Estado = Entidades.Entidad.Estados.NoModificado;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion //Debe ser eliminada porque los datos ahora est�n en una BD
        */

        #region Metodos
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlConn);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {

                    Usuario usr = new Usuario();

                    usr.Id = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];

                    usuarios.Add(usr);
                }

                drUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            
                Usuario usr = new Usuario();
                try
                {

                    this.OpenConnection();
                    SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where id_usuario = @id", SqlConn);
                    cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                    if (drUsuarios.Read())
                    {

                        usr.Id = (int)drUsuarios["id_usuario"];
                        usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                        usr.Clave = (string)drUsuarios["clave"];
                        usr.Habilitado = (bool)drUsuarios["habilitado"];
                        usr.IdPersona = (int)drUsuarios["id_persona"];
  
                    }

                    drUsuarios.Close();

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de usuarios", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                    
                }

                return usr;
            }
        public Usuario GetOne(string usu, string pass)
        {

            Usuario usr = new Usuario();
            try
            {

                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios where nombre_usuario = @usu and clave =@pass", SqlConn);
                cmdUsuarios.Parameters.Add("@usu", SqlDbType.VarChar, 50).Value = usu;
                cmdUsuarios.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = pass;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {

                    usr.Id = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.IdPersona = (int)drUsuarios["id_persona"];
                    /* usr.Nombre = (string)drUsuarios["nombre"];
                     usr.Apellido = (string)drUsuarios["apellido"];
                     usr.Email = (string)drUsuarios["email"];*/


                }

                drUsuarios.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }

            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete from usuarios where id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE usuarios set nombre_usuario= @nombre_usuario, clave= @clave,"+
                    "habilitado=@habilitado WHERE id_usuario=@id", SqlConn);


                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into usuarios(nombre_usuario,clave,habilitado, id_persona)" +
                    "values( @nombre_usuario,@clave,@habilitado, @id_persona)" +
                    " select @@identity AS id_usuario", SqlConn);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IdPersona;
                usuario.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
               
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos del usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Usuario usuario)
        {
            if (usuario.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(usuario.Id);
            }
            else if (usuario.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(usuario);
            }
            else if (usuario.Estado == Entidad.Estados.Modificado)
            {
                this.Update(usuario);
            }
            usuario.Estado = Entidad.Estados.NoModificado;
        }

        #endregion
    }
}
