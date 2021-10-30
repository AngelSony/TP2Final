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
    public partial class CursosDesktop : ApplicationForm
    {
        public Curso CursoActual;
        public CursosDesktop()
        {
            InitializeComponent();
            CargaCombos();
        }

        
        public CursosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }
        public CursosDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoActual = CursoLogic.GetOne(ID);
            MapearADatos();
        }
        public override void MapearADatos()
        {
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoActual.IDMateria = Convert.ToInt32(cbMateria.SelectedValue);
                CursoActual.IDComision = Convert.ToInt32(cbComision.SelectedValue);
                CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);
                CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                default:
                    break;
            }
        }
        private void ModoBoton()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
                default:
                    break;

            }
        }
        private void CargaCombos()
        {

        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
