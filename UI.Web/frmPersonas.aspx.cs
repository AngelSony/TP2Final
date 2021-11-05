using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Windows.Forms;

namespace UI.Web
{
    public partial class frmPersonas : Page
    {
        protected Personas.TiposPersonas tipo;
        protected Usuario uEntity { get; set; }
        protected Personas pEntity { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                if (Session["inputText"] == null)
                {
                    Response.Redirect("~/AdvertenciaLogin.aspx");
                }
                tipo = Personas.TiposPersonas.Alumno;
                LoadGrid();
                CargarCombo();
            }
            */
        }
        private void CargarCombo()
        {
            ddPlanes.DataSource = PlanLogic.GetAll();
            ddPlanes.DataTextField = "Descripcion";
            ddPlanes.DataValueField = "ID";
            ddPlanes.DataBind();
            ddPlanes.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private void LoadGrid()
        {
            var PersonasUsuarios = from p in PersonasLogic.GetAll()
                                   join u in UsuarioLogic.GetAll() on p.ID equals u.IDPersona
                                   join pl in PlanLogic.GetAll() on p.IDPlan equals pl.ID
                                   where p.TipoPersona.Equals(tipo)
                                   select new { u.ID, u.NombreUsuario, u.Clave, u.Habilitado, p.Nombre, p.Apellido, p.Legajo, p.FechaNacimiento, p.Email, p.Direccion, p.Telefono, pl.Descripcion };
            grvPersonas.DataSource = PersonasUsuarios.ToList();
            grvPersonas.DataBind();
        }
        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (SelectedID != 0);
            }
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        private void LoadForm(int id)
        {
            uEntity = UsuarioLogic.GetOne(id);
            pEntity = PersonasLogic.GetOne(uEntity.IDPersona);
            nombreUsuarioTextBox.Text = uEntity.NombreUsuario;
            claveTextBox.Text = uEntity.Clave;
            confirmarClaveTextBox.Text = uEntity.Clave;
            habilitadoCheckBox.Checked = uEntity.Habilitado;
            nombreTextBox.Text = pEntity.Nombre;
            apellidoTextBox.Text = pEntity.Apellido;
            emailTextBox.Text = pEntity.Email;
            fechanacimientoTextBox.Text = pEntity.FechaNacimiento.ToString("dd/MM/yyyy");
            ddPlanes.SelectedValue = pEntity.IDPlan.ToString();
            legajoTextBox.Text = pEntity.Legajo.ToString();
            telefonoTextBox.Text = pEntity.Telefono;
            direccionTextBox.Text = pEntity.Direccion;
        }
        private void LoadEntity(Personas persona, Usuario user)
        {
            persona.Nombre = nombreTextBox.Text;
            persona.Apellido = apellidoTextBox.Text;
            persona.Email = emailTextBox.Text;
            persona.Direccion = direccionTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(fechanacimientoTextBox.Text);
            persona.Legajo = Convert.ToInt32(legajoTextBox.Text);
            persona.IDPlan = Convert.ToInt32(ddPlanes.SelectedValue);
            persona.Telefono = telefonoTextBox.Text;
            persona.TipoPersona = tipo;

            user.NombreUsuario = nombreUsuarioTextBox.Text;
            user.Clave = claveTextBox.Text;
            user.Habilitado = habilitadoCheckBox.Checked;
        }
        private void DeleteEntity(int id)
        {
            Usuario usr = UsuarioLogic.GetOne(id);
            UsuarioLogic.Delete(id);
            PersonasLogic.Delete(usr.IDPersona);
        }
        private void SaveEntity(Personas persona, Usuario user)
        {
            PersonasLogic.Save(persona);
            user.IDPersona = persona.ID;
            UsuarioLogic.Save(user);
        }
        private void EnableForm(bool enable)
        {
            nombreUsuarioTextBox.Enabled = enable;
            claveTextBox.Enabled = enable;
            confirmarClaveTextBox.Enabled = enable;
            habilitadoCheckBox.Enabled = enable;
            nombreTextBox.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;
            telefonoTextBox.Enabled = enable;
            fechanacimientoTextBox.Enabled = enable;
            ddPlanes.Enabled = enable;
            direccionTextBox.Enabled = enable;
            legajoTextBox.Enabled = enable;
        }
        private void ClearForm()
        {
            nombreUsuarioTextBox.Text = string.Empty;
            claveTextBox.Text = string.Empty;
            confirmarClaveTextBox.Text = string.Empty;
            habilitadoCheckBox.Checked = false;
            ddPlanes.SelectedValue = "0";
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            fechanacimientoTextBox.Text = string.Empty;
            legajoTextBox.Text = string.Empty;
            telefonoTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
        }
        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
                EnableForm(true);
                formActionPanel.Visible = true;
                grvPersonas.Enabled = false;
                gridActionsPanel.Visible = false;
            }
        }
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    break;
                case FormModes.Modificacion:
                    uEntity = new Usuario();
                    pEntity = new Personas();
                    uEntity.ID = SelectedID;
                    pEntity.ID = UsuarioLogic.GetOne(SelectedID).IDPersona;
                    uEntity.State = BusinessEntity.States.Modified;
                    pEntity.State = BusinessEntity.States.Modified;
                    LoadEntity(pEntity, uEntity);
                    SaveEntity(pEntity, uEntity);
                    break;
                case FormModes.Alta:
                    uEntity = new Usuario();
                    pEntity = new Personas();
                    LoadEntity(pEntity, uEntity);
                    SaveEntity(pEntity, uEntity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/frmPersonas.aspx");
        }
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                LoadForm(SelectedID);
                EnableForm(false);
                formActionPanel.Visible = true;
                grvPersonas.Enabled = false;
                gridActionsPanel.Visible = false;
            }
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
            formActionPanel.Visible = true;
            gridActionsPanel.Visible = false;
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmPersonas.aspx");
        }
        protected void grvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)grvPersonas.SelectedValue;
        }
    }
}