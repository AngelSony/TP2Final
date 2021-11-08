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
            Listar();
        }
        public void Listar()
        {
            try
            {
                var cursos = from c in CursoLogic.GetAll()
                             join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                             join co in ComisionesLogic.GetAll() on c.IDComision equals co.ID
                             select new { c.ID, Materia = m.Descripcion, Comision = co.Descripcion, c.AnioCalendario, c.Cupo };
                dgvCursos.DataSource = cursos.ToList();
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
            Dispose();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop formCurso = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            Listar();
        }
        private void tspEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvCursos.SelectedRows[0].Cells["id_curso"].Value);
            CursosDesktop formCurso = new CursosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formCurso.ShowDialog();
            Listar();
        }
        private void tspEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvCursos.SelectedRows[0].Cells["id_curso"].Value);
            CursosDesktop formCurso = new CursosDesktop(ID, ApplicationForm.ModoForm.Baja);
            formCurso.ShowDialog();
            Listar();
        }
    }
}
