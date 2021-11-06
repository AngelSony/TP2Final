﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
   public class AlumnoInscripcionesLogic
    {

        public static AlumnoInscripcion GetOne(int ID)
        {
            try
            {
                return new AlumnosInscripcionesAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<AlumnoInscripcion> GetAll()
        {
            try
            {
                return new AlumnosInscripcionesAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(AlumnoInscripcion AluIns)
        {
            try
            {
                new AlumnosInscripcionesAdapter().Save(AluIns);

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
                new AlumnosInscripcionesAdapter().Delete(ID);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}