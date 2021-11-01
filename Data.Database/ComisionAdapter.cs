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
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision
                    {
                        ID = (int)drComisiones["id_comision"],
                        Descripcion = (string)drComisiones["desc_comision"],
                        AnioEspecialidad = (int)drComisiones["anio_especialidad"],
                        IDPlan = (int)drComisiones["id_plan"]
                    };

                    comisiones.Add(com);
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar las comisiones", Ex);
            }
            finally
            {
                CloseConnection();
            }
            return comisiones;
        }
        public Comision GetOne(int ID)
        {
            try
            {
                var comision = from m in GetAll() where m.ID == ID select m;
                return comision.Single();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error el recuperar datos de la Comisión", Ex);
            }
        }
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("DELETE comisiones where id_comision = @id", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdComision.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la Comisión", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Insert(Comision com)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdComision = new SqlCommand("INSERT into comisiones(desc_comision,anio_especialidad,id_plan) values(@desc_comision,@anio_especialidad,@id_plan) select @@identity", sqlConn);
                cmdComision.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdComision.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdComision.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;

                com.ID = Decimal.ToInt32((decimal)cmdComision.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear la Comisión", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Update(Comision com)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdComision = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision, anio_especialidad = @anio_especialidad, id_plan = @id_plan WHERE id_comision = @id ", sqlConn);
                cmdComision.Parameters.Add("@id", SqlDbType.Int).Value = com.ID;
                cmdComision.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = com.Descripcion;
                cmdComision.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = com.AnioEspecialidad;
                cmdComision.Parameters.Add("@id_plan", SqlDbType.Int).Value = com.IDPlan;
                cmdComision.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar la Comisión", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Comision com)
        {
            switch (com.State)
            {
                case BusinessEntity.States.Deleted:
                    Delete(com.ID);
                    break;
                case BusinessEntity.States.Modified:
                    Update(com);
                    break;
                case BusinessEntity.States.New:
                    Insert(com);
                    break;
                default:
                    break;
            }

            com.State = BusinessEntity.States.Unmodified;
        }
    }
}
