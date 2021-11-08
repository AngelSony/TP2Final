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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        private Business.Entities.DocenteCurso DocenteCursoSeleccionado;
        public DocenteCursoDesktop()
        {
            InitializeComponent();
            CargaCombos();
        }
        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }
        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            try {
                DocenteCursoSeleccionado  = DocenteCursoLogic.GetOne(ID);
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MapearDeDatos();
            ModoBoton();
        }
        public override void MapearDeDatos()
        {
            txtID.Text = DocenteCursoSeleccionado.ID.ToString();
            cbCargo.SelectedItem = DocenteCursoSeleccionado.Cargo;
            cbCurso.SelectedValue = DocenteCursoSeleccionado.IDCurso;
            cbDocente.SelectedValue = DocenteCursoSeleccionado.IDDocente;
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                DocenteCursoSeleccionado = new Business.Entities.DocenteCurso();
            }
            if (Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                DocenteCursoSeleccionado.Cargo = (Business.Entities.DocenteCurso.TiposCargos)cbCargo.SelectedIndex;
                DocenteCursoSeleccionado.IDCurso = Convert.ToInt32(cbCurso.SelectedValue);
                DocenteCursoSeleccionado.IDDocente = Convert.ToInt32 (cbDocente.SelectedValue);
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    DocenteCursoSeleccionado.State = BusinessEntity.States.New;
                    try
                    {
                        Validaciones.ValidarDocentes(DocenteCursoSeleccionado);
                        DocenteCursoSeleccionado.State = BusinessEntity.States.New;
                    }
                    catch(Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                        DocenteCursoSeleccionado.State = BusinessEntity.States.Unmodified;
                    }

                    break;
                case ModoForm.Modificacion:
                    DocenteCursoSeleccionado.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    DocenteCursoSeleccionado.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    DocenteCursoSeleccionado.State = BusinessEntity.States.Unmodified;
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
                    btnGuardar.Text = "Guardar";
                    break;
                case ModoForm.Modificacion:
                    btnGuardar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    btnGuardar.Text = "Eliminar";
                    
                    break;
                case ModoForm.Consulta:
                    btnGuardar.Text = "Aceptar";
                    break;
                default:
                    break;
            }
        }
        private void CargaCombos()
        {
            try {
                cbCargo.DataSource = Enum.GetValues(typeof(Business.Entities.DocenteCurso.TiposCargos));
           
                cbDocente.DataSource = PersonasLogic.GetAll().Where(d => d.TipoPersona == Personas.TiposPersonas.Docente).Select(p => new { ID = p.ID, NombreApellido = $"{p.Nombre} {p.Apellido}" }).ToList();
                cbDocente.DisplayMember = "NombreApellido";
                cbDocente.ValueMember = "ID";

                var CursoMateria = from c in CursoLogic.GetAll()
                                       join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                                       join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                                       select new {c.ID, Descripcion =  m.Descripcion + " " + cm.Descripcion + " " + c.AnioCalendario };

                cbCurso.DataSource = CursoMateria.ToList();
                cbCurso.DisplayMember = "Descripcion";
                cbCurso.ValueMember = "ID";
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            try {
                DocenteCursoLogic.Save(DocenteCursoSeleccionado);
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(cbDocente.Text))
            {
                Notificar("Advertencia", "Campo Docente incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(cbCurso.Text))
            {
                Notificar("Advertencia", "Campo Curso incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(cbCargo.Text))
            {
                Notificar("Advertencia", "Campo Cargo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else { return true; }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar() || Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
        }
    }
}
