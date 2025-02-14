using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

}namespace PRACTICA_WEB_API_LIBROS.Models
{
    public class BibliotecaContext : DbContext

    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext>option) : base(option) 
        
        {
        
        }  

    }
}
