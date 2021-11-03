using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
   public class PlanLogic
    {
        public static Plan GetOne(int ID)
        {
            try
            {
                return new PlanAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Plan> GetAll()
        {
            try
            {
                return new PlanAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(Plan plan)
        {
            try
            {
                new PlanAdapter().Save(plan);

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
                new PlanAdapter().Delete(ID);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
