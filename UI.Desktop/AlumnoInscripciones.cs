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
    public partial class AlumnoInscripciones : ApplicationForm
    {
        Personas AlumnoActual;

        public AlumnoInscripciones()
        {
            InitializeComponent();
        }

        public AlumnoInscripciones(Personas alumno):this()
        {
            AlumnoActual = alumno;
            listar();
            CargaCombo();
        }

        public void listar()
        {
            try
            {
                var listado = from alu_ins in AlumnoInscripcionesLogic.GetAll()
                              join cur in CursoLogic.GetAll() on alu_ins.IDCurso equals cur.ID
                              join alu in PersonasLogic.GetAll() on alu_ins.IDAlumno equals alu.ID
                              join mat in MateriaLogic.GetAll() on cur.IDMateria equals mat.ID
                              join comi in ComisionesLogic.GetAll() on cur.IDComision equals comi.ID
                              where alu.ID == AlumnoActual.ID
                              select new { alu_ins.ID, Materia = mat.Descripcion, cur.AnioCalendario, alu_ins.Nota, alu_ins.Condicion, comi.Descripcion };
                dgvInscripcion.DataSource = listado.ToList();
            }catch(Exception Ex)
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
            Close();
        }

        private void CargaCombo()
        {
            try {
            var CursoMateria = from c in CursoLogic.GetAll()
                               join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                               join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                               select new { c.ID, Descripcion =" Materia: "+ m.Descripcion + " Comision: " + cm.Descripcion + " Año: " + c.AnioCalendario };

            cbCurso.DataSource = CursoMateria.ToList();
            cbCurso.DisplayMember = "Descripcion";
            cbCurso.ValueMember = "ID";
            cbCurso.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            try {
                AlumnoInscripcion AluIns = new AlumnoInscripcion();

                AluIns.IDCurso = Convert.ToInt32 (cbCurso.SelectedValue);
                AluIns.IDAlumno = AlumnoActual.ID;
                AluIns.Condicion = "Inscripto";
                Curso cur =  CursoLogic.GetOne(AluIns.IDCurso);

                if (Validaciones.ValidarAlumno(AlumnoActual,cur) && Validaciones.ValidarCupo(cur))
                {
                    AluIns.State = BusinessEntity.States.New;
                    AlumnoInscripcionesLogic.Save(AluIns);
                    cur.State = BusinessEntity.States.Modified;
                    CursoLogic.Save(cur);
                    listar();
                }
                else
                {
                    Notificar("Advertencia", "Usted ya está inscripto en el curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
