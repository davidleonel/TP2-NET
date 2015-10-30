using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Data.Database
{
    public class MateriaAdapter: Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", SqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {

                    Materia mat = new Materia();

                    mat.Id = (int)drMaterias["id_materia"];
                    mat.DescripcionMateria = (string)drMaterias["desc_materia"];
                    mat.HsSemanales = (int)drMaterias["hs_semanales"];
                    mat.HsTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];

                    materias.Add(mat);
                }

                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return materias;
        }

        public Materia GetOne(int ID)
        {

            Materia mat = new Materia();
            try
            {

                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia = @id", SqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMateria = cmdMateria.ExecuteReader();
                if (drMateria.Read())
                {

                    mat.Id = (int)drMateria["id_materia"];
                    mat.DescripcionMateria = (string)drMateria["desc_materia"];
                    mat.HsSemanales = (int)drMateria["hs_semanales"];
                    mat.HsTotales = (int)drMateria["hs_totales"];
                    mat.IdPlan = (int)drMateria["id_plan"];

                }

                drMateria.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar una materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();

            }

            return mat;
        }

        public void Save(Materia mat)
        {
            if (mat.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(mat.Id);
            }
            else if (mat.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(mat);
            }
            else if (mat.Estado == Entidad.Estados.Modificado)
            {
                this.Update(mat);
            }
            mat.Estado = Entidad.Estados.NoModificado;
        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "insert into materias(desc_materia,hs_semanales,hs_totales,id_plan)" +
                    "values( @desc_materia,@hs_semanales,@hs_totales,@id_plan)" +
                    " select @@identity AS id_materia", SqlConn);

                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.DescripcionMateria;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IdPlan;

                mat.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos de la materia", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();

            }

        }

        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE materias SET desc_materia = @desc_materia, hs_semanales=@hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan" +
                    " WHERE id_materia = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mat.Id;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.DescripcionMateria;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HsSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HsTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IdPlan;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la materia", Ex);
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
                    new SqlCommand("delete from materias where id_materia=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

    }
}
