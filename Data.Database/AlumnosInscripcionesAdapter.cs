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
    public   class AlumnosInscripcionesAdapter : Adapter
    {


        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnoInscripciones = new List<AlumnoInscripcion>();
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("select * from alumnos_inscripciones", sqlConn);
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();
                while (drAlumnoInscripcion.Read())
                {
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
                    alumnoInscripcion.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    alumnoInscripcion.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    if (drAlumnoInscripcion["nota"] != DBNull.Value)
                    {
                        alumnoInscripcion.Nota = (int)drAlumnoInscripcion["nota"];
                    }
                    alumnoInscripcion.Condicion = (string)drAlumnoInscripcion["condicion"];
                    alumnoInscripciones.Add(alumnoInscripcion);
                }
                drAlumnoInscripcion.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            return alumnoInscripciones;
        }


        public AlumnoInscripcion GetOne(int id)
        {
            try
            {
                var AluIns = from al in GetAll() where al.ID == id select al;

                return AluIns.Single();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error el recuperar datos del Plan", Ex);
            }

        }

        public void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("UPDATE alumnos_inscripciones SET condicion=@condicion, " +
                    "nota=@nota WHERE id_inscripcion = @idInscripcion", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@idInscripcion", SqlDbType.Int).Value = inscripcion.ID;
                if (inscripcion.Nota >= 0)
                {
                    cmdAlumnoInscripcion.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                }
                else
                {
                    cmdAlumnoInscripcion.Parameters.Add("@nota", SqlDbType.Int).Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                cmdAlumnoInscripcion.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdAlumnoInscripcion.ExecuteNonQuery();
            }
            finally
            {
                OpenConnection();
            }

        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInscripciones = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @id", sqlConn);
                cmdInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdInscripciones.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

        }

        public void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdInsertarInscripcion = new SqlCommand("INSERT INTO alumnos_inscripciones" +
                    "(id_alumno, id_curso, condicion) VALUES(@idAlumno, @idCurso, @condicion)", sqlConn);
                cmdInsertarInscripcion.Parameters.Add("@idAlumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdInsertarInscripcion.Parameters.Add("@idCurso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdInsertarInscripcion.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdInsertarInscripcion.ExecuteNonQuery();
                SqlCommand cmdActualizarCupo = new SqlCommand("UPDATE cursos SET cupo = cupo - 1" +
                    " WHERE id_curso=@idCurso", sqlConn);
                cmdActualizarCupo.Parameters.Add("@idCurso", SqlDbType.VarChar, 50).Value = inscripcion.IDCurso;
                cmdActualizarCupo.ExecuteNonQuery();
            }
           catch (Exception Ex)
            {
               Exception ExcepcionManejada = new Exception("Error al generar la inscripcion", Ex);
               throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }




        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
            {
                Delete(alumnoInscripcion.ID);
            }
            if (alumnoInscripcion.State == BusinessEntity.States.Modified)
            {
                Update(alumnoInscripcion);
            }
            if (alumnoInscripcion.State == BusinessEntity.States.New)
            {
                Insert(alumnoInscripcion);
            }

            alumnoInscripcion.State = BusinessEntity.States.Unmodified;
        }







    }
}
