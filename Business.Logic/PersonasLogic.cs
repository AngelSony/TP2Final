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
        private PersonasAdapter PersonaData;

        public PersonasLogic(){

            PersonaData = new PersonasAdapter();
        }
    

        public Personas GetOne(int ID)
        {
            try
            {
                return PersonaData.GetOne(ID);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public List<Personas> GetAll()
        {

            try
            {
                return PersonaData.GetAll();

            }
            catch(Exception Ex)
            {
                throw Ex;
            }
         
        }


        public void Save(Personas persona) // Validar Plan
        {
            

            PersonaData.Save(persona);

        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }





    }
}
