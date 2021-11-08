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
    public partial class RegistroNota : System.Web.UI.Page
    {
        private Personas personaActual
        {
            get
            {
                return (Personas)Session["Persona"];
            }
        }
        protected AlumnoInscripcion Entity { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoPersona"] == null)
                {
                    Response.Redirect("~/AdvertenciaLogin.aspx");
                }
                else if ((Personas.TiposPersonas)Session["TipoPersona"] == Personas.TiposPersonas.Alumno)
                {
                    Response.Redirect("~/AdvertenciaAccesoUsuario.aspx");
                }
                CargarCombo();
            }
        }
        public void CargarCombo()
        {
            switch (personaActual.TipoPersona)
            {
                case Personas.TiposPersonas.Docente:
                    var cursos = from c in CursoLogic.GetAll()
                                 join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                                 join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                                 join dc in DocenteCursoLogic.GetAll() on c.ID equals dc.IDCurso
                                 where dc.IDDocente.Equals(personaActual.ID)
                                 select new { ID = c.ID, Descripcion = m.Descripcion + " " + cm.Descripcion + " " + c.AnioCalendario };
                    cursosDropDown.DataSource = cursos.ToList();
                    elmininarLinkButton.Enabled = false;
                    break;
                case Personas.TiposPersonas.Administrativo:
                    var todoscursos = from c in CursoLogic.GetAll()
                                      join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                                      join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                                      select new { ID = c.ID, Descripcion = m.Descripcion + " " + cm.Descripcion + " " + c.AnioCalendario };
                    cursosDropDown.DataSource = todoscursos.ToList();
                    break;
                default:
                    break;
            }
            cursosDropDown.DataTextField = "Descripcion";
            cursosDropDown.DataValueField = "ID";
            cursosDropDown.DataBind();
            cursosDropDown.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private void LoadGrid()
        {
            var inscripciones = from i in AlumnoInscripcionesLogic.GetAll()
                                join a in PersonasLogic.GetAll() on i.IDAlumno equals a.ID
                                where i.IDCurso == Convert.ToInt32(cursosDropDown.SelectedValue)
                                select new { i.ID, Alumno = a.Apellido + " " + a.Nombre, i.Condicion, i.Nota };
            grvNotas.DataSource = null;
            grvNotas.DataSource = inscripciones.ToList();
            grvNotas.DataBind();
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
        private void LoadForm(int id)
        {
            Entity = AlumnoInscripcionesLogic.GetOne(id);
            Personas alu = PersonasLogic.GetOne(Entity.IDAlumno);
            alumnoTextBox.Text = alu.Apellido + " " + alu.Nombre;
            condicionTextBox.Text = Entity.Condicion;
            notaTextBox.Text = Entity.Nota.ToString();
        }
        private void LoadEntity(AlumnoInscripcion ins)
        {
            ins.Nota = Convert.ToInt32(notaTextBox.Text);
            ins.Condicion = condicionTextBox.Text;
        }
        private void DeleteEntity(int id)
        {
            AlumnoInscripcionesLogic.Delete(id);
        }
        private void SaveEntity(AlumnoInscripcion ins)
        {
            AlumnoInscripcionesLogic.Save(ins);
        }
        private void EnableForm(bool enable)
        {
            notaTextBox.Enabled = enable;
            condicionTextBox.Enabled = enable;
        }
        protected void cursosDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    break;
                case FormModes.Modificacion:
                    Entity = AlumnoInscripcionesLogic.GetOne(SelectedID);
                    Entity.State = BusinessEntity.States.Modified;
                    LoadEntity(Entity);
                    SaveEntity(Entity);
                    break;
                default:
                    break;
            }
            Response.Redirect("~/RegistroNota.aspx");
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
                cursosDropDown.Enabled = false;
                grvNotas.Enabled = false;
                grdActionPanel.Visible = false;
            }
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistroNota.aspx");
        }
        protected void grvNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)grvNotas.SelectedValue;
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
                cursosDropDown.Enabled = false;
                grvNotas.Enabled = false;
                grdActionPanel.Visible = false;
            }
        }
    }
}