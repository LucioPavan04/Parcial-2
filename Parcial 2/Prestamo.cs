namespace GestorBiblioteca
{
    class Prestamo
    {
        public string Socio { get; }
        public int Dias { get; }
        public DateTime Fecha { get; }

        public Prestamo(string socio, int dias)
        {
            Socio = socio;
            Dias = dias;
            Fecha = DateTime.Now;
        }
    }
}
