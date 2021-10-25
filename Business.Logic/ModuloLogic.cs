using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private readonly ModuloAdapter ModuloData;

        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        public List<Modulo> GetAll()
        {
            try
            {
                return ModuloData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
