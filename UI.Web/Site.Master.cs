using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void menu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            Menu miMenu = (Menu)sender;
            SiteMapNode mapNode = (SiteMapNode)e.Item.DataItem;

            if(Session["TipoPersona"] == null) 
            {
                string[] titulos = { "Administración", "Cursos", "Reportes"};
                if (titulos.Contains(mapNode.Title))
                {
                    MenuItem itemToRemove = miMenu.FindItem(mapNode.Title);
                    menu.Items.Remove(itemToRemove);
                }
            }
            else
            {
                switch ((Personas.TiposPersonas)Session["TipoPersona"])
                {
                    case Personas.TiposPersonas.Alumno:
                        string[] titulosalumno = { "Administración", "Reportes"};
                        string[] subtitulosalumno = {"Administración de Cursos", "Docentes - Cursos", "Registro de Notas" };
                        if (titulosalumno.Contains(mapNode.Title))
                        {
                            MenuItem itemToRemove = miMenu.FindItem(mapNode.Title);
                            menu.Items.Remove(itemToRemove);
                        }
                        if (subtitulosalumno.Contains(mapNode.Title))
                        {
                            MenuItem itemToRemove = miMenu.FindItem("Cursos/"+mapNode.Title);
                            itemToRemove.Parent.ChildItems.Remove(itemToRemove);
                        }
                        break;
                    case Personas.TiposPersonas.Docente:
                        string[] titulosdocente = { "Administración", "Reportes" };
                        string[] subtitulosdocente = { "Inscripción a Cursos","Administración de Cursos", "Docentes - Cursos"};
                        if (titulosdocente.Contains(mapNode.Title))
                        {
                            MenuItem itemToRemove = miMenu.FindItem(mapNode.Title);
                            menu.Items.Remove(itemToRemove);
                        }
                        if (subtitulosdocente.Contains(mapNode.Title))
                        {
                            MenuItem itemToRemove = miMenu.FindItem("Cursos/" + mapNode.Title);
                            itemToRemove.Parent.ChildItems.Remove(itemToRemove);
                        }
                        break;
                    case Personas.TiposPersonas.Administrativo:
                        if (mapNode.Title == "Inscripción a Cursos")
                        {
                            MenuItem itemToRemove = miMenu.FindItem("Cursos/" + mapNode.Title);
                            itemToRemove.Parent.ChildItems.Remove(itemToRemove);
                        }
                        break;
                    default:
                        break;
                }
            }

            
        }
    }
}