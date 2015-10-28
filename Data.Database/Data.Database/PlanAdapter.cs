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
    public class PlanAdapter: Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("SELECT * FROM planes", SqlConn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {

                    Plan plan = new Plan();
                    plan.Id = (int)drPlanes["id_plan"];
                    plan.DescripcionPlan = (string)drPlanes["desc_plan"];
                    plan.IdEspecialidad = (int)drPlanes["id_especialidad"];

                    planes.Add(plan);
                }

                drPlanes.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return planes;
        }

        public Plan GetOne(int ID)
        {

            Plan plan = new Plan();
            try
            {

                this.OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes where id_plan = @id", SqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlan.ExecuteReader();
                if (drPlanes.Read())
                {

                    plan.Id = (int)drPlanes["id_plan"];
                    plan.DescripcionPlan = (string)drPlanes["desc_plan"];
                    plan.IdEspecialidad = (int)drPlanes["id_especialidad"];

                }

                drPlanes.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar un plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }

            return plan;
        }
        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into planes(desc_plan,id_especialidad) values( @desc_plan,@id_especialidad)" +
                    " select @@identity AS id_plan", SqlConn);

                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.DescripcionPlan;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;

                plan.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());


            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos del plan", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE planes SET desc_plan = @desc_plan, " +
                    "id_especialidad = @id_especialidad WHERE id_plan = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.Id;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.DescripcionPlan;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
    
                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del plan", Ex);
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
                    new SqlCommand("delete from planes where id_plan=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el plan", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(plan.Id);
            }
            else if (plan.Estado == Entidad.Estados.Nuevo)
            {
               this.Insert(plan);
            }
            else if (plan.Estado == Entidad.Estados.Modificado)
            {
               this.Update(plan);
            }
            plan.Estado = Entidad.Estados.NoModificado;
        }


    }
}
