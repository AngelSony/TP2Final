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
        public PlanesDesktop()
        {
            InitializeComponent();
        }

        

        public PlanesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }

        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic PlanLogic = new PlanLogic();
            planActual = PlanLogic.GetOne(ID);
            MapearDeDatos();
        }



        public override void MapearDeDatos()
        {
            txtID.Text = planActual.ID.ToString();
            txtDescripcion.Text = planActual.Descripcion;
            txtEspecialidad.Text = planActual.IDEspecialidad.ToString(); //CAMBIAR


            List<Materia> misMaterias = new List<Materia>();

            foreach (var materia in MateriaLogic.GetAll())
            {
                if (materia.IDPlan.Equals(planActual.ID))
                {
                    misMaterias.Add(materia);
                }
            }
            dgvMaterias.AutoGenerateColumns = false;
            dgvMaterias.DataSource = misMaterias;
            ModoBoton();

        }




        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {

                planActual = new Plan();

               

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
           
            PlanLogic.Save(planActual);

          
            if (Modo == ModoForm.Alta)
            {
                MessageBox.Show("Plan Agregado con Éxito");

            }
            if (Modo == ModoForm.Modificacion)
            {
                MessageBox.Show("Plan Modificado con Éxito");
            }

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
                MateriasDesktop formMaterias = new MateriasDesktop(ApplicationForm.ModoForm.Alta);
                formMaterias.ShowDialog();
                
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriasDesktop formMaterias = new MateriasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formMaterias.ShowDialog();
            
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Materia)dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriasDesktop formMateria = new MateriasDesktop(ID, ApplicationForm.ModoForm.Baja);
            formMateria.ShowDialog();
         
        }

        private void PlanesDesktop_Load(object sender, EventArgs e)
        {

        }
    }
}
