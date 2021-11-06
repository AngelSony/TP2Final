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
    public partial class DocenteCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadGrid();
                CargarCombo();

            }
            
        }



        Business.Entities.DocenteCurso _logic;

        private Business.Entities.DocenteCurso Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new Business.Entities.DocenteCurso();
                }
                return _logic;
            }
        }
        private Business.Entities.DocenteCurso Entity
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

        private void LoadGrid()
        {
            grdDocenteCursos.DataSource = DocenteCursoLogic.GetAll();
            grdDocenteCursos.DataBind();
        }

        private void CargarCombo()
        {

            ddlCargo.DataSource = Enum.GetValues(typeof(Business.Entities.DocenteCurso.TiposCargos));
       
            ddlCargo.DataBind();


            ddlDocente.DataSource = PersonasLogic.GetAll().Where(d => d.TipoPersona == Personas.TiposPersonas.Docente).Select(p => new { ID = p.ID, NombreApellido = $"{p.Nombre} {p.Apellido}" }).ToList();
            ddlDocente.DataTextField = "NombreApellido";
            ddlDocente.DataValueField = "ID";
            ddlDocente.DataBind();
            ddlDocente.Items.Insert(0, new ListItem("-- Seleccione --", "0"));

            var CursoMateria = from c in CursoLogic.GetAll()
                               join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                               join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                               select new { c.ID, Descripcion = m.Descripcion + " " + cm.Descripcion + " " + c.AnioCalendario };




            ddlCurso.DataSource = CursoMateria.ToList();
            ddlCurso.DataTextField = "Descripcion";
            ddlCurso.DataValueField = "ID";
            ddlCurso.DataBind();
            ddlCurso.Items.Insert(0, new ListItem("-- Seleccione --", "0"));

        }


        private void LoadForm(int id)
        {
            Entity = DocenteCursoLogic.GetOne(id);
            IDTextBox.Text = Entity.ID.ToString();
            ddlCargo.SelectedValue = Entity.Cargo.ToString();
            ddlCurso.SelectedValue = Entity.IDCurso.ToString();
            ddlDocente.SelectedValue = Entity.IDDocente.ToString();
        }


        private void LoadEntity(Business.Entities.DocenteCurso docenteCurso)
        {
            docenteCurso.Cargo = (Business.Entities.DocenteCurso.TiposCargos)ddlCargo.SelectedIndex ;
            docenteCurso.IDCurso = Convert.ToInt32(ddlCurso.SelectedValue);
            docenteCurso.IDDocente = Convert.ToInt32(ddlDocente.SelectedValue);
        }


        private void DeleteEntity(int id)
        {
            DocenteCursoLogic.Delete(id);
        }

        private void SaveEntity(Business.Entities.DocenteCurso DocenteCurso)
        {
            try
            {
                DocenteCursoLogic.Save(DocenteCurso);
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);

            }

        }

        protected void grdDocenteCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)grdDocenteCursos.SelectedValue;
        }

        private void EnableForm(bool enable)
        {
            IDTextBox.Enabled = enable;
            ddlCargo.Enabled = enable;
            ddlCurso.Enabled = enable;
            ddlDocente.Enabled = enable;
        }

        private void ClearForm()
        {
            ddlCurso.SelectedValue = "0";
            ddlDocente.SelectedValue = "0";
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
                formActionPanel.Visible = true;
                grdDocenteCursos.Enabled = false;
                gridActionPanel.Visible = false;

            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
            formActionPanel.Visible = true;
            gridActionPanel.Visible = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/DocenteCurso.aspx");
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
                grdDocenteCursos.Enabled = false;
                gridActionPanel.Visible = false;

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
                    Entity = new Business.Entities.DocenteCurso();
                    Entity.ID = SelectedID;
                    Entity.State = BusinessEntity.States.Modified;
                    
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                case FormModes.Alta:
                    Entity = new Business.Entities.DocenteCurso();
                    LoadEntity(Entity);
                    try
                    {
                        Entity.State = BusinessEntity.States.New;
                        Validaciones.ValidarDocentes(Entity);
                       

                    }
                    catch (Exception Ex)
                    {
                        System.Windows.Forms.MessageBox.Show(Ex.Message);
                        Entity.State = BusinessEntity.States.Unmodified;
                    }
                    
                    
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }

            Response.Redirect("~/DocenteCurso.aspx");
        }
    }
}