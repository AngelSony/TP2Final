using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Comisiones : System.Web.UI.Page
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
        private Comision Entity
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
                return SelectedID != 0;
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
            var comisiones = from c in ComisionesLogic.GetAll()
                             join p in PlanLogic.GetAll() on c.IDPlan equals p.ID
                             select new { c.ID, c.Descripcion, c.AnioEspecialidad, Plan = p.Descripcion };
            grdComisiones.DataSource = comisiones.ToList();
            grdComisiones.DataBind();
        }
        private void LoadForm(int id)
        {
            Entity = ComisionesLogic.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
            anioEspecialidadTextBox.Text = Entity.AnioEspecialidad.ToString();
            ddPlanes.SelectedValue = Entity.IDPlan.ToString();
        }
        private void LoadEntity(Comision com)
        {
            com.Descripcion = descripcionTextBox.Text;
            com.AnioEspecialidad = Convert.ToInt32(anioEspecialidadTextBox.Text);
            com.IDPlan = Convert.ToInt32(ddPlanes.SelectedValue);
        }
        private void DeleteEntity(int id)
        {
            ComisionesLogic.Delete(id);
        }
        private void SaveEntity(Comision com)
        {
            ComisionesLogic.Save(com);
        }
        private void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
            anioEspecialidadTextBox.Enabled = enable;
            ddPlanes.Enabled = enable;
        }
        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
            anioEspecialidadTextBox.Text = string.Empty;
            ddPlanes.SelectedValue = "0";
        }
        protected void grdComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)grdComisiones.SelectedValue;
        }
        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
                EnableForm(true);
                formActionsPanel.Visible = true;
                grdComisiones.Enabled = false;
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
                    Entity = new Comision();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Comision();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/Comisiones.aspx");
        }
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                LoadForm(SelectedID);
                EnableForm(false);
                formActionsPanel.Visible = true;
                grdComisiones.Enabled = false;
                gridActionsPanel.Visible = false;
            }
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
            formActionsPanel.Visible = true;
            gridActionsPanel.Visible = false;
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comisiones.aspx");
        }
    }
}