using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {
        #region Metodos
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", SqlConn);

                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {

                    Especialidad esp = new Especialidad();

                    esp.Id = (int)drEspecialidades["id_especialidad"];
                    esp.DescripcionEspecialidad = (string)drEspecialidades["desc_especialidad"];

                    especialidades.Add(esp);
                }

                drEspecialidades.Close();

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

            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {

            Especialidad esp = new Especialidad();
            try
            {

                this.OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad = @id", SqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                if (drEspecialidades.Read())
                {

                    esp.Id = (int)drEspecialidades["id_especialidad"];
                    esp.DescripcionEspecialidad = (string)drEspecialidades["desc_especialidad"];

                }

                drEspecialidades.Close();

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

            return esp;
        }


        public void Save(Especialidad esp)
        {
            if (esp.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(esp.Id);
            }
            else if (esp.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(esp);
            }
            else if (esp.Estado == Entidad.Estados.Modificado)
            {
                this.Update(esp);
            }
            esp.Estado = Entidad.Estados.NoModificado;
        }

        protected void Insert(Especialidad esp)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into especialidades(desc_especialidad) values( @desc_especialidad)" +
                    " select @@identity AS id_especialidad", SqlConn);

                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.DescripcionEspecialidad;

                esp.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //cmdSave.ExecuteNonQuery();
                /*PREGUNTAR: SI EXECUTEESCALAR ADEMAS DE DEVOLVER EL ID EJECUTA EL INSERT ALTA DUDA*/


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

        protected void Update(Especialidad esp)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE especialidades set desc_especialidad= @desc_especialidad WHERE id_especialidad=@id", SqlConn);


                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = esp.Id;
                cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = esp.DescripcionEspecialidad;
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

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete from especialidades where id_especialidad=@id", SqlConn);
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


        #endregion
    }

}
