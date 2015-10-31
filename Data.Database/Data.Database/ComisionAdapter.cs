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
    public class ComisionAdapter:Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from comisiones", SqlConn);

                SqlDataReader drComisiones = cmdUsuarios.ExecuteReader();

                while (drComisiones.Read())
                {

                    Comision com = new Comision();

                    com.Id = (int)drComisiones["id_comision"];
                    com.DescripcionComision = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    com.IdPlan = (int)drComisiones["id_plan"];


                    comisiones.Add(com);
                }

                drComisiones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            {
                Comision com = new Comision();
                try
                {

                    this.OpenConnection();
                    SqlCommand cmdComision = new SqlCommand("select * from comisiones where id_comision = @id", SqlConn);
                    cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    SqlDataReader drComision = cmdComision.ExecuteReader();
                    if (drComision.Read())
                    {

                        com.Id = (int)drComision["id_comision"];
                        com.DescripcionComision = (string)drComision["desc_comision"];
                        com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                        com.IdPlan = (int)drComision["id_plan"];

                    }

                    drComision.Close();

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de comisiones", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();

                }

                return com;
            }

        }
        protected void Insert(Comision com)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into comisiones(desc_comision,anio_especialidad,id_plan)" +
                    "values( @desc_comision,@anio_especialidad,@id_plan)" +
                    " select @@identity AS id_comision", SqlConn); 

                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.DescripcionComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IdPlan;


                com.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());


            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos de la comision", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Comision com)
        {
            if (com.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(com.Id);
            }
            else if (com.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(com);
            }
            else if (com.Estado == Entidad.Estados.Modificado)
            {
                this.Update(com);
            }
            com.Estado = Entidad.Estados.NoModificado;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete from comisiones WHERE id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la comision", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision com)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                        "UPDATE comisiones set desc_comision=@desc_comision, anio_especialidad=@anio_especialidad," +
                        "id_plan=@id_plan WHERE id_comision=@id", SqlConn);
                
             

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = com.Id;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.DescripcionComision;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IdPlan;
                
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }


    }
}
