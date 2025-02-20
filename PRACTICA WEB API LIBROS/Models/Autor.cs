using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRACTICA_WEB_API_LIBROS.Models
{
    public class Autor
    {
        [Key] // Esto indica que es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nacionalidad { get; set; }

        // Relación con los libros
        public List<Libro> Libro { get; set; } = new List<Libro>();
    }


}
