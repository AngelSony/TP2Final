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
    public partial class ReportesCursosForm : Form
    {
        public ReportesCursosForm()
        {
            InitializeComponent();
        }

        private void ReportesCursosForm_Load(object sender, EventArgs e)
        {
            try { 
                var listado = from cur in CursoLogic.GetAll()
                              join mat in MateriaLogic.GetAll() on cur.IDMateria equals mat.ID
                              join comi in ComisionesLogic.GetAll() on cur.IDComision equals comi.ID
                              orderby cur.AnioCalendario descending
                              select new { cur.ID, cur.AnioCalendario, IDComision = comi.Descripcion , IDMateria = mat.Descripcion};

                CursoBindingSource.DataSource = listado.ToList();

                rpwCursos.RefreshReport();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
