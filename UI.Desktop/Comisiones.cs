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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComisiones.AutoGenerateColumns = false;
            Listar();
        }
        public void Listar()
        {
            try
            {
                var comisiones = from c in ComisionesLogic.GetAll()
                                 join p in PlanLogic.GetAll() on c.IDPlan equals p.ID
                                 select new { c.ID, c.Descripcion, c.AnioEspecialidad, Plan = p.Descripcion };
                dgvComisiones.DataSource = comisiones.ToList();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ComisionesDesktop formComisiones = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            formComisiones.ShowDialog();
            Listar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvComisiones.SelectedRows[0].Cells["ID"].Value);
            ComisionesDesktop formComisiones = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formComisiones.ShowDialog();
            Listar();
        }
        private void btneEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvComisiones.SelectedRows[0].Cells["ID"].Value);
            ComisionesDesktop formComisiones = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);
            formComisiones.ShowDialog();
            Listar();
        }
    }
}
