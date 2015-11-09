using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {


        #region Metodos
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> AlumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones", SqlConn);

                SqlDataReader drAlumnosInscripciones = cmdAlumnoInscripcion.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {

                    AlumnoInscripcion aluIns = new AlumnoInscripcion();

                    aluIns.Id = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluIns.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    aluIns.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                    aluIns.Condicion = (string)drAlumnosInscripciones["condicion"];
                    aluIns.Nota = (int)drAlumnosInscripciones["nota"];


                    AlumnosInscripciones.Add(aluIns);
                }

                drAlumnosInscripciones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return AlumnosInscripciones;
        }

        public List<AlumnoInscripcion> GetAll(int idCurso)
        {
            List<AlumnoInscripcion> AlumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones where id_curso = @id", SqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = idCurso;

                SqlDataReader drAlumnosInscripciones = cmdAlumnoInscripcion.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {

                    AlumnoInscripcion aluIns = new AlumnoInscripcion();

                    aluIns.Id = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluIns.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    aluIns.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                    aluIns.Condicion = (string)drAlumnosInscripciones["condicion"];
                    aluIns.Nota = (int)drAlumnosInscripciones["nota"];


                    AlumnosInscripciones.Add(aluIns);
                }

                drAlumnosInscripciones.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return AlumnosInscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {

            AlumnoInscripcion aluIns = new AlumnoInscripcion();
                try
                {

                    this.OpenConnection();
                    SqlCommand cmdAlumnoInscripcions = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", SqlConn);
                    cmdAlumnoInscripcions.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    
                    SqlDataReader drAlumnosInscripciones = cmdAlumnoInscripcions.ExecuteReader();
                    if (drAlumnosInscripciones.Read())
                    {
                        aluIns.Id = (int)drAlumnosInscripciones["id_inscripcion"];
                        aluIns.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                        aluIns.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                        aluIns.Condicion = (string)drAlumnosInscripciones["condicion"];
                        aluIns.Nota = (int)drAlumnosInscripciones["nota"];

                        
                    }

                    drAlumnosInscripciones.Close();

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de Alumnos", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                    
                }

                return aluIns;
            }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete from alumnos_inscripciones where id_inscripcion=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el Alumno", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion AlumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE alumnos_inscripciones set id_alumno= @id_alumno, id_curso= @id_curso," +
                    "condicion=@condicion, nota=@nota WHERE id_inscripcion=@id", SqlConn);


                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = AlumnoInscripcion.Id;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = AlumnoInscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = AlumnoInscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = AlumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = AlumnoInscripcion.Nota;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos del Alumnos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion AlumnoInscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into alumnos_inscripciones(id_alumno,id_curso,condicion,nota)" +

                    "values( @id_alumno,@id_curso,@condicion,@nota)" +

                    " select @@identity AS id_AlumnoInscripcion", SqlConn); 

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = AlumnoInscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = AlumnoInscripcion.IdCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = AlumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = AlumnoInscripcion.Nota;

                AlumnoInscripcion.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos del alumno", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(AlumnoInscripcion AlumnoInscripcion)
        {
            if (AlumnoInscripcion.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(AlumnoInscripcion.Id);
            }
            else if (AlumnoInscripcion.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(AlumnoInscripcion);
            }
            else if (AlumnoInscripcion.Estado == Entidad.Estados.Modificado)
            {
                this.Update(AlumnoInscripcion);
            }
            AlumnoInscripcion.Estado = Entidad.Estados.NoModificado;
        }

        #endregion
    }
}
