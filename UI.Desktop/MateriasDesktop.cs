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
    public partial class MateriasDesktop : ApplicationForm
    {
        public Materia MateriaActual;
        public List<Materia> materiasActuales;
        public MateriasDesktop()
        {
            InitializeComponent();
        }
        public MateriasDesktop(ref List<Materia> mats, ModoForm modo) : this()
        {
            Modo = modo;
            materiasActuales = mats;
            ModoBoton();
        }
        public MateriasDesktop(ref List<Materia> mats,int ID, ModoForm modo) : this()
        {
            Modo = modo;
            materiasActuales = mats;
            foreach(Materia mat in materiasActuales)
            {
                if(mat.ID == ID)
                {
                    MateriaActual = mat;
                }
            }
            MapearDeDatos();
            ModoBoton();
        }
        public override void MapearDeDatos()
        {
            txtID.Text = MateriaActual.ID.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion;
            txtHSSemanales.Text = MateriaActual.HSSemanales.ToString();
            txtHSTotales.Text = MateriaActual.HSTotales.ToString();
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
        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
            txtHSSemanales.Enabled = enable;
            txtHSTotales.Enabled = enable;
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                MateriaActual = new Materia();
                MateriaActual.ID = 0;
            }
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                MateriaActual.Descripcion = txtDescripcion.Text.Trim();
                MateriaActual.HSSemanales = Convert.ToInt32(txtHSSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(txtHSTotales.Text);
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    MateriaActual.State = BusinessEntity.States.Unmodified;
                    break;
                default:
                    break;
            }
        }
        public override void GuardarCambios() {
            MapearADatos();
            if (Modo == ModoForm.Alta)
            {
                materiasActuales.Add(MateriaActual);
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                Notificar("Advertencia", "Campo Descripcion incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtHSSemanales.Text))
            {
                Notificar("Advertencia", "Campo Horas Semanales incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtHSTotales.Text))
            {
                Notificar("Advertencia", "Campo Usuario incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
