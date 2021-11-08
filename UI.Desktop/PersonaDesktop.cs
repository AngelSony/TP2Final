using Business.Entities;
using Business.Logic;
using System;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        private Personas.TiposPersonas tipoPersona;
        private Usuario usrActual;
        private Personas perActual;
        public PersonaDesktop()
        {
            InitializeComponent();
            CargaCombo();
        }
        public PersonaDesktop(Personas.TiposPersonas tipo, ModoForm modo) : this()
        {
            tipoPersona = tipo;
            Text = tipoPersona.ToString();
            Modo = modo;
            ModoBoton();
        }
        public PersonaDesktop(Personas.TiposPersonas tipo, ModoForm modo, int ID) : this()
        {
            tipoPersona = tipo;
            Text = tipoPersona.ToString();
            Modo = modo;
            try {
                usrActual = UsuarioLogic.GetOne(ID);
                perActual = PersonasLogic.GetOne(usrActual.IDPersona);
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MapearDeDatos();
            ModoBoton();
        }
        private void CargaCombo()
        {
            try { 
                cbPlan.DataSource = PlanLogic.GetAll();
                cbPlan.DisplayMember = "Descripcion";
                cbPlan.ValueMember = "ID";
                cbPlan.SelectedIndex = -1;
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public override void MapearDeDatos()
        {
            txtId.Text = usrActual.ID.ToString();
            chkHabilitado.Checked = usrActual.Habilitado;
            txtNombreUsuario.Text = usrActual.NombreUsuario;
            txtClave.Text = usrActual.Clave;
            txtConfirmarClave.Text = usrActual.Clave;
            txtApellido.Text = perActual.Apellido;
            txtNombre.Text = perActual.Nombre;
            txtDireccion.Text = perActual.Direccion;
            txtEmail.Text = perActual.Email;
            txtTelefono.Text = perActual.Telefono;
            cbPlan.SelectedValue = perActual.IDPlan;
            txtLegajo.Text = perActual.Legajo.ToString();
            txtFechaNac.Text = perActual.FechaNacimiento.ToString("dd/MM/yyyy");
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                usrActual = new Usuario();
                perActual = new Personas();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                usrActual.NombreUsuario = txtNombreUsuario.Text.Trim();
                usrActual.Clave = txtClave.Text.Trim();
                usrActual.Habilitado = chkHabilitado.Checked;

                perActual.Apellido = txtApellido.Text.Trim();
                perActual.Nombre = txtNombre.Text.Trim();
                perActual.Legajo = Convert.ToInt32(txtLegajo.Text.Trim());
                perActual.Direccion = txtDireccion.Text.Trim();
                perActual.Email = txtEmail.Text.Trim();
                perActual.Telefono = txtTelefono.Text.Trim();
                perActual.TipoPersona = Personas.TiposPersonas.Alumno;
                perActual.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                perActual.IDPlan = Convert.ToInt32(cbPlan.SelectedValue);
                perActual.TipoPersona = tipoPersona;
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    usrActual.State = BusinessEntity.States.New;
                    perActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    usrActual.State = BusinessEntity.States.Deleted;
                    perActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    usrActual.State = BusinessEntity.States.Unmodified;
                    perActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    usrActual.State = BusinessEntity.States.Modified;
                    perActual.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            try {
                PersonasLogic.Save(perActual);
                usrActual.IDPersona = perActual.ID;
                UsuarioLogic.Save(usrActual);
            }
            catch (Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (Modo == ModoForm.Alta)
            {
                Notificar("Usuario Registrado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Modo == ModoForm.Modificacion)
            {
                Notificar("Usuario Modificado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(Modo == ModoForm.Baja)
            {
                Notificar("Usuario Eliminado con éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Notificar("Advertencia", "Campo Nombre incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                Notificar("Advertencia", "Campo Apellido incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                Notificar("Advertencia", "Campo Legajo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                Notificar("Advertencia", "Campo Telefono incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                Notificar("Advertencia", "Campo Direccion incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (cbPlan.SelectedValue == null)
            {
                Notificar("Advertencia", "Seleccione un plan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.EsMailValido(txtEmail.Text))
            {
                Notificar("Advertencia", "Email no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.EsFechaValida(txtFechaNac.Text))
            {
                Notificar("Advertencia", "El formato de la fecha debe ser dd/MM/aaaa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!Validaciones.EsClaveValida(txtClave.Text))
            {
                Notificar("Advertencia", "Clave inválida. Debe tener al menos 8 caracteres, y al menos una letra y un número", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (!txtConfirmarClave.Text.Equals(txtClave.Text))
            {
                Notificar("Advertencia", "Las Claves no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                Notificar("Advertencia", "Campo Nombre Usuario incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else 
            { 
                return true; 
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Baja || Validar())
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
