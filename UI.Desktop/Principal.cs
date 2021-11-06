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

        private void tsmiUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios formUsuario = new Usuarios();
            formUsuario.ShowDialog();
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
            formPersonas Personas = new formPersonas(Business.Entities.Personas.TiposPersonas.Alumno);
            Personas.ShowDialog();
        }

        private void Principal_Shown(object sender, EventArgs e)
        {
            Login formLogin = new Login(ref usuarioActual);
            
            if (formLogin.ShowDialog() != DialogResult.OK)
            {
                Dispose();
            
            }
            else
            {
                usuarioActual = formLogin.usuarioActual;
                usuarioActual = UsuarioLogic.GetUsuarioPorNombre(usuarioActual);
                personaActual = PersonasLogic.GetOne(usuarioActual.IDPersona);
                MessageBox.Show("Bienvenido " + personaActual.Nombre + " " + personaActual.Apellido, "UTN FRRO",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                switch(personaActual.TipoPersona)
                {
                    case Personas.TiposPersonas.Administrativo:
                        MessageBox.Show("Inicio de sesion como administrativo");
                        //SACARLE PERMISO DE NOTAS E INSCRIPCION
                        break;
                    case Personas.TiposPersonas.Alumno:
                        MessageBox.Show("Inicio de sesion como alumno");
                        //SACAR NOTAS, REPORTES;
                        break;

                    case Personas.TiposPersonas.Docente:
                        MessageBox.Show("Inicio de sesion como Docente");
                        break;
          
                }
            }
        }

        private void tsmiDocentes_Click(object sender, EventArgs e)
        {
            formPersonas Personas = new formPersonas(Business.Entities.Personas.TiposPersonas.Docente);
            Personas.ShowDialog();
        }

        private void administrarCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos formCurso = new Cursos();
            formCurso.ShowDialog();
        }

        private void asignarDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocenteCurso formDocenteCurso = new DocenteCurso();
            formDocenteCurso.ShowDialog();
        }

        private void tsmiEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidad = new Especialidades();
            formEspecialidad.ShowDialog();
        }

        private void registroDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegistroNotas(personaActual).ShowDialog();
        }

        private void inscripciònACursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoInscripciones formAluInsc = new AlumnoInscripciones(personaActual);
            formAluInsc.ShowDialog();
        }
    }
}
