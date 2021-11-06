using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Data.Database;
using Business.Entities;
using System.Windows.Forms;

namespace Business.Logic
{
    public class Validaciones
    {
        public static Boolean EsMailValido(string email)
        {
            string expresion = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@(([a-zA-Z]+[\w-]+\.){1,2}[a-zA-Z]{2,4})$";
            return Regex.IsMatch(email, expresion);
        }

        public static Boolean EsFechaValida(string fecha)
        {
            string expresion = @"^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})";
            return Regex.IsMatch(fecha, expresion);
        }
        public static Boolean EsClaveValida(string clave)
        {
            string expresion = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
            return Regex.IsMatch(clave, expresion);
        }

        public static Boolean EsUsuarioValido(Usuario usuario)
        {
            try
            {
                Usuario miUsuario = UsuarioLogic.GetUsuarioPorNombre(usuario);
                if (miUsuario.Equals(null))
                {
                    return false;
                }
                else if (miUsuario.Clave.Equals(usuario.Clave))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(ArgumentNullException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static void ValidarDocentes(DocenteCurso docenteCurso)
        {
            List<DocenteCurso> docentesCursos = DocenteCursoLogic.GetAll();
            List<DocenteCurso> docenteCursosRepetidos = docentesCursos.Where(dc => dc.IDCurso == docenteCurso.IDCurso && dc.IDDocente == docenteCurso.IDDocente).ToList();
            if (docenteCursosRepetidos.Count != 0)
                throw new Exception("El docente ya se encuetra asignado al curso seleccionado");
        }
        public static Boolean EsNumeroPositivo(string text)
        {
            if (!Int32.TryParse(text,out int n))
            {
                return false;
            }else if (Int32.Parse(text) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean ValidarCupo(Curso curso)
        {
            if(curso.Cupo.Equals(0))
            {
                 MessageBox.Show("NO HAY CUPOS PARA EL CURSO");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Boolean ValidarAlumno(Personas alumno, Curso cur)
        {
            foreach (var al in AlumnoInscripcionesLogic.GetAll())
            {
                if (al.IDAlumno == alumno.ID && al.IDCurso == cur.ID)
                {
                    return false;
                }

            }
            return true;

        }



    }
}





    

