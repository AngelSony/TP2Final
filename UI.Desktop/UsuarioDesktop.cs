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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public Usuario UsuarioActual;
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic UsuarioNegocio = new UsuarioLogic();
            UsuarioActual = UsuarioNegocio.GetOne(ID);
            MapearDeDatos();
        }
        public override void MapearDeDatos()
        {
            txtID.Text = UsuarioActual.ID.ToString();
            chkHabilitado.Checked = UsuarioActual.Habilitado;
            txtNombre.Text = UsuarioActual.Nombre;
            txtApellido.Text = UsuarioActual.Apellido;
            txtEmail.Text = UsuarioActual.EMail;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            txtClave.Text = UsuarioActual.Clave;
            txtConfirmarclave.Text = UsuarioActual.Clave;
            ModoBoton();
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

        public override void MapearADatos() { 
            if(Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
            }

            if(Modo == ModoForm.Modificacion || Modo == ModoForm.Alta)
            {
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Nombre = txtNombre.Text.Trim();
                UsuarioActual.Apellido = txtApellido.Text.Trim();
                UsuarioActual.EMail = txtEmail.Text.Trim();
                UsuarioActual.NombreUsuario = txtUsuario.Text.Trim();
                UsuarioActual.Clave = txtClave.Text.Trim();
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
                default:
                    break;
            }
        }
        public override void GuardarCambios() {
            MapearADatos();
            UsuarioLogic UsuarioNegocio = new UsuarioLogic();
            UsuarioNegocio.Save(UsuarioActual);
        }
        public override bool Validar() {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)){
                Notificar("Advertencia", "Campo Nombre incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (string.IsNullOrWhiteSpace(txtApellido.Text)) {
                Notificar("Advertencia", "Campo Apellido incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (string.IsNullOrWhiteSpace(txtEmail.Text)) {
                Notificar("Advertencia", "Campo Email incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (string.IsNullOrWhiteSpace(txtUsuario.Text)) {
                Notificar("Advertencia", "Campo Usuario incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (string.IsNullOrWhiteSpace(txtClave.Text)) {
                Notificar("Advertencia", "Campo Clave incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (string.IsNullOrWhiteSpace(txtConfirmarclave.Text)) {
                Notificar("Advertencia", "Campo Confirmar Clave incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (!txtClave.Text.Equals(txtConfirmarclave.Text)){
                Notificar("Advertencia", "Las claves no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (txtClave.Text.Length < 8){
                Notificar("Advertencia", "La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else if (!txtEmail.Text.Contains('@')) {
                Notificar("Advertencia", "Email no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; }
            else { return true; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }else if (Validar())
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
