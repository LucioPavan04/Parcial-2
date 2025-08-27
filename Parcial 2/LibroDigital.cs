namespace GestorBiblioteca
{
    class LibroDigital : Libro
    {
        public LibroDigital(string isbn, string titulo, string autor) : base(isbn, titulo, autor) { }

        public override bool EstaDisponible() => true;
    }
}

