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

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Autor> listadoAutor = (from e in _BibliotecaContexto.Autor select e).ToList();

            if (listadoAutor.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoAutor);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            Autor? Autor = (from e in _BibliotecaContexto.Autor where e.Id == id select new Autor
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Nacionalidad = e.Nacionalidad,
                Libro = _BibliotecaContexto.Libro
                            .Where(l => l.AutorId == e.Id)
                            .ToList()
            }).FirstOrDefault();

            if (Autor == null)
            {
                return NotFound();
            }

            return Ok(Autor);
        }

        
    }
}
