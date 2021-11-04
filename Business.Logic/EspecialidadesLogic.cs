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
        public static Especialidad GetOne(int ID)
        {
            try
            {
                return new EspecialidadesAdapter().GetOne(ID);
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
                return new EspecialidadesAdapter().GetAll();
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
                new EspecialidadesAdapter().Save(es);
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
                new EspecialidadesAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
