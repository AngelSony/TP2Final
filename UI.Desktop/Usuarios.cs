﻿using System;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }
        public void listar()
        {
            try
            {
                dgvUsuarios.DataSource = UsuarioLogic.GetAll();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Usuarios_Load(object sender, System.EventArgs e)
        {
            listar();
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            listar();
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            Dispose();
        }

        private void tsbNuevo_Click(object sender, System.EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            listar();
        }

        private void tsbEliminar_Click(object sender, System.EventArgs e)
        {
            int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUsuario = new UsuarioDesktop(ID,ApplicationForm.ModoForm.Baja);
            formUsuario.ShowDialog();
            listar();
        }

        private void tsbEditar_Click(object sender, System.EventArgs e)
        {
            int ID = ((Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            listar();
        }
    }
}
