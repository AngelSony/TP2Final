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
    public partial class Materias : Page
    {
        protected Materia Entity { get; set; }
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
                CargarCombo();
            }
        }
        private void CargarCombo()
        {
            planesDropDown.DataSource = PlanLogic.GetAll();
            planesDropDown.DataTextField = "Descripcion";
            planesDropDown.DataValueField = "ID";
            planesDropDown.DataBind();
            planesDropDown.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private void LoadGrid()
        {
            var materias = from m in MateriaLogic.GetAll()
                           where m.IDPlan == Convert.ToInt32(planesDropDown.SelectedValue)
                           select m;
            grvMaterias.DataSource = null;
            grvMaterias.DataSource = materias.ToList();
            grvMaterias.DataBind();
            grdActionPanel.Visible = true;
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
        protected void planesDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadForm(int id)
        {
            Entity = MateriaLogic.GetOne(id);
            descripcionTextBox.Text = Entity.Descripcion;
            HSTextBox.Text = Entity.HSSemanales.ToString();
            HTTextBox.Text = Entity.HSTotales.ToString();
        }
        private void LoadEntity(Materia mat)
        {
            mat.Descripcion = descripcionTextBox.Text;
            mat.HSSemanales = Convert.ToInt32(HSTextBox.Text);
            mat.HSTotales = Convert.ToInt32(HTTextBox.Text);
            mat.IDPlan = Convert.ToInt32(planesDropDown.SelectedValue);
        }
        private void DeleteEntity(int id)
        {
            MateriaLogic.Delete(id);
        }
        private void SaveEntity(Materia mat)
        {
            MateriaLogic.Save(mat);
        }
        private void EnableForm(bool enable)
        {
            descripcionTextBox.Enabled = enable;
            HSTextBox.Enabled = enable;
            HTTextBox.Enabled = enable;
        }
        private void ClearForm()
        {
            descripcionTextBox.Text = string.Empty;
            HSTextBox.Text = string.Empty;
            HTTextBox.Text = string.Empty;
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
                planesDropDown.Enabled = false;
                grvMaterias.Enabled = false;
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
                    Entity = new Materia();
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Materia();
                    Entity.ID = SelectedID;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/Materias.aspx");
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
                planesDropDown.Enabled = false;
                grvMaterias.Enabled = false;
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
            planesDropDown.Enabled = false;
            grdActionPanel.Visible = false;
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Materias.aspx");
        }
        protected void grvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)grvMaterias.SelectedValue;
        }
    }
}