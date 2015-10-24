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
    class EspecialidadAdapter: Adapter
    {
        public void Save(Especialidad esp)
        {
            if (esp.Estado == Entidad.Estados.Eliminado)
            {
               // this.Delete(esp.Id);
            }
            else if (esp.Estado == Entidad.Estados.Nuevo)
            {
                this.Insert(esp);
            }
            else if (esp.Estado == Entidad.Estados.Modificado)
            {
               // this.Update(esp);
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
                    "insert into especialidad(desc_especialidad) values( @desc_especialidad)" +
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


    }
}
