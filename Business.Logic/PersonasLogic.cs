using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class PersonasLogic : BusinessLogic
    {
        public static Personas GetOne(int ID)
        {
            try
            {
                return new PersonasAdapter().GetOne(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Personas> GetAll()
        {
            try
            {
                return new PersonasAdapter().GetAll();
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(Personas persona)
        {
            try
            {
                new PersonasAdapter().Save(persona);
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
                new PersonasAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
