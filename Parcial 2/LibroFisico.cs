namespace GestorBiblioteca
{
    class LibroFisico : Libro
    {
        private bool prestado = false;

        public LibroFisico(string isbn, string titulo, string autor) : base(isbn, titulo, autor) { }

        public override bool EstaDisponible() => !prestado;

        public override void AgregarPrestamo(Prestamo p)
        {
            base.AgregarPrestamo(p);
            prestado = true;
        }
    }
}
