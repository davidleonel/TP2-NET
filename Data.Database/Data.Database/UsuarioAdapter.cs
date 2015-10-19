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
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
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
        #endregion //Debe ser eliminada porque los datos ahora están en una BD

        #region Metodos
        public List<Entidades.Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                //abrimos la conexion a la base de datos con el metodo que creamos antes
                this.OpenConnection();

                //creamos un objeto sqlcommand Que sera la sentencia SQL
                //que vamos a ejecutar contra la base de datos 
                //(los datos de la BD usuarios, contraseña, servidor, etc.
                //estan en el connection string)
                SqlCommand cmdUsuarios = new SqlCommand("select * from usuarios", SqlConn);

                //creo objeto datareader que será el que recupera los objetos de la BD
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                //Read() lee una fila de las devueltas por el comando sql
                //carga los datos en drUsuarios para poder accederlos
                //devuelve verdadero mientras haya podido leer datos
                //y avanza a la fila siguiente para el proximo read
                while (drUsuarios.Read())
                {
                    //creamos un objeto usuarios de la capa de entidades para
                    //copiar los datos de la fila del datareader al objeto de entidades
                    Usuario usr = new Usuario();

                    //ahora copiamos los datos de la fila al objeto
                    usr.Id = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];

                    //agregamos el objeto con datos a la lista que devolveremos
                    usuarios.Add(usr);
                }

                //cerramos el datareader y la conexion a la BD
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
            //devolvemos el objeto
            return usuarios;
        }

        public Entidades.Usuario GetOne(int ID)
        {
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
                        usr.Nombre = (string)drUsuarios["nombre"];
                        usr.Apellido = (string)drUsuarios["apellido"];
                        usr.Email = (string)drUsuarios["email"];
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

        }

        public void Delete(int ID)
        {
            try
            {
                //abrimos la conexion
                this.OpenConnection();

                //creamos la sentencia Sql y asignamos un valor al parametro
                SqlCommand cmdDelete =
                    new SqlCommand("delete from usuarios where id_usuario=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //ejecutamos la sentencia sql
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
                        "UPDATE usuarios SET nombre_usuario = @nombre_usuario, " +
                        "clave = @clave, habilitado = @habilitado, id_persona = @id_persona " +
                        "WHERE id_usuario = @id", SqlConn);


                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
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
                    "insert into usuarios (nombre_usuario,clave,habilitado,id_persona) " +
                    "values(@nombre_usuario,@clave,@habilitado,@id_persona) " +
                    "select @@identity", //esta linea es para recuperar el ID que asignó el sql automaticamente
                    SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();

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

        public void Save(Entidades.Usuario usuario)
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
