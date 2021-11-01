using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso
                    {
                        ID = (int)drCursos["id_curso"],
                        IDMateria = (int)drCursos["id_materia"],
                        IDComision = (int)drCursos["id_comision"],
                        Cupo = (int)drCursos["cupo"],
                        AnioCalendario = (int)drCursos["anio_calendario"]
                    };

                    cursos.Add(cur);
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar lista de cursos", Ex);
            }
            finally
            {
                CloseConnection();
            }
            return cursos;
        }
        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso = @id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    cur.ID = (int)drCursos["id_curso"];
                    cur.IDMateria = (int)drCursos["id_materia"];
                    cur.IDComision = (int)drCursos["id_comision"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                }
                drCursos.Close();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al recuperar los datos del curso", Ex);
            }
            finally
            {
                CloseConnection();
            }
            return cur;
        }
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Insert(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into cursos(id_materia, id_comision, anio_calendario, cupo) values(@id_materia, @id_comision, @anio_calendario, @cupo) select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al crear usuario", Ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        protected void Update(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo WHERE id_curso=@id", sqlConn);
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.Deleted)
            {
                Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }
    }
}