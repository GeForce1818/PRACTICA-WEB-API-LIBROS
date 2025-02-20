using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRACTICA_WEB_API_LIBROS.Models;
using Microsoft.EntityFrameworkCore;



namespace PRACTICA_WEB_API_LIBROS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly BibliotecaContext _BibliotecaContexto;

        public LibroController(BibliotecaContext BibliotecaContexto)
        {
            _BibliotecaContexto = BibliotecaContexto;
        }

    }
}
