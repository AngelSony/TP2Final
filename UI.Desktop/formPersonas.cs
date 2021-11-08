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
    public partial class formPersonas : Form
    {
        private Personas.TiposPersonas tipoPersona;
        public formPersonas(Personas.TiposPersonas tipo)
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
            tipoPersona = tipo;
            Text = tipoPersona.ToString();
        }
        public void Listar()
        {
            try { 
                var PersonasUsuarios = from p in PersonasLogic.GetAll()
                                       join u in UsuarioLogic.GetAll() on p.ID equals u.IDPersona
                                       join pl in PlanLogic.GetAll() on p.IDPlan equals pl.ID
                                       where p.TipoPersona.Equals(tipoPersona) 
                                       select new { u.ID, u.NombreUsuario, u.Clave, u.Habilitado, p.Nombre, p.Apellido, p.Legajo, p.FechaNacimiento, p.Email, p.Direccion, p.Telefono, pl.Descripcion};

                dgvPersonas.DataSource = PersonasUsuarios.ToList();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void fromPersonas_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop frmPersonas = new PersonaDesktop(tipoPersona, ApplicationForm.ModoForm.Alta);
            frmPersonas.ShowDialog();
            Listar();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPersonas.SelectedRows[0].Cells["idUsuario"].Value;
            PersonaDesktop frmPersonas = new PersonaDesktop(tipoPersona, ApplicationForm.ModoForm.Modificacion, ID);
            frmPersonas.ShowDialog();
            Listar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPersonas.SelectedRows[0].Cells["idUsuario"].Value;
            PersonaDesktop frmPersonas = new PersonaDesktop(tipoPersona, ApplicationForm.ModoForm.Baja, ID);
            frmPersonas.ShowDialog();
            Listar();
        }
    }
}
