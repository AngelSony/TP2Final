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
    public partial class Alumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["inputText"] == null)
            {
                
                Response.Redirect("~/AdvertenciaLogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                   
                    LoadGrid();
                    CargarCombo();
     
                }
            }


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
            List<Personas> misAlu = new List<Personas>();
            foreach (var unAlu in PersonasLogic.GetAll())
            {
                if (unAlu.TipoPersona.Equals(Personas.TiposPersonas.Alumno))
                {
                    misAlu.Add(unAlu);
                }
            }

            grdAlumnos.DataSource = misAlu;
            grdAlumnos.DataBind();
        

        }
        private Personas Entity
        {
            get;
            set;
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
            Entity = PersonasLogic.GetOne(id);
            nombreTextBox.Text = Entity.Nombre;
            apellidoTextBox.Text = Entity.Apellido;
            emailTextBox.Text = Entity.Email;
            fechanacimientoTextBox.Text = Entity.FechaNacimiento.ToString("dd/MM/yyyy");
            ddPlanes.SelectedValue = Entity.IDPlan.ToString();
            legajoTextBox.Text = Entity.Legajo.ToString();
            telefonoTextBox.Text = Entity.Telefono;
            direccionTextBox.Text = Entity.Direccion;

        }
        private void LoadEntity(Personas alumno)
        {
            alumno.Nombre = nombreTextBox.Text;
            alumno.Apellido = apellidoTextBox.Text;
            alumno.Email = emailTextBox.Text;
            alumno.Direccion= direccionTextBox.Text;
            alumno.FechaNacimiento= Convert.ToDateTime(fechanacimientoTextBox.Text);
            alumno.Legajo = Convert.ToInt32(legajoTextBox.Text);
            alumno.IDPlan = Convert.ToInt32(ddPlanes.SelectedValue);
            alumno.Telefono = telefonoTextBox.Text;
            alumno.TipoPersona = Personas.TiposPersonas.Alumno;
        }
        private void DeleteEntity(int id)
        {
            PersonasLogic.Delete(id);
        }
        private void SaveEntity(Personas alumno)
        {
            PersonasLogic.Save(alumno);
        }
        private void EnableForm(bool enable)
        {
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
                grdAlumnos.Enabled = false;
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
                    Entity = new Personas();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Personas();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/Alumno.aspx");
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
                grdAlumnos.Enabled = false;
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
            Response.Redirect("~/Alumno.aspx");
        }
        protected void grdAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)grdAlumnos.SelectedValue;
        }
    }
}