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
    public partial class Principal : Form
    {
        Usuario usuarioActual;
        Personas personaActual;
        public Principal()
        {
            InitializeComponent();
        }
        private void tsmiSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void tsmiPlanes_Click(object sender, EventArgs e)
        {
            new Planes().ShowDialog();
        }
        private void tsmiAlumnos_Click(object sender, EventArgs e)
        {
            new formPersonas(Personas.TiposPersonas.Alumno).ShowDialog();
        }
        private void Principal_Shown(object sender, EventArgs e)
        {
            Log();
        }
        private void Log()
        {
            Login formLogin = new Login(ref usuarioActual);

            if (formLogin.ShowDialog() != DialogResult.OK)
            {
                Dispose();
            }
            else
            {
                try {
                    usuarioActual = formLogin.usuarioActual;
                    usuarioActual = UsuarioLogic.GetUsuarioPorNombre(usuarioActual);
                    personaActual = PersonasLogic.GetOne(usuarioActual.IDPersona);
                    MessageBox.Show("Bienvenido " + personaActual.Nombre + " " + personaActual.Apellido, "UTN FRRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    VisibleButtons();
                    switch (personaActual.TipoPersona)
                    {
                        case Personas.TiposPersonas.Administrativo:
                            MessageBox.Show("Inicio de sesion como Administrador", "Info de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tsmiInscripcion.Visible = false;
                            break;
                        case Personas.TiposPersonas.Alumno:
                            MessageBox.Show("Inicio de sesion como Alumno", "Info de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tsmiAsignarDocentes.Visible = false;
                            tsmiAdminCursos.Visible = false;
                            tsmiRegistroNotas.Visible = false;
                            tsmiReporteCurso.Visible = false;
                            tsmiReportePlan.Visible = false;
                            tsmiAdministracion.Visible = false;
                            break;

                        case Personas.TiposPersonas.Docente:
                            MessageBox.Show("Inicio de sesion como Docente", "Info de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tsmiInscripcion.Visible = false;
                            tsmiAsignarDocentes.Visible = false;
                            tsmiAdminCursos.Visible = false;
                            tsmiAdministracion.Visible = false;
                            break;
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }
        private void VisibleButtons()
        {
            tsmiInscripcion.Visible = true;
            tsmiAdministracion.Visible = true;
            tsmiAsignarDocentes.Visible = true;
            tsmiAdminCursos.Visible = true;
            tsmiRegistroNotas.Visible = true;
            tsmiReporteCurso.Visible = true;
            tsmiReportePlan.Visible = true;
        }
        private void tsmiDocentes_Click(object sender, EventArgs e)
        {
            new formPersonas(Personas.TiposPersonas.Docente).ShowDialog();
        }
        private void tsmiEspecialidades_Click(object sender, EventArgs e)
        {
            new Especialidades().ShowDialog();
        }
        private void tsmiAdminCursos_Click(object sender, EventArgs e)
        {
            new Cursos().ShowDialog();
        }
        private void tsmiAsignarDocentes_Click(object sender, EventArgs e)
        {
            new DocenteCurso().ShowDialog();
        }
        private void tsmiCerrarSesion_Click(object sender, EventArgs e)
        {
            Log();
        }
        private void tsmiReporteCurso_Click(object sender, EventArgs e)
        {
            new ReportesCursosForm().ShowDialog();
        }
        private void tsmiReportePlan_Click(object sender, EventArgs e)
        {
            new ReporteDePlanes().ShowDialog();
        }
        private void tsmiInscripcion_Click(object sender, EventArgs e)
        {
            new AlumnoInscripciones(personaActual).ShowDialog();
        }
        private void tsmiRegistroNotas_Click(object sender, EventArgs e)
        {
            new RegistroNotas(personaActual).ShowDialog();
        }
        private void tsmiComisiones_Click(object sender, EventArgs e)
        {
            new Comisiones().ShowDialog();
        }
    }
}
