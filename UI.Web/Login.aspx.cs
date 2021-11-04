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
    public partial class Login : System.Web.UI.Page
    {
        Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Clave = txtClave.Text;

            if (Validaciones.EsUsuarioValido(usuario))
            {

                Page.Response.Write("Usuario Valido");
                Session["inputText"] = txtUsuario;
            }
            else
            {

                Page.Response.Write("Usuario Invalido");
                Session["inputText"] = null;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

       
    }
}