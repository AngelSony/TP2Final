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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
            Listar();
        }
        public void Listar()
        {
            try
            {
                var planes = from p in PlanLogic.GetAll()
                             join e in EspecialidadesLogic.GetAll() on p.IDEspecialidad equals e.ID
                             select new { p.ID, p.Descripcion, Especialidad = e.Descripcion };
                dgvPlanes.DataSource = planes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanesDesktop formPlanes = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            formPlanes.ShowDialog();
            Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvPlanes.SelectedRows[0].Cells["ID"].Value);
            PlanesDesktop formPlanes = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPlanes.ShowDialog();
            Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvPlanes.SelectedRows[0].Cells["ID"].Value);
            PlanesDesktop formPlanes= new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);
            formPlanes.ShowDialog();
            Listar();
        }
    }
}
