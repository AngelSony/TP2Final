using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
            listar();
        }
        public void listar()
        {
            try
            {
                dgvEspecialidades.DataSource = EspecialidadesLogic.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop formEspecialidad = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadesDesktop formEspecialidad = new EspecialidadesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadesDesktop formEspecialidad = new EspecialidadesDesktop(ID, ApplicationForm.ModoForm.Baja);
            formEspecialidad.ShowDialog();
            listar();
        }
    }
}
