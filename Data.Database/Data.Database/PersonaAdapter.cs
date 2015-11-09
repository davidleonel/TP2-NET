using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {


        #region Metodos
        public List<Persona> GetAll()
        {
            List<Persona> Personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {

                    Persona per = new Persona();

                    per.Id = (int)drPersonas["id_Persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    //per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Persona.TiposPersona)drPersonas["tipo_persona"];
                    per.IdPlan = (int)drPersonas["id_plan"];

                    Personas.Add(per);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return Personas;
        }

        public List<Persona> GetAllAlumnos()
        {
            List<Persona> Personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona = 1", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {

                    Persona per = new Persona();

                    per.Id = (int)drPersonas["id_Persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    //per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Persona.TiposPersona)drPersonas["tipo_persona"];
                    per.IdPlan = (int)drPersonas["id_plan"];

                    Personas.Add(per);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return Personas;
        }

        public List<Persona> GetAllDocentes()
        {
            List<Persona> Personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona = 2", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {

                    Persona per = new Persona();

                    per.Id = (int)drPersonas["id_Persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    //per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Persona.TiposPersona)drPersonas["tipo_persona"];
                    per.IdPlan = (int)drPersonas["id_plan"];

                    Personas.Add(per);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de Personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return Personas;
        }

        public Persona GetOne(int ID)
        {
            
                Persona per = new Persona();
                try
                {

                    this.OpenConnection();
                    SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", SqlConn);
                    cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                    if (drPersonas.Read())
                    {

                        per.Id = (int)drPersonas["id_Persona"];
                        per.Nombre = (string)drPersonas["nombre"];
                        per.Apellido = (string)drPersonas["apellido"];
                        per.Direccion = (string)drPersonas["direccion"];
                        per.Email = (string)drPersonas["email"];
                        per.Telefono = (string)drPersonas["telefono"];
                        //per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                        per.Legajo = (int)drPersonas["legajo"];
                        per.TipoPersona = (Persona.TiposPersona)drPersonas["tipo_persona"];
                        per.IdPlan = (int)drPersonas["id_plan"];

                        
                    }

                    drPersonas.Close();

                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de Personas", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                    
                }

                return per;
            }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("delete from personas where id_persona=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al eliminar la Persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona Persona, int tipo_persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                     "UPDATE personas set nombre=@nombre, apellido=@apellido, direccion= @direccion, email=@email, telefono= @telefono," +
                    "legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan WHERE id_persona=@id", SqlConn);

                //fecha_nac=@fecha_nac, 

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = Persona.Id;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = Persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = Persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = Persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = Persona.Telefono;
                //cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = Persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = Persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = tipo_persona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = Persona.IdPlan;

                cmdSave.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la Persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Persona Persona, int tipo_persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into personas (nombre,apellido,direccion,email,telefono,legajo,tipo_persona,id_plan)" +
                    "values(@nombre,@apellido,@direccion,@email,@telefono,@legajo,@tipo_persona,@id_plan)" +
                    " select @@identity AS id_persona", SqlConn);

                //,fecha_nac,@fecha_nac
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = Persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = Persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = Persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = Persona.Telefono;
                //cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = Persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = Persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = tipo_persona;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = Persona.IdPlan;
                
                Persona.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos de la Persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }
        
        /*protected void InsertAlumno(Persona Persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan)" +
                    "values(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                    " select @@identity AS id_persona", SqlConn);


                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = Persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = Persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = Persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = Persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = "2010-10-10";
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = Persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 1;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = 1;

                Persona.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());



            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos de la Persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }

        protected void InsertDocente(Persona Persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave;
                cmdSave = new SqlCommand(
                    "insert into personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan)" +
                    "values(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                    " select @@identity AS id_persona", SqlConn);


                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = Persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = Persona.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = Persona.Direccion;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = Persona.Email;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = Persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = "2010-10-10";
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = Persona.Legajo;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 2;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = 1;

                Persona.Id = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());



            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Error al crear datos de la Persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }*/
        
        public void Save(Persona Persona)
        {
            int tipo;
            switch (Persona.TipoPersona)
            {
                case Persona.TiposPersona.Administrador:
                    tipo = 0;
                    break;
                case Persona.TiposPersona.Alumno:
                    tipo = 1;
                    break;
                case Persona.TiposPersona.Docente:
                    tipo = 2;
                    break;
                default:
                    tipo = 0;
                    break;
            }
            if (Persona.Estado == Entidad.Estados.Eliminado)
            {
                this.Delete(Persona.Id);
            }
            else if (Persona.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(Persona, tipo);
                
            }
            else if (Persona.Estado == Entidad.Estados.Modificado)
            {
                this.Update(Persona, tipo);
            }
            Persona.Estado = Entidad.Estados.NoModificado;
        }

        #endregion
    }
}
