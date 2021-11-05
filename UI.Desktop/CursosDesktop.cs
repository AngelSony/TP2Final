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
    public partial class CursosDesktop : ApplicationForm
    {
        public Curso CursoActual;
        public CursosDesktop()
        {
            InitializeComponent();
            CargaCombos();
        }
        public CursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }
        public CursosDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoActual = CursoLogic.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual = new Curso
                    {
                        State = BusinessEntity.States.New
                    };
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoActual.IDMateria = Convert.ToInt32(cbMateria.SelectedValue);
                CursoActual.IDComision = Convert.ToInt32(cbComision.SelectedValue);
                CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);
                CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);
            }
        }
        public override void MapearDeDatos() 
        {
            txtID.Text = CursoActual.ID.ToString();
            cbComision.SelectedValue = CursoActual.IDComision;
            cbMateria.SelectedValue = CursoActual.IDMateria;
            txtCupo.Text = CursoActual.Cupo.ToString();
            txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
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
        private void CargaCombos()
        {
            cbMateria.DataSource = MateriaLogic.GetAll();
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "ID";
            cbMateria.SelectedIndex = -1;

            cbComision.DataSource = ComisionesLogic.GetAll();
            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "ID";
            cbComision.SelectedIndex = -1;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic.Save(CursoActual);
            switch (Modo)
            {
                case ModoForm.Alta:
                    Notificar("Curso registrado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ModoForm.Modificacion:
                    Notificar("Curso actualizado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ModoForm.Baja:
                    Notificar("Curso eliminado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtAnioCalendario.Text))
            {
                Notificar("Error", "El campo Año Calendario no debe estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if(string.IsNullOrWhiteSpace(txtCupo.Text))
            {
                Notificar("Error", "El campo Cupo no debe estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            /*else if(cbComision.SelectedValue == null)
            {
                Notificar("Error", "Debe especificar una comisión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }*/
            else if (cbMateria.SelectedValue.Equals(null))
            {
                Notificar("Error", "Debe especificar una materia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                GuardarCambios();
                Close();
            }
        }
    }
}
