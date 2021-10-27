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
        private readonly CursoAdapter CursoData;

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }
        public Curso GetOne(int ID)
        {
            try
            {
                return CursoData.GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void Save(Curso cur)
        {
            try
            {
                CursoData.Save(cur);
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
                CursoData.Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
