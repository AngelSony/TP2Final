using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        public CursoLogic()
        {
        }
        public static Curso GetOne(int ID)
        {
            try
            {
                return new CursoAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Curso> GetAll()
        {
            try
            {
                return new CursoAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(Curso cur)
        {
            try
            {
                new CursoAdapter().Save(cur);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Delete(int ID)
        {
            try
            {
                new CursoAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public static Object GetAllCursosComiMat()
        {
            try
            {
                var listado = from cur in GetAll()
                              join mat in MateriaLogic.GetAll() on cur.IDMateria equals mat.ID
                              join comi in ComisionesLogic.GetAll() on cur.IDComision equals comi.ID
                              orderby cur.AnioCalendario descending
                              select new { cur.ID, cur.AnioCalendario, IDComision = comi.Descripcion, IDMateria = mat.Descripcion, Cupo = cur.Cupo };

                return listado.ToList();
            }
            catch(Exception Ex)
            {
                throw new Exception("Error al recuperar los cursos para el reporte", Ex);
            }

        }


    }
}

