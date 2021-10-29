using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnosDesktop : ApplicationForm
    {


        public Personas AlumnoActual;
        public AlumnosDesktop()
        {
            InitializeComponent();
        }
        public AlumnosDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ModoBoton();
        }

        public AlumnosDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonasLogic PersonasLogic = new PersonasLogic();
            AlumnoActual = PersonasLogic.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            txtID.Text = AlumnoActual.ID.ToString();
            txtApellido.Text = AlumnoActual.Apellido;
            txtNombre.Text = AlumnoActual.Nombre;
            txtDireccion.Text = AlumnoActual.Direccion;
            txtEmail.Text = AlumnoActual.Email;
            txtTelefono.Text = AlumnoActual.Telefono;
            txtLegajo.Text = AlumnoActual.Legajo.ToString();
            txtFechaDeNacimiento.Text = AlumnoActual.FechaNacimiento.ToString();
            txtPlan.Text = AlumnoActual.IDPlan.ToString();
            txtDireccion.Text = AlumnoActual.Direccion;
            ModoBoton();

        }

        public override void MapearADatos()
        {
           if(Modo == ModoForm.Alta)
            {

                AlumnoActual = new Personas();

            }

           if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)


            {

                
                AlumnoActual.Apellido = txtApellido.Text.Trim();
                AlumnoActual.Nombre = txtNombre.Text.Trim();
                AlumnoActual.Legajo = Convert.ToInt32(txtLegajo.Text);
                AlumnoActual.Direccion = txtDireccion.Text;
                AlumnoActual.Email = txtTelefono.Text;
                AlumnoActual.Telefono = txtEmail.Text;
                AlumnoActual.TipoPersona = Personas.TiposPersonas.Alumno;
                AlumnoActual.FechaNacimiento = DateTime.Parse(txtFechaDeNacimiento.Text);
                AlumnoActual.IDPlan = Convert.ToInt32(txtPlan.Text); //MODIFICAR CUANDO ESTE LA CAPA DE PLAN 
               
            }

           switch(Modo)
            {
                case ModoForm.Alta:
                    AlumnoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Baja:
                    AlumnoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    AlumnoActual.State = BusinessEntity.States.Unmodified;
                    break;
                case ModoForm.Modificacion:
                    AlumnoActual.State = BusinessEntity.States.Modified;
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

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonasLogic PersonaNegocio = new PersonasLogic();
            PersonaNegocio.Save(AlumnoActual);

            if(Modo == ModoForm.Alta)
            {
                MessageBox.Show("Alumno Agregado con Éxito");

            }
            if(Modo == ModoForm.Modificacion)
            {
                MessageBox.Show("Alumno Modificado con Éxito");
            }
            
        }


        public override bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Notificar("Advertencia", "Campo Nombre incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                Notificar("Advertencia", "Campo Apellido incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           
            else if (string.IsNullOrWhiteSpace(txtLegajo.Text))
            {
                Notificar("Advertencia", "Campo Legajo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                Notificar("Advertencia", "Campo Telefono incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                Notificar("Advertencia", "Campo Direccion incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrWhiteSpace(txtPlan.Text)) //MODIFICAR
            {
                Notificar("Advertencia", "Campo Plan incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (!Business.Logic.Validaciones.EsMailValido(txtEmail.Text))
            {
                Notificar("Advertencia", "Email no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else if (!Business.Logic.Validaciones.EsFechaValida(txtFechaDeNacimiento.Text))
            {
                Notificar("Advertencia", "El formato de la fecha debe ser dd/MM/aaaa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }




            else { return true; }
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            else if (Validar())

            {
                GuardarCambios();
                Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
