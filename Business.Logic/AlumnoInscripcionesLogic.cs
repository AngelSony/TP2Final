using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
   public class AlumnoInscripcionesLogic
    {

        public static AlumnoInscripcion GetOne(int ID)
        {
            try
            {
                return new AlumnosInscripcionesAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<AlumnoInscripcion> GetAll()
        {
            try
            {
                return new AlumnosInscripcionesAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(AlumnoInscripcion AluIns)
        {
            try
            {
                if(AluIns.State == BusinessEntity.States.New)
                {
                    if(CursoLogic.GetOne(AluIns.IDCurso).Cupo == 0)
                    {
                        throw new Exception("No existen cupos disponibles para este curso");
                    }
                }
                new AlumnosInscripcionesAdapter().Save(AluIns);
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
                Curso cur = CursoLogic.GetOne(GetOne(ID).IDCurso);
                cur.Cupo++;
                cur.State = BusinessEntity.States.Modified;
                CursoLogic.Save(cur);
                new AlumnosInscripcionesAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
