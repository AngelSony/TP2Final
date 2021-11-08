using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class ReporteDePlanes : Form
    {
        public ReporteDePlanes()
        {
            InitializeComponent();
        }

        private void ReporteDePlanes_Load(object sender, EventArgs e)
        {
            var listado = from p in PlanLogic.GetAll()
                          join esp in EspecialidadesLogic.GetAll() on p.IDEspecialidad equals esp.ID
               
                          select new { ID = p.ID, Descripcion= p.Descripcion, IDEspecialidad = esp.Descripcion };

            PlanBindingSource.DataSource = listado.ToList();
             
            this.reportViewer1.RefreshReport();
        }
    }
}
