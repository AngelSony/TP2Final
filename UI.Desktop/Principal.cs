using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tsmiUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios formUsuario = new Usuarios();
            formUsuario.ShowDialog();
        }

        private void tsmiCursos_Click(object sender, EventArgs e)
        {
            Cursos formCurso = new Cursos();
            formCurso.ShowDialog();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modulos formModulo = new Modulos();
            formModulo.ShowDialog();
        }

     
        private void tsmiPlanes_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog();
        }

        private void tsmiAlumnos_Click(object sender, EventArgs e)
        {
            Alumnos formAlumno = new Alumnos();
            formAlumno.ShowDialog();
        }

        private void Principal_Shown(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            if (formLogin.ShowDialog() != DialogResult.OK)
            {
                Dispose();
            }
        }

    }
}
