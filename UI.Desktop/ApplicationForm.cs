using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form
    {
        public ModoForm Modo;
        public ApplicationForm()
        {
            InitializeComponent();
        }
        public enum ModoForm
        {
            Alta,
            Baja,
            Modificacion,
            Consulta
        }
        public virtual void MapearDeDatos() { }
        public virtual void MapearADatos() { }
        public virtual void GuardarCambios() { }
        public virtual bool Validar() { return false; }
        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            Notificar(Text, mensaje, botones, icono);
        }

    }
}
