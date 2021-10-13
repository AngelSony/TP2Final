namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        private string _Descripcion;

        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
