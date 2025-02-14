namespace PRACTICA_WEB_API_LIBROS.Models
{
    public class Libro
    {
        public int id_libro { get; set; }
        public string titulo { get; set; }
        public int año_publicacion { get; set; }
        public int autor_id { get; set; }
        public int categoria_id { get; set; }
        public string resumen { get; set; }



    }
}
