using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public static Usuario GetOne(int ID)
        {
            try
            {
                return new UsuarioAdapter().GetOne(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static List<Usuario> GetAll()
        {
            try
            {
                return new UsuarioAdapter().GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static void Save(Usuario usuario)
        {
            try
            {
                new UsuarioAdapter().Save(usuario);
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
                new UsuarioAdapter().Delete(ID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public static Usuario GetUsuarioPorNombre(Usuario usuario)
        {
            try
            {
                return new UsuarioAdapter().GetUsuarioPorNombre(usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
