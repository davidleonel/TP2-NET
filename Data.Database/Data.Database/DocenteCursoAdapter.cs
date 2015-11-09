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
     
    public class DocenteCursoAdapter:Adapter
    {

        #region Metodos
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCur = new SqlCommand("select * from docentes_cursos", SqlConn);

                SqlDataReader drDocCurso = cmdDocCur.ExecuteReader();

                while (drDocCurso.Read())
                {

                    DocenteCurso docCurso = new DocenteCurso();

                    docCurso.Id = (int)drDocCurso["id_dictado"];
                    docCurso.IdCurso = (int)drDocCurso["id_curso"];
                    docCurso.IdDocente = (int)drDocCurso["id_docente"];
                    docCurso.Cargo = (int)drDocCurso["cargo"];


                    docCursos.Add(docCurso);
                }

                drDocCurso.Close();

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

            return docCursos;
        }

        public List<DocenteCurso> GetAll(int idDoc)
        {
            List<DocenteCurso> docCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocCur = new SqlCommand("select * from docentes_cursos where id_docente = @id", SqlConn);
                cmdDocCur.Parameters.Add("@id", SqlDbType.Int).Value = idDoc;

                SqlDataReader drDocCurso = cmdDocCur.ExecuteReader();

                while (drDocCurso.Read())
                {

                    DocenteCurso docCurso = new DocenteCurso();

                    docCurso.Id = (int)drDocCurso["id_dictado"];
                    docCurso.IdCurso = (int)drDocCurso["id_curso"];
                    docCurso.IdDocente = (int)drDocCurso["id_docente"];
                    docCurso.Cargo = (int)drDocCurso["cargo"];


                    docCursos.Add(docCurso);
                }

                drDocCurso.Close();

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

            return docCursos;
        }

        public DocenteCurso GetOne(int ID)
        {
            
                DocenteCurso docCurso = new DocenteCurso();
                try
                {

                    this.OpenConnection();
                    SqlCommand cmdUsuarios = new SqlCommand("select * from docentes_cursos where id_dictado = @id", SqlConn);
                    cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    
                    SqlDataReader drDocCurso = cmdUsuarios.ExecuteReader();
                    
                    if (drDocCurso.Read())
                    {

                        docCurso.Id = (int)drDocCurso["id_dictado"];
                        docCurso.IdCurso = (int)drDocCurso["id_curso"];
                        docCurso.IdDocente = (int)drDocCurso["id_docente"];
                        docCurso.Cargo = (int)drDocCurso["cargo"];


                        
                    }

                    drDocCurso.Close();

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de Docentes", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                    
                }

                return docCurso;
            }

  

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete from docentes_cursos where id_dictado=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar el docente", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso docCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE docentes_cursos set id_curso= @id_curso, id_docente= @id_docente,"+
                    "cargo=@cargo WHERE id_dictado=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docCurso.Id;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCurso.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCurso.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCurso.Cargo;

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

        protected void Insert(DocenteCurso docCurso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into docentes_cursos(id_curso,id_docente,cargo)" +
                    "values( @id_curso,@id_docente,@cargo)" +
                    " select @@identity AS id_dictado", SqlConn); 

                cmdSave.Parameters.Add("@id_curso", SqlDbType.VarChar, 50).Value = docCurso.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.VarChar, 50).Value = docCurso.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCurso.Cargo;

                docCurso.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());



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

        public void Save(DocenteCurso docCurso)
        {
            if (docCurso.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(docCurso.Id);
            }
            else if (docCurso.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(docCurso);
            }
            else if (docCurso.Estado == Entidad.Estados.Modificado)
            {
                this.Update(docCurso);
            }
            docCurso.Estado = Entidad.Estados.NoModificado;
        }

        #endregion
    }
    
}
