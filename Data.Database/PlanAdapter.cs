using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;


namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("SELECT * FROM planes", sqlConn);

                SqlDataReader drPlan = cmdPlan.ExecuteReader();



                while (drPlan.Read())
                {
                    Plan miPlan = new Plan();
                    miPlan.ID = (int)drPlan["id_plan"];
                    miPlan.Descripcion = (string)drPlan["desc_plan"];
                    miPlan.IDEspecialidad = (int)drPlan["id_especialidad"];
                    planes.Add(miPlan);
                    
                }
                drPlan.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionPlan = new Exception("-Error al recuperar lista de Planes", Ex);
                throw ExcepcionPlan;
            }
            finally
            {
                CloseConnection();

            }
            return planes;

        }
        public Plan GetOne(int id)
        {
            try
            {
                var miPlan = from u in GetAll() where u.ID == id select u;
                return miPlan.Single();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error el recuperar datos del Plan", Ex);
            }
        }


        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("DELETE planes where id_plan = @id", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("-Error al eliminar el Plan", Ex);
            }
            finally
            {
                CloseConnection();
            }

        }


        protected void Insert(Plan plan)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdPlan = new SqlCommand("INSERT into planes(desc_plan,id_especialidad) values(@desc_plan,@id_especialidad) select @@identity", sqlConn);
                cmdPlan.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdPlan.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                
                plan.ID = Decimal.ToInt32((decimal)cmdPlan.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear Plan", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("UPDATE planes SET desc_plan = @desc_plan, id_especialidad = @id_especialidad WHERE id_plan = @id ", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdPlan.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdPlan.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdPlan.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar Plan ", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                Delete(plan.ID);
            }
            if (plan.State == BusinessEntity.States.Modified)
            {
                Update(plan);
            }
            if (plan.State == BusinessEntity.States.New)
            {
                Insert(plan);
            }

            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
