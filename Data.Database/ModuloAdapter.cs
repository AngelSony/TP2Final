using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloAdapter : Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();

            try
            {
                OpenConnection();
                SqlCommand cmdModulo = new SqlCommand("select * from modulos", sqlConn);
                SqlDataReader drmodulo = cmdModulo.ExecuteReader();

                while (drmodulo.Read())
                {
                    Modulo cur = new Modulo
                    {
                        ID = (int)drmodulo["id_modulo"],
                        Descripcion = (string)drmodulo["desc_modulo"],
                    };

                    modulos.Add(cur);
                }
                drmodulo.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionModulos = new Exception("Error al recuperar la lsita de modulos", Ex);
                throw ExcepcionModulos;
            }
            finally
            {
                CloseConnection();
            }

            return modulos;
        }
    }
}
