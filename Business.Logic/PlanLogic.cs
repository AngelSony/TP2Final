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


        private PlanAdapter PlanData;

        public PlanLogic()
        {

            PlanData = new PlanAdapter();

        }

        public Plan GetOne(int ID)
        {
            try
            {
                return PlanData.GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public List<Plan> GetAll()
        {

            try
            {
                return PlanData.GetAll();

            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void Save(Plan plan)
        {


            PlanData.Save(plan);

        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }




    }
}
