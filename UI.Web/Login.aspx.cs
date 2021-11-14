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
        Personas personas;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Clave = txtClave.Text;

            if (Validaciones.EsUsuarioValido(usuario))
            {

                usuario = UsuarioLogic.GetUsuarioPorNombre(usuario);
                personas = PersonasLogic.GetOne(usuario.IDPersona);
                Session ["Persona"] = personas;
                Session["TipoPersona"] = PersonasLogic.GetOne(usuario.IDPersona).TipoPersona;
                
                lblMensaje.Text = "Bienvenido al sistema Academia: " + PersonasLogic.GetOne(usuario.IDPersona).Nombre +" "+ PersonasLogic.GetOne(usuario.IDPersona).Apellido +" Usted ingreso al sistema como: " + PersonasLogic.GetOne(usuario.IDPersona).TipoPersona;
                lblMensaje.Visible = true;

                Response.Redirect("~/Login.aspx");

            }
            else
            {
                lblMensaje.Text = "Usuario y/o Contraseña Inválida";
                lblMensaje.Visible = true;
                txtClave.Text = "";
                txtUsuario.Text = "";
            }
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

       
    }
}