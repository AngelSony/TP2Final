using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonasAdapter : Adapter
    {
        public List<Personas> GetAll()
        {
            List<Personas> personas = new List<Personas>();

            try
            {
                OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Personas per = new Personas();
                    per.ID = (int)drPersonas["id_persona"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.TipoPersona = (Personas.TiposPersonas)(int)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);

                }
                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionPersonas = new Exception("Error al recuperar lista de Personas", Ex);
                throw ExcepcionPersonas;
            }
            finally
            {
                CloseConnection();

            }
            return personas;

        }
        public Personas GetOne(int ID)
        {
            Personas per = new Personas();
            try
            {
                OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas where id_persona = @id ", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if(drPersonas.Read())
                    {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.TipoPersona = (Personas.TiposPersonas)(int)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];


                }
                drPersonas.Close();

            }

            catch(Exception Ex)
            {
                Exception ExcepcionPersonas = new Exception("No se encontro la Persona", Ex);
                throw ExcepcionPersonas;

            }
            finally
            {
                CloseConnection();
            }
            return per;
        }
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("DELETE personas where id_persona = @id",sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdPersonas.ExecuteNonQuery();
            }
            catch(Exception Ex)
            {
                Exception ExcepcionPersona = new Exception("Error al encontrar la Persona",Ex);
                throw ExcepcionPersona;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Insert(Personas persona)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdPersona = new SqlCommand("INSERT into personas(nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan) values(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan) select @@identity", sqlConn);
                cmdPersona.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdPersona.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdPersona.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdPersona.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdPersona.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdPersona.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdPersona.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdPersona.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdPersona.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdPersona.ExecuteScalar());
            }
            catch(Exception Ex)
            {
                Exception ExcepcionPersona = new Exception("Error al crear la Persona", Ex);
                throw ExcepcionPersona;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Update(Personas persona)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdPersona = new SqlCommand("UPDATE personas SET nombre = @nombre, apellido = @apellido, direccion = @direccion, email = @email, telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, tipo_persona = @tipo_persona, id_plan = @id_plan WHERE id_persona = @id ",sqlConn);
                cmdPersona.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdPersona.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdPersona.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdPersona.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdPersona.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdPersona.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdPersona.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 50).Value = persona.FechaNacimiento;
                cmdPersona.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdPersona.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdPersona.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdPersona.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionPersona = new Exception("Error al modificar la Persona",Ex);
                throw ExcepcionPersona;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Personas persona)
        {
            if(persona.State == BusinessEntity.States.Deleted)
            {
                Delete(persona.ID);
            }
            if(persona.State == BusinessEntity.States.Modified)
            {
                Update(persona);
            }
            if(persona.State == BusinessEntity.States.New)
            {
                Insert(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }
    }
}
