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
    public partial class Especialidades : System.Web.UI.Page
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
            }
        }
        private Especialidad Entity
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
        private void LoadGrid()
        {
            gvEspecialidades.DataSource = EspecialidadesLogic.GetAll();
            gvEspecialidades.DataBind();
        }
        private void LoadForm(int id)
        {
            Entity = EspecialidadesLogic.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
        }
        private void LoadEntity(Especialidad es)
        {
            es.Descripcion = descripcionTextBox.Text;
        }
        private void DeleteEntity(int id)
        {
            EspecialidadesLogic.Delete(id);
        }
        private void SaveEntity(Especialidad es)
        {
            EspecialidadesLogic.Save(es);
        }
        private void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
        }
        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
        }
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    break;
                case FormModes.Modificacion:
                    Entity = new Especialidad();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Especialidad();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/Especialidades.aspx");
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Especialidades.aspx");
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
                gvEspecialidades.Enabled = false;
                gridActionsPanel.Visible = false;
            }
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
                gvEspecialidades.Enabled = false;
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
        protected void gvEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gvEspecialidades.SelectedValue;
        }
    }
}