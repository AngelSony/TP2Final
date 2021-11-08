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
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        public Especialidad EspecialidadActual;
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadesDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }
        public EspecialidadesDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            EspecialidadActual = EspecialidadesLogic.GetOne(ID);
            MapearDeDatos();
            ModoBoton();
        }
        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    EspecialidadActual = new Especialidad
                    {
                        State = BusinessEntity.States.New
                    };
                    break;
                case ModoForm.Baja:
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    EspecialidadActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = txtDescripcion.Text;
            }
        }
        public override void MapearDeDatos()
        {
            txtID.Text = EspecialidadActual.ID.ToString();
            txtDescripcion.Text = EspecialidadActual.Descripcion.ToString();
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
            try { 
                EspecialidadesLogic.Save(EspecialidadActual);
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    Notificar("Especialidad registrada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ModoForm.Modificacion:
                    Notificar("Especialidad actualizada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ModoForm.Baja:
                    Notificar("Especialidad eliminada con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    break;
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                Notificar("Error", "El campo Especialidad no debe estar vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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





















        
