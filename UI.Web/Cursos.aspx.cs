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
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                //CargarCombos();
            }
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
        private void CargarCombos()
        {
            throw new NotImplementedException();
        }

        private void LoadGrid()
        {
            gvCursos.DataSource = CursoLogic.GetAll();
            gvCursos.DataBind();
        }

        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gvCursos.SelectedValue;
        }
    }
}