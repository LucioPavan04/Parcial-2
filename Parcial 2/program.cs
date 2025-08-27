namespace GestorBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Libro> libros = new List<Libro>();
            int opcion;

            do
            {
                Console.WriteLine("\n=== GESTOR DE BIBLIOTECA ===");
                Console.WriteLine("1) Registrar un libro");
                Console.WriteLine("2) Registrar un préstamo");
                Console.WriteLine("3) Mostrar información de un libro");
                Console.WriteLine("4) Mostrar todos los libros y estadísticas");
                Console.WriteLine("5) Salir");
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                if (opcion == 1) RegistrarLibro(libros);
                else if (opcion == 2) RegistrarPrestamo(libros);
                else if (opcion == 3) MostrarLibro(libros);
                else if (opcion == 4) MostrarTodos(libros);
            } while (opcion != 5);
        }

        static void RegistrarLibro(List<Libro> libros)
        {
            Console.WriteLine("1) Físico  2) Digital");
            int tipo = int.Parse(Console.ReadLine());

            string isbn;
            do
            {
                Console.Write("ISBN: "); isbn = Console.ReadLine();
            } while (libros.Exists(l => l.ISBN == isbn));

            Console.Write("Título: "); string titulo = Console.ReadLine();
            Console.Write("Autor: "); string autor = Console.ReadLine();

            if (tipo == 1) libros.Add(new LibroFisico(isbn, titulo, autor));
            else if (tipo == 2) libros.Add(new LibroDigital(isbn, titulo, autor));
        }

        static void RegistrarPrestamo(List<Libro> libros)
        {
            Console.Write("ISBN: ");
            var libro = libros.Find(l => l.ISBN == Console.ReadLine());
            if (libro == null) 
            { 
                Console.WriteLine("No existe."); return; 
            }
            if (!libro.EstaDisponible()) 
            { 
                Console.WriteLine("No disponible."); return; 
            }

            Console.Write("Socio: "); string socio = Console.ReadLine();
            Console.Write("Duración días: "); int dias = int.Parse(Console.ReadLine());

            libro.AgregarPrestamo(new Prestamo(socio, dias));
            Console.WriteLine("Préstamo registrado.");
        }

        static void MostrarLibro(List<Libro> libros)
        {
            Console.Write("ISBN: ");
            var libro = libros.Find(l => l.ISBN == Console.ReadLine());
            if (libro == null) 
            {
                Console.WriteLine("No existe."); return; 
            }

            Console.WriteLine($"\nTítulo: {libro.Titulo}\nAutor: {libro.Autor}\nISBN: {libro.ISBN}");
            Console.WriteLine($"Préstamos: {libro.CantidadPrestamos()}");
            Console.WriteLine($"Disponible: {(libro.EstaDisponible() ? "Sí" : "No")}");
        }

        static void MostrarTodos(List<Libro> libros)
        {
            int fisicos = 0, digitales = 0, prestamos = 0;
            foreach (var l in libros)
            {
                Console.WriteLine($"\n[{l.GetType().Name}] {l.Titulo} - {l.Autor} ({l.ISBN})");
                prestamos += l.CantidadPrestamos();
                if (l is LibroFisico) fisicos++; else digitales++;
            }
            Console.WriteLine($"\nTotal préstamos: {prestamos}");
            Console.WriteLine($"Libros físicos: {fisicos}, digitales: {digitales}");
        }
    }
}
