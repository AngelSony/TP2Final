using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ReporteDeCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoPersona"] == null)
            {
                Response.Redirect("~/AdvertenciaLogin.aspx");
            }
            else if ((int)Session["TipoPersona"] == (int)Personas.TiposPersonas.Alumno)
            {
                Response.Redirect("~/AdvertenciaAccesoUsuario.aspx");
            }
        }
    }
}