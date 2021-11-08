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
    public partial class PlanesDesktop : ApplicationForm
    {
        public Plan planActual;
        public List<Materia> materiasActuales;
        public PlanesDesktop()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
            CargaCombo();
            materiasActuales = new List<Materia>();
        }
        public PlanesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }
        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            planActual = PlanLogic.GetOne(ID);
            foreach (Materia materia in MateriaLogic.GetAll())
            {
                if (materia.IDPlan.Equals(planActual.ID))
                {
                    materiasActuales.Add(materia);
                    materia.State = BusinessEntity.States.Unmodified;
                }
            }
            MapearDeDatos();
            ModoBoton();
        }
        public void CargaCombo()
        {
            cbEspecial.DataSource = EspecialidadesLogic.GetAll();
            cbEspecial.DisplayMember = "Descripcion";
            cbEspecial.ValueMember = "ID";
            cbEspecial.SelectedIndex = -1;
        }
        public override void MapearDeDatos()
        {
            txtID.Text = planActual.ID.ToString();
            txtDescripcion.Text = planActual.Descripcion;
            cbEspecial.SelectedValue = planActual.IDEspecialidad;

            Listar();
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                planActual = new Plan();
                materiasActuales = new List<Materia>();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                planActual.Descripcion= txtDescripcion.Text.Trim();
                planActual.IDEspecialidad = Convert.ToInt32(cbEspecial.SelectedValue);
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    planActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    planActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    planActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    planActual.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
        }
        private void ModoBoton()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    EnableForm(false);
                    btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
        }
        public void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
            cbEspecial.Enabled = enable;
            toolStrip1.Enabled = enable;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            if (Modo == ModoForm.Alta)
            {
                PlanLogic.Save(planActual);
                foreach (Materia mat in materiasActuales)
                {
                    mat.IDPlan = planActual.ID;
                    MateriaLogic.Save(mat);
                }
                Notificar("Plan Agregado con Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Modo == ModoForm.Modificacion)
            {
                foreach (Materia mat in materiasActuales)
                {
                    if(mat.State == BusinessEntity.States.Deleted)
                    {
                        MateriaLogic.Delete(mat.ID);
                    }
                }
                PlanLogic.Save(planActual);
                foreach (Materia mat in materiasActuales)
                {
                    if (mat.State != BusinessEntity.States.Deleted)
                    {
                        mat.IDPlan = planActual.ID;
                        MateriaLogic.Save(mat);
                    }
                }
                Notificar("Plan Modificado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(Modo == ModoForm.Baja)
            {
                foreach (Materia mat in materiasActuales)
                {
                    MateriaLogic.Delete(mat.ID);
                }
                PlanLogic.Delete(planActual.ID);
                Notificar("Plan Eliminado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Listar()
        {
            List<Materia> matListar = new List<Materia>();
            foreach(Materia mat in materiasActuales)
            {
                if(mat.State!= BusinessEntity.States.Deleted)
                {
                    matListar.Add(mat);
                }
            }
            dgvMaterias.DataSource = null;
            dgvMaterias.DataSource = matListar;
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                Notificar("Advertencia", "Campo Descripción incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cbEspecial.SelectedIndex == -1)
            {
                Notificar("Advertencia", "Debe seleccionar una Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else { return true; }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar() || Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriasDesktop formMaterias = new MateriasDesktop(ref materiasActuales, ApplicationForm.ModoForm.Alta);
            formMaterias.ShowDialog();
            Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriasDesktop formMaterias = new MateriasDesktop(ref materiasActuales, ID, ApplicationForm.ModoForm.Modificacion);
            formMaterias.ShowDialog();
            Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriasDesktop formMateria = new MateriasDesktop(ref materiasActuales, ID, ApplicationForm.ModoForm.Baja);
            formMateria.ShowDialog();
            Listar();
        }
    }
}
