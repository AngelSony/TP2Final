using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Business.Entities;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentesCursos = new List<DocenteCurso>();
            try
            {
                OpenConnection();

                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT dc.id_dictado, dc.id_curso, dc.id_docente, dc.cargo, CONCAT(p. nombre,' ',p.apellido) AS nombre_apellido_docente, CONCAT(m.desc_materia,' - ',com.desc_comision,' - ',c.anio_calendario) AS descripcion_curso FROM docentes_cursos AS dc " +
                                                            "LEFT JOIN personas AS p " +
                                                            "ON p.id_persona = dc.id_docente " +
                                                            "LEFT JOIN cursos AS c " +
                                                            "ON c.id_curso = dc.id_curso " +
                                                            "LEFT JOIN materias m " +
                                                            "ON c.id_materia = m.id_materia " +
                                                            "LEFT JOIN comisiones com " +
                                                            "ON com.id_comision = c.id_comision", sqlConn);
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                while (drDocenteCurso.Read())
                {
                    DocenteCurso docenteCurso = new DocenteCurso();
                    docenteCurso.ID = (int)drDocenteCurso["id_dictado"];
                    docenteCurso.IDCurso = (int)drDocenteCurso["id_curso"];
                    docenteCurso.NombreApellidoDocente = (string)drDocenteCurso["nombre_apellido_docente"];
                    docenteCurso.Curso = (string)drDocenteCurso["descripcion_curso"];
                    docenteCurso.IDDocente = (int)drDocenteCurso["id_docente"];
                    docenteCurso.Cargo = (DocenteCurso.TiposCargos)drDocenteCurso["cargo"];
                    docentesCursos.Add(docenteCurso);
                }
                drDocenteCurso.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar la lista de asignaciones docentes", e);
            }
            finally
            {
                CloseConnection();
            }
            return docentesCursos;
        }


        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docenteCurso = new DocenteCurso();
            try
            {
                OpenConnection();

                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT dc.id_dictado, dc.id_curso, dc.id_docente, dc.cargo, CONCAT(p. nombre,' ',p.apellido) AS nombre_apellido_docente, CONCAT(m.desc_materia,' - ',com.desc_comision,' - ',c.anio_calendario) AS descripcion_curso FROM docentes_cursos AS dc " +
                                                            "LEFT JOIN personas AS p " +
                                                            "ON p.id_persona = dc.id_docente " +
                                                            "LEFT JOIN cursos AS c " +
                                                            "ON c.id_curso = dc.id_curso " +
                                                            "LEFT JOIN materias m " +
                                                            "ON c.id_materia = m.id_materia " +
                                                            "LEFT JOIN comisiones com " +
                                                            "ON com.id_comision = c.id_comision " +
                                                            "WHERE dc.id_dictado = @id", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();
                if (drDocenteCurso.Read())
                {
                    docenteCurso.ID = (int)drDocenteCurso["id_dictado"];
                    docenteCurso.IDCurso = (int)drDocenteCurso["id_curso"];
                    docenteCurso.IDDocente = (int)drDocenteCurso["id_docente"];
                    docenteCurso.NombreApellidoDocente = (string)drDocenteCurso["nombre_apellido_docente"];
                    docenteCurso.Curso = (string)drDocenteCurso["descripcion_curso"];
                    docenteCurso.Cargo = (DocenteCurso.TiposCargos)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al recuperar la asignacion", e);
            }
            finally
            {
                CloseConnection();
            }
            return docenteCurso;
        }

        public void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("INSERT INTO docentes_cursos(id_curso,id_docente,cargo) VALUES(@id_curso,@id_docente,@cargo) SELECT @@identity", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
                cmdDocenteCurso.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IDDocente;
                cmdDocenteCurso.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
                docenteCurso.ID = Decimal.ToInt32((decimal)cmdDocenteCurso.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception("Error al crear la asignacion", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(DocenteCurso docenteCurso)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdDocenteCurso = new SqlCommand("UPDATE docentes_cursos SET id_curso = @id_curso, id_docente = @id_docente, cargo = @cargo WHERE id_dictado = @id", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IDCurso;
                cmdDocenteCurso.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IDDocente;
                cmdDocenteCurso.Parameters.Add("@cargo", SqlDbType.Int).Value = (int)docenteCurso.Cargo;
                cmdDocenteCurso.Parameters.Add("@id", SqlDbType.Int).Value = docenteCurso.ID;

                cmdDocenteCurso.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al guardar la asignacion", e);
            }
            finally
            {
                CloseConnection();
            }
        }


        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdCursoDocente = new SqlCommand("DELETE FROM docentes_cursos WHERE id_dictado = @id", sqlConn);
                cmdCursoDocente.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdCursoDocente.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al eliminar la asignacion", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(DocenteCurso docenteCurso)
        {
            switch (docenteCurso.State)
            {
                case BusinessEntity.States.New:
                    this.Insert(docenteCurso);
                    break;
                case BusinessEntity.States.Modified:
                    this.Update(docenteCurso);
                    break;
                case BusinessEntity.States.Deleted:
                    this.Delete(docenteCurso.ID);
                    break;
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }



    }
}
