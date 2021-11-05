namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private TiposCargos _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        public TiposCargos Cargo { get => _Cargo; set => _Cargo = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
        public int IDDocente { get => _IDDocente; set => _IDDocente = value; }
        public string NombreApellidoDocente { get; set; }
        public string Curso { get; set; }

        public  enum TiposCargos
        {
            Titular,
            JTP,
            AuxiliarPrimera
        }
    }
}
