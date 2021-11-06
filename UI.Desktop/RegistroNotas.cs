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
    public partial class RegistroNotas : Form
    {
        private Personas personaActual;
        private int idCurso;
        private bool band;
        public RegistroNotas() 
        {
            band = false;
            idCurso = 0;
            InitializeComponent();
            dgvNotas.AutoGenerateColumns = false;
        }
        public RegistroNotas(Personas persona) : this()
        {
            personaActual = persona;
            CargaCombo();
        }
        private void CargaCombo()
        {
            switch (personaActual.TipoPersona)
            {
                case Personas.TiposPersonas.Docente:
                    var cursos = from c in CursoLogic.GetAll()
                                 join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                                 join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                                 join dc in DocenteCursoLogic.GetAll() on c.ID equals dc.IDCurso
                                 where dc.IDDocente.Equals(personaActual.ID)
                                 select new { ID = c.ID, Descripcion = m.Descripcion + " " + cm.Descripcion + " " + c.AnioCalendario };
                    cbCurso.DataSource = cursos.ToList();
                    tsbEliminar.Enabled = false;
                    break;
                case Personas.TiposPersonas.Administrativo:
                    var todoscursos = from c in CursoLogic.GetAll()
                                 join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                                 join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                                 select new { ID = c.ID, Descripcion = m.Descripcion + " " + cm.Descripcion + " " + c.AnioCalendario };
                    cbCurso.DataSource = todoscursos.ToList();
                    break;
                default:
                    break;
            }
            cbCurso.DisplayMember = "Descripcion";
            cbCurso.ValueMember = "ID";
            cbCurso.SelectedIndex = -1;
        }
        private void Listar()
        {
            var inscripciones = from i in AlumnoInscripcionesLogic.GetAll()
                                join a in PersonasLogic.GetAll() on i.IDAlumno equals a.ID
                                where i.IDCurso == idCurso
                                select new { i.ID, Alumno = a.Apellido + " " + a.Nombre, i.Condicion, i.Nota};
            dgvNotas.DataSource = inscripciones.ToList();
        }

        private void cbCurso_SelectedValueChanged(object sender, EventArgs e)
        {
            if(band)
            {
                idCurso = Convert.ToInt32(cbCurso.SelectedValue);
                Listar();
            }
            if(cbCurso.SelectedIndex == -1)
            {
                band = true;
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvNotas.SelectedRows[0].Cells["ID"].Value);
            RegistroNotasDesktop formNotas = new RegistroNotasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formNotas.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvNotas.SelectedRows[0].Cells["ID"].Value);
            RegistroNotasDesktop formNotas = new RegistroNotasDesktop(ID, ApplicationForm.ModoForm.Baja);
            formNotas.ShowDialog();
            Listar();
        }
    }
}
