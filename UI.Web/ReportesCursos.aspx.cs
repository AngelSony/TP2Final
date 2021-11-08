using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;

namespace UI.Web
{
    public partial class WebForm1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoPersona"] == null)
            {
                Response.Redirect("~/AdvertenciaLogin.aspx");
            }
            else if ((int)Session["TipoPersona"] != (int)Personas.TiposPersonas.Administrativo)
            {
                Response.Redirect("~/AdvertenciaAccesoUsuario.aspx");
            }
        }
    }
}