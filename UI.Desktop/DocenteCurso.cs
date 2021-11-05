using System;
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
    public partial class DocenteCurso : Form
    {
        public DocenteCurso()
        {
            InitializeComponent();
            dgvDocenteCursos.AutoGenerateColumns = false;
        }

        public void listar()
        {
            try
            {
                dgvDocenteCursos.DataSource = DocenteCursoLogic.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DocenteCurso_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formDocenteCurso.ShowDialog();
            listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)dgvDocenteCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formDocenteCurso.ShowDialog();
            listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)dgvDocenteCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop formDocenteCurso = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
            formDocenteCurso.ShowDialog();
            listar();
        }
    }
}
