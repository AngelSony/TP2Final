﻿using System;
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
        public CursoLogic()
        {
        }
        public static Curso GetOne(int ID)
        {
            try
            {
                return new CursoAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Curso> GetAll()
        {
            try
            {
                return new CursoAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(Curso cur)
        {
            try
            {
                new CursoAdapter().Save(cur);
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
                new CursoAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
