using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PRACTICA_WEB_API_LIBROS.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Nacionalidad { get; set; }
    }


}
