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
    public partial class formPersonas : Form
    {
        private Personas.TiposPersonas tipoPersona;
        public formPersonas(Personas.TiposPersonas tipo)
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
            tipoPersona = tipo;
            Text = tipoPersona.ToString();
        }
        public void Listar()
        {
            var PersonasUsuarios = from p in PersonasLogic.GetAll()
                                   join u in new UsuarioLogic().GetAll() on p.ID equals u.IDPersona
                                   where p.TipoPersona.Equals(tipoPersona) 
                                   select new { IDUsuario = u.ID, NombreUsuario = u.NombreUsuario, Clave = u.Clave, Habilitado = u.Habilitado, TipoPersona = p.TipoPersona};

            dgvPersonas.DataSource = PersonasUsuarios.ToList();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void fromPersonas_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Abrir PersonasDesktop
        }
    }
}
