using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        public static DocenteCurso GetOne(int ID)
        {
            try
            {
                return new DocenteCursoAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public static List<DocenteCurso> GetAll()
        {
            try
            {
                return new DocenteCursoAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(DocenteCurso curso)
        {
            try
            {
                new DocenteCursoAdapter().Save(curso);
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
                new DocenteCursoAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
