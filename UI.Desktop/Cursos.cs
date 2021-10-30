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
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
        }
        public void listar()
        {
            CursoLogic cl = new CursoLogic();
            try
            {
                dgvCursos.DataSource = CursoLogic.GetAll();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formCursos_Load(object sender, EventArgs e)
        {
            listar();
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
            CursosDesktop formCurso = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            listar();
        }

        private void tspEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop formCurso = new CursosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formCurso.ShowDialog();
            listar();
        }

        private void tspEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop formCurso = new CursosDesktop(ID, ApplicationForm.ModoForm.Baja);
            formCurso.ShowDialog();
            listar();
        }
    }
}
