using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EspecialidadesAdapter: Adapter
    {
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades", sqlConn);
                SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad es = new Especialidad
                    {
                        ID = (int)drEspecialidades["id_especialidad"],
                        Descripcion = (string)drEspecialidades["desc_especialidad"]
                    };

                    especialidades.Add(es);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar lista de Especialidades", Ex);
            }
            finally
            {
                CloseConnection();
            }
            return especialidades;
        }
        public Especialidad GetOne(int ID)
        {
            try
            {
                var materia = from m in GetAll() where m.ID == ID select m;
                return materia.Single();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error el recuperar datos de la Especialidad", Ex);
            }
        }
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidad = new SqlCommand("DELETE especialidades where id_especialidad = @id", sqlConn);
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdEspecialidad.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la Especialidad", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Insert(Especialidad es)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdEspecialidad = new SqlCommand("INSERT into especialidades(desc_especialidad) values(@desc_especialidad) select @@identity", sqlConn);
                cmdEspecialidad.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = es.Descripcion;

                es.ID = Decimal.ToInt32((decimal)cmdEspecialidad.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear la Especialidad", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Update(Especialidad es)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdEspecialidad = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc_especialidad WHERE id_especialidad=@id", sqlConn);
                cmdEspecialidad.Parameters.Add("@id", SqlDbType.Int).Value = es.ID;
                cmdEspecialidad.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = es.Descripcion;
                cmdEspecialidad.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar la Especialidad", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Especialidad es)
        {
            switch (es.State)
            {
                case BusinessEntity.States.Deleted:
                    Delete(es.ID);
                    break;
                case BusinessEntity.States.Modified:
                    Update(es);
                    break;
                case BusinessEntity.States.New:
                    Insert(es);
                    break;
                default:
                    break;
            }

            es.State = BusinessEntity.States.Unmodified;
        }
    }
}
