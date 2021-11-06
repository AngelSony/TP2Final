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
            if (Session["TipoPersona"] == null)
            {
                Response.Redirect("~/AdvertenciaLogin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    LoadGrid();
                }
            }
        }
        private void LoadGrid()
        {
            grdPlanes.DataSource = PlanLogic.GetAll();
            grdPlanes.DataBind();
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
            especialdadTextBox.Text = Entity.IDEspecialidad.ToString(); //CAMBIAR
        }
        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = descripcionTextBox.Text;
            plan.IDEspecialidad = Convert.ToInt32( especialdadTextBox.Text);
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
            especialdadTextBox.Enabled = enable;
        }
        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
            especialdadTextBox.Text = string.Empty;
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