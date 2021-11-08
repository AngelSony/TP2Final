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
    public partial class ComisionesDesktop : ApplicationForm
    {
        private Comision comisionActual;
        public ComisionesDesktop()
        {
            InitializeComponent();
            CargaCombo();
        }
        public ComisionesDesktop(ModoForm modo): this()
        {
            Modo = modo;
            ModoBoton();
        }
        public ComisionesDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
            comisionActual = ComisionesLogic.GetOne(ID);
            MapearDeDatos();
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
            cbPlanes.Enabled = enable;
            txtAnioEspecialidad.Enabled = enable;
            txtDescripcion.Enabled = enable;
            }
        private void CargaCombo()
        {
            cbPlanes.DataSource = PlanLogic.GetAll();
            cbPlanes.DisplayMember = "Descripcion";
            cbPlanes.ValueMember = "ID";
            cbPlanes.SelectedIndex = -1;
        }
        public override void MapearDeDatos()
        {
            txtId.Text = comisionActual.ID.ToString();
            txtDescripcion.Text = comisionActual.Descripcion;
            txtAnioEspecialidad.Text = comisionActual.AnioEspecialidad.ToString();
            cbPlanes.SelectedValue = comisionActual.IDPlan;
        }
        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    comisionActual = new Comision
                    {
                        State = BusinessEntity.States.New
                    };
                    break;
                case ModoForm.Baja:
                    comisionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    comisionActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    comisionActual.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                comisionActual.Descripcion = txtDescripcion.Text;
                comisionActual.AnioEspecialidad = Convert.ToInt32(txtAnioEspecialidad.Text);
                comisionActual.IDPlan = Convert.ToInt32(cbPlanes.SelectedValue);
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionesLogic.Save(comisionActual);
            switch (Modo)
            {
                case ModoForm.Alta:
                    Notificar("Comisión registrada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ModoForm.Modificacion:
                    Notificar("Comisión actualizada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ModoForm.Baja:
                    Notificar("Comisión eliminada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtAnioEspecialidad.Text))
            {
                Notificar("Error", "El campo Año Especialidad no debe estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.EsNumeroPositivo(txtAnioEspecialidad.Text))
            {
                Notificar("Error", "El campo Año Especialidad no es válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(cbPlanes.SelectedValue == null)
            {
                Notificar("Error", "Debe especificar un Plan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
