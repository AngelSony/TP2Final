using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Planes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoPersona"] == null)
                {
                    Response.Redirect("~/AdvertenciaLogin.aspx");
                }
                else if ((int)Session["TipoPersona"] != (int)Personas.TiposPersonas.Administrativo)
                {
                    Response.Redirect("~/AdvertenciaAccesoUsuario.aspx");
                }
                LoadGrid();
                CargarCombo();
            }
        }
        private void LoadGrid()
        {
            var planes = from p in PlanLogic.GetAll()
                         join e in EspecialidadesLogic.GetAll() on p.IDEspecialidad equals e.ID
                         select new { p.ID, p.Descripcion, Especialidad = e.Descripcion };
            grdPlanes.DataSource = planes.ToList();
            grdPlanes.DataBind();
        }
        private void CargarCombo()
        {
            ddEspecialidad.DataSource = EspecialidadesLogic.GetAll();
            ddEspecialidad.DataTextField = "Descripcion";
            ddEspecialidad.DataValueField = "ID";
            ddEspecialidad.DataBind();
            ddEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private Plan Entity
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
            Entity = PlanLogic.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
            ddEspecialidad.SelectedValue = Entity.IDEspecialidad.ToString();
        }
        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = descripcionTextBox.Text;
            plan.IDEspecialidad = Convert.ToInt32(ddEspecialidad.SelectedValue);
        }
        private void DeleteEntity(int id)
        {
            PlanLogic.Delete(id);
        }
        private void SaveEntity(Plan plan)
        {
            PlanLogic.Save(plan);
        }
        private void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
            ddEspecialidad.Enabled = enable;
        }
        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
            ddEspecialidad.SelectedValue = "0";
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
                grdPlanes.Enabled = false;
                grdActionPanel.Visible = false;
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
                    Entity = new Plan();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Plan();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/Planes.aspx");
        }
        protected void elmininarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                LoadForm(SelectedID);
                EnableForm(false);
                formActionPanel.Visible = true;
                grdPlanes.Enabled = false;
                grdActionPanel.Visible = false;
            }
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
            formActionPanel.Visible = true;
            grdActionPanel.Visible = false;
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Planes.aspx");
        }
        protected void grdPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)grdPlanes.SelectedValue;
        }
    }
}