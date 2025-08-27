namespace GestorBiblioteca
{
    abstract class Libro
    {
        public string ISBN { get; }
        public string Titulo { get; }
        public string Autor { get; }
        protected List<Prestamo> prestamos = new List<Prestamo>();

        public Libro(string isbn, string titulo, string autor)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
        }

        public virtual void AgregarPrestamo(Prestamo p) => prestamos.Add(p);
        public int CantidadPrestamos() => prestamos.Count;
        public abstract bool EstaDisponible();
    }
}