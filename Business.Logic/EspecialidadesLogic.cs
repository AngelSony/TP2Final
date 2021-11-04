using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class EspecialidadesLogic : BusinessLogic
    {
        public static Materia GetOne(int ID)
        {
            try
            {
                return new EspecialidadAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Especialidad> GetAll()
        {
            try
            {
                return new EspecialidadAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(Especialidad es)
        {
            try
            {
                new EspecialidadAdapter().Save(es);
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
                new EspecialidadAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
    }
}
