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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }
        private Usuario Entity
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
            Entity = Logic.GetOne(id);
            nombreTextBox.Text = Entity.Nombre;
            apellidoTextBox.Text = Entity.Apellido;
            emailTextBox.Text = Entity.EMail;
            habilitadoCheckBox.Checked = Entity.Habilitado;
            nombreUsuarioTextBox.Text = Entity.NombreUsuario;
        }
        private void LoadGrid()
        {
            gridView.DataSource = Logic.GetAll();
            gridView.DataBind();
        }
        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = nombreTextBox.Text;
            usuario.Apellido = apellidoTextBox.Text;
            usuario.EMail = emailTextBox.Text;
            usuario.NombreUsuario = nombreUsuarioTextBox.Text;
            usuario.Clave = claveTextBox.Text;
            usuario.Habilitado = habilitadoCheckBox.Checked;
        }
        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }
        private void SaveEntity(Usuario usuario)
        {
            Logic.Save(usuario);
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
                EnableForm(true);
            }
        }
        private void EnableForm(bool enable)
        {
            nombreTextBox.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;
            nombreUsuarioTextBox.Enabled = enable;
            claveTextBox.Visible = enable;
            claveLabel.Visible = enable;
            repetirClaveTextBox.Visible = enable;
            repetirClaveLabel.Visible = enable;
        }
        private void ClearForm()
        {
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            habilitadoCheckBox.Checked = false;
            nombreUsuarioTextBox.Text = string.Empty;
        }
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    break;
                case FormModes.Modificacion:
                    Entity = new Usuario();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Usuario();
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }

            LoadGrid();
            formPanel.Visible = false;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }
    }
}