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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mat = new Materia
                    {
                        ID = (int)drMaterias["id_materia"],
                        Descripcion = (string)drMaterias["desc_materia"],
                        HSSemanales = (int)drMaterias["hs_semanales"],
                        HSTotales = (int)drMaterias["hs_totales"],
                        IDPlan = (int)drMaterias["id_plan"]
                    };

                    materias.Add(mat);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar lista de Materias", Ex);
            }
            finally
            {
                CloseConnection();
            }
            return materias;
        }
        public Materia GetOne(int ID)
        {
            try
            {
                var materia = from m in GetAll() where m.ID == ID select m;
                return materia.Single();
            }
            catch(Exception Ex)
            {
                throw new Exception("Error el recuperar datos de la Materia", Ex);
            }
        }
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("DELETE materias where id_materia = @id", sqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdMateria.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al eliminar la Materia", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Insert(Materia mat)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdMateria = new SqlCommand("INSERT into materias(desc_materia,hs_semanales,hs_totales,id_plan) values(@desc_materia,@hs_semanales,@hs_totales,@id_plan) select @@identity", sqlConn);
                cmdMateria.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdMateria.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdMateria.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdMateria.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;

                mat.ID = Decimal.ToInt32((decimal)cmdMateria.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear la Materia", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Update(Materia mat)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan WHERE id_materia = @id ", sqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdMateria.Parameters.Add("@desc_materia", SqlDbType.NVarChar, 50).Value = mat.Descripcion;
                cmdMateria.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;
                cmdMateria.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdMateria.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;
                cmdMateria.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al modificar la Materia", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Materia mat)
        {
            switch (mat.State)
            {
                case BusinessEntity.States.Deleted:
                    Delete(mat.ID);
                    break;
                case BusinessEntity.States.Modified:
                    Update(mat);
                    break;
                case BusinessEntity.States.New:
                    Insert(mat);
                    break;
                default:
                    break;
            }

            mat.State = BusinessEntity.States.Unmodified;
        }
    }
}
