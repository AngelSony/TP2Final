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
    public partial class RegistroNotasDesktop : ApplicationForm
    {
        public AlumnoInscripcion inscripcionActual;
        public RegistroNotasDesktop()
        {
            InitializeComponent();
        }
        public RegistroNotasDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            inscripcionActual = AlumnoInscripcionesLogic.GetOne(ID);
            ModoBoton();
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
        public override void MapearDeDatos()
        {
            txtId.Text = inscripcionActual.ID.ToString();
            Personas alu = PersonasLogic.GetOne(inscripcionActual.IDAlumno);
            txtAlumno.Text = alu.Apellido + " " + alu.Nombre;
            Curso cur = CursoLogic.GetOne(inscripcionActual.IDCurso);
            Comision com = ComisionesLogic.GetOne(cur.IDComision);
            Materia mat = MateriaLogic.GetOne(cur.IDMateria);
            txtCurso.Text = com.Descripcion + " " + mat.Descripcion + " " + cur.AnioCalendario;
            txtCondición.Text = inscripcionActual.Condicion;
            txtNota.Text = inscripcionActual.Nota.ToString();
        }
        public override void MapearADatos()
        {
            switch (Modo)
            {
                 case ModoForm.Baja:
                    inscripcionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    inscripcionActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    inscripcionActual.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                inscripcionActual.Condicion = txtCondición.Text;
                inscripcionActual.Nota = Convert.ToInt32(txtNota.Text);
            }
        }
        public void EnableForm(bool enable)
        {
            txtCondición.Enabled = enable;
            txtNota.Enabled = enable;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoInscripcionesLogic.Save(inscripcionActual);
            switch (Modo)
            {
                case ModoForm.Modificacion:
                    Notificar("Nota y condición actualizados con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ModoForm.Baja:
                    Notificar("Inscripción eliminada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNota.Text))
            {
                Notificar("Error", "El campo Nota no debe estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }else if (string.IsNullOrWhiteSpace(txtCondición.Text))
            {
                Notificar("Error", "El campo Condición no debe estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }else if (!Validaciones.EsNumeroPositivo(txtNota.Text))
            {
                Notificar("Error", "El campo Nota debe ser un número positivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
