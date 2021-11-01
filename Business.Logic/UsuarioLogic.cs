using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private readonly UsuarioAdapter UsuarioData;

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }
        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
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
