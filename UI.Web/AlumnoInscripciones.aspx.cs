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
    public partial class AlumnoInscripciones : System.Web.UI.Page
    {
        private Personas AlumnoActual
        {
            get
            {
                return (Personas)Session["Persona"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoPersona"] == null)
                {
                    Response.Redirect("~/AdvertenciaLogin.aspx");
                }
                else if ((int)Session["TipoPersona"] != (int)Personas.TiposPersonas.Alumno)
                {
                    Response.Redirect("~/AdvertenciaAccesoUsuario.aspx");
                }
                LoadGrid();
                CargaCombo();
           }
        }



        public void LoadGrid()
        {
            var listado = from alu_ins in AlumnoInscripcionesLogic.GetAll()
                          join cur in CursoLogic.GetAll() on alu_ins.IDCurso equals cur.ID
                          join alu in PersonasLogic.GetAll() on alu_ins.IDAlumno equals alu.ID
                          join mat in MateriaLogic.GetAll() on cur.IDMateria equals mat.ID
                          join comi in ComisionesLogic.GetAll() on cur.IDComision equals comi.ID
                          where alu.ID == AlumnoActual.ID
                          select new { alu_ins.ID, Materia = mat.Descripcion, cur.AnioCalendario, alu_ins.Nota, alu_ins.Condicion, comi.Descripcion };
            grdInscripciones.DataSource = listado.ToList();
            grdInscripciones.DataBind();
        }

        private void CargaCombo()
        {
            var CursoMateria = from c in CursoLogic.GetAll()
                               join m in MateriaLogic.GetAll() on c.IDMateria equals m.ID
                               join cm in ComisionesLogic.GetAll() on c.IDComision equals cm.ID
                               select new { c.ID, Descripcion = " Materia: " + m.Descripcion + " Comision: " + cm.Descripcion + " Año: " + c.AnioCalendario };

            ddlCursos.DataSource = CursoMateria.ToList();
            ddlCursos.DataTextField = "Descripcion";
            ddlCursos.DataValueField = "ID";
            ddlCursos.DataBind();
            ddlCursos.SelectedIndex = -1;
            ddlCursos.Items.Insert(0, new ListItem("-- Seleccione --", "0"));

        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion AluIns = new AlumnoInscripcion();

            AluIns.IDCurso = Convert.ToInt32(ddlCursos.SelectedValue);
            AluIns.IDAlumno = AlumnoActual.ID;
            AluIns.Condicion = "Inscripto";

            if (!Validaciones.ValidarCupo(AluIns.IDCurso))
            {
                lblAdvertencia.Text = "ERROR: No hay más cupos para este Curso";
                lblAdvertencia.Visible = true;
            }
            else
            {
                if (Validaciones.ValidarAlumno(AluIns.IDAlumno, AluIns.IDCurso))
                {
                    AluIns.State = BusinessEntity.States.New;
                    AlumnoInscripcionesLogic.Save(AluIns);
                    Response.Redirect("~/AlumnoInscripciones.aspx");
                }
                else
                {
                    lblAdvertencia.Text = "ERROR: Usted ya está inscripto en el curso";
                    lblAdvertencia.Visible = true;
                }
            }
        }
    }
}