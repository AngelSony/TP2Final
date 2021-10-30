using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        public static Materia GetOne(int ID)
        {
            try
            {
                return new MateriaAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Materia> GetAll()
        {
            try
            {
                return new MateriaAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void Save(Materia mat)
        {
            try
            {
                new MateriaAdapter().Save(mat);
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
                new MateriaAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
