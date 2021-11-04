﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Login : Form
    {

   
        public Usuario usuarioActual;

        public Login(ref Usuario usu)
        {
            InitializeComponent();
            usuarioActual = usu;
            
        }


      

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            usuarioActual = new Usuario();
            usuarioActual.NombreUsuario = txtUsuario.Text;
            usuarioActual.Clave = txtClave.Text;

            if(Validaciones.EsUsuarioValido(usuarioActual))
            { 
                MessageBox.Show("Usuario Valido");
                DialogResult = DialogResult.OK;
               }
            else
            {

                MessageBox.Show("Usuario Invalido");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
