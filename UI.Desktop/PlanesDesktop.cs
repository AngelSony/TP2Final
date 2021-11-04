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
        }
        public override void MapearDeDatos()
        {
            txtID.Text = planActual.ID.ToString();
            txtDescripcion.Text = planActual.Descripcion;
            txtEspecialidad.Text = planActual.IDEspecialidad.ToString(); //CAMBIAR

            listar();
            ModoBoton();

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
                planActual.IDEspecialidad = Convert.ToInt32(txtEspecialidad.Text.Trim()); //CAMNIAR
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
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            MessageBox.Show(materiasActuales.Count.ToString());

            if (Modo == ModoForm.Alta)
            {
                PlanLogic.Save(planActual);
                foreach (Materia mat in materiasActuales)
                {
                    mat.IDPlan = planActual.ID;
                    MateriaLogic.Save(mat);
                }
                MessageBox.Show("Plan Agregado con Éxito");
            }
            if (Modo == ModoForm.Modificacion)
            {
                foreach (Materia mat in materiasActuales)
                {
                    if(mat.State == BusinessEntity.States.Deleted)
                    {
                        MessageBox.Show("Se va a eliminar: "+mat.ID);
                        MateriaLogic.Delete(mat.ID);
                    }
                }
                PlanLogic.Save(planActual);
                foreach (Materia mat in materiasActuales)
                {
                    if (mat.State != BusinessEntity.States.Deleted)
                    {
                        MateriaLogic.Save(mat);
                    }
                }
                MessageBox.Show("Plan Modificado con Éxito");
            }
            if(Modo == ModoForm.Baja)
            {
                foreach (Materia mat in materiasActuales)
                {
                    MateriaLogic.Delete(mat.ID);
                }
                PlanLogic.Delete(planActual.ID);
            }
        }
        public void listar()
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
            else if (string.IsNullOrWhiteSpace(txtEspecialidad.Text))
            {
                Notificar("Advertencia", "Campo Apellido incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else { return true; }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            else if (Validar())

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
            listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriasDesktop formMaterias = new MateriasDesktop(ref materiasActuales, ID, ApplicationForm.ModoForm.Modificacion);
            formMaterias.ShowDialog();
            listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriasDesktop formMateria = new MateriasDesktop(ref materiasActuales, ID, ApplicationForm.ModoForm.Baja);
            formMateria.ShowDialog();
            listar();
        }
        private void PlanesDesktop_Load(object sender, EventArgs e)
        {
        }
    }
}
