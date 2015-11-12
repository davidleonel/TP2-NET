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
    public class CursoAdapter: Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", SqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {

                    Curso cur = new Curso();

                    cur.Id = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Cupo = (int)drCursos["cupo"];


                    cursos.Add(cur);
                }

                drCursos.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }


        public Curso GetOne(int ID)
        {
            {
                Curso cur = new Curso();
                try
                {

                    this.OpenConnection();
                    SqlCommand cmdUsuarios = new SqlCommand("select * from cursos where id_curso = @id", SqlConn);
                    cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    SqlDataReader drCursos = cmdUsuarios.ExecuteReader();
                    if (drCursos.Read())
                    {

                        cur.Id = (int)drCursos["id_curso"];
                        cur.IdMateria = (int)drCursos["id_materia"];
                        cur.IdComision = (int)drCursos["id_comision"];
                        cur.AnioCalendario = (int)drCursos["anio_calendario"];
                        cur.Cupo = (int)drCursos["cupo"];

                    }

                    drCursos.Close();

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de cursos", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();

                }

                return cur;
            }

        }

        protected void Insert(Curso cur)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into cursos(id_materia,id_comision,anio_calendario,cupo)" +
                    "values( @id_materia,@id_comision,@anio_calendario,@cupo)" +
                    " select @@identity AS id_curso", SqlConn); //esta linea es para recuperar el ID que asignó el sql automaticamente

                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = cur.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = cur.IdComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;
     
                cur.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //cmdSave.ExecuteNonQuery();
                /*PREGUNTAR: SI EXECUTEESCALAR ADEMAS DE DEVOLVER EL ID EJECUTA EL INSERT ALTA DUDA*/


            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos del curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        public void Save(Curso cur)
        {
            if (cur.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(cur.Id);
            }
            else if (cur.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(cur);
            }
            else if (cur.Estado == Entidad.Estados.Modificado)
            {
                this.Update(cur);
            }
            cur.Estado = Entidad.Estados.NoModificado;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete from cursos where id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Curso cur)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE cursos set id_materia= @id_materia, id_comision= @id_comision," +
                    "anio_calendario=@anio_calendario, cupo=@cupo WHERE id_curso=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = cur.Id;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = cur.IdMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = cur.IdComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = cur.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = cur.Cupo;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
    }
}
