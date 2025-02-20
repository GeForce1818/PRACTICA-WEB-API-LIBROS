using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRACTICA_WEB_API_LIBROS.Models;
using Microsoft.EntityFrameworkCore;

namespace PRACTICA_WEB_API_LIBROS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BibliotecaContext _BibliotecaContexto;

        public AutorController(BibliotecaContext BibliotecaContexto)
        {
            _BibliotecaContexto = BibliotecaContexto;
        }
    }
}
