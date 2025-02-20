using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRACTICA_WEB_API_LIBROS.Models
{
    public class Libro
    {
        [Key] // Esto indica que es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AñoPublicación { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
        public string Resumen { get; set; }

        // Relación con Autor
        public Autor Autor { get; set; }
    }
}
