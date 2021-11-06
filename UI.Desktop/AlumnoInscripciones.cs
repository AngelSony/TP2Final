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
    public partial class AlumnoInscripciones : Form
    {
        Personas AlumnoActual;

        public AlumnoInscripciones()
        {
            InitializeComponent();
         
        }

        public AlumnoInscripciones(Personas alumno)
        {
            AlumnoActual = alumno;
            listar();
        }

        public void listar()
        {
            var Listado = from alu_ins in AlumnoInscripcionesLogic.GetAll()
                          join cur in CursoLogic.GetAll() on alu_ins.IDCurso equals cur.ID
                          join alu in PersonasLogic.GetAll() on alu_ins.IDAlumno equals alu.ID
                          join mat in MateriaLogic.GetAll() on cur.IDMateria equals mat.ID
                          where alu.ID.Equals(AlumnoActual.ID)
                          select new {alu_ins.ID, alu.Nombre , alu.Apellido,  cur.AnioCalendario, alu_ins.Nota,alu_ins.Condicion };

            dgvInscripcion.DataSource = Listado.ToList();

        }


            
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
