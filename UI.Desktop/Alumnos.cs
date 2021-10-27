using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
            dgvAlumnos.AutoGenerateColumns = false;

        }
        

        public void Listar()
        {
            PersonasLogic pl = new PersonasLogic();
            List<Personas> misAlu = new List<Personas>();
            foreach(var unAlu in pl.GetAll())
            {
                if(unAlu.TipoPersona.Equals(Personas.TiposPersonas.Alumno))
                {
                    misAlu.Add(unAlu);
                }
            }

            dgvAlumnos.DataSource = misAlu; 
            
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            Listar();   
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {

            AlumnosDesktop formAlumno = new AlumnosDesktop(ApplicationForm.ModoForm.Alta);
            formAlumno.ShowDialog();
            Listar();       
        
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Personas)dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnosDesktop formAlumno = new AlumnosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formAlumno.ShowDialog();
            Listar();

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Personas)dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnosDesktop formAlumno = new AlumnosDesktop(ID, ApplicationForm.ModoForm.Baja);
            formAlumno.ShowDialog();
            Listar();
        }
    }
}
