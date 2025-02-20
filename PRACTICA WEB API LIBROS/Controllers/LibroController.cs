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

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Libro> listadoLibro = (from e in _BibliotecaContexto.Libro select e).ToList();
            
            if(listadoLibro.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoLibro);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            Libro? Libro = (from e in _BibliotecaContexto.Libro where e.Id == id select e).FirstOrDefault();

            if (Libro == null)
            {
                return NotFound();
            }

            return Ok(Libro);
        }


    }
}
