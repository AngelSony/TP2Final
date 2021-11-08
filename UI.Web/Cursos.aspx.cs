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
    public partial class Cursos : System.Web.UI.Page
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
                CargarCombos();
            }
        }
        private Curso Entity
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
        private void CargarCombos()
        {
            ddComision.DataSource = ComisionesLogic.GetAll();
            ddComision.DataTextField = "Descripcion";
            ddComision.DataValueField = "ID";
            ddComision.DataBind();
            ddComision.Items.Insert(0, new ListItem("-- Seleccione --", "0"));

            ddMateria.DataSource = MateriaLogic.GetAll();
            ddMateria.DataTextField = "Descripcion";
            ddMateria.DataValueField = "ID";
            ddMateria.DataBind();
            ddMateria.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private void LoadGrid()
        {
            gvCursos.DataSource = CursoLogic.GetAll();
            gvCursos.DataBind();
        }
        private void LoadForm(int id)
        {
            Entity = CursoLogic.GetOne(id);
            ddComision.SelectedValue = Entity.IDComision.ToString();
            ddMateria.SelectedValue = Entity.IDMateria.ToString();
            anioCalendarioTextBox.Text = Entity.AnioCalendario.ToString();
            cupoTextBox.Text = Entity.Cupo.ToString();
        }
        private void LoadEntity(Curso cur)
        {
            cur.IDComision = Convert.ToInt32(ddComision.SelectedValue);
            cur.IDMateria = Convert.ToInt32(ddMateria.SelectedValue);
            cur.AnioCalendario = Convert.ToInt32(anioCalendarioTextBox.Text);
            cur.Cupo = Convert.ToInt32(cupoTextBox.Text);
        }
        private void DeleteEntity(int id)
        {
            CursoLogic.Delete(id);
        }
        private void SaveEntity(Curso cur)
        {
            CursoLogic.Save(cur);
        }
        private void EnableForm(bool enable)
        {
            ddComision.Enabled = enable;
            ddMateria.Enabled = enable;
            anioCalendarioTextBox.Enabled = enable;
            cupoTextBox.Enabled = enable;
        }
        private void ClearForm()
        {
            ddComision.SelectedValue = "0";
            ddMateria.SelectedValue = "0";
            anioCalendarioTextBox.Text = string.Empty;
            cupoTextBox.Text = string.Empty;
        }
        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gvCursos.SelectedValue;
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
                gvCursos.Enabled = false;
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
                    Entity = new Curso();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Curso();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/Cursos.aspx");
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
                gvCursos.Enabled = false;
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
            Response.Redirect("~/Cursos.aspx");
        }
    }
}