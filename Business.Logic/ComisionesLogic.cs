using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionesLogic : BusinessLogic
    {
        public static Comision GetOne(int ID)
        {
            try
            {
                return new ComisionAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Comision> GetAll()
        {
            try
            {
                return new ComisionAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void Save(Comision com)
        {
            try
            {
                new ComisionAdapter().Save(com);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void Delete(int ID)
        {
            try
            {
                new ComisionAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
