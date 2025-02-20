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

            if (listadoLibro.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoLibro);
        }

        [HttpGet]
        [Route("GetAllLibros")]
        public IActionResult GetLibros()
        {
            var listadoLibro = (from e in _BibliotecaContexto.Libro
                                join t in _BibliotecaContexto.Autor
                                          on e.AutorId equals t.Id
                                select new
                                {
                                    e.Id,
                                    e.Titulo,
                                    e.AñoPublicación,
                                    e.AutorId,
                                    Nombre_Autor = t.Nombre,
                                    e.CategoriaId,
                                    e.Resumen,
                                }).OrderBy(resultado => resultado.Id)
                                    .ThenBy(resultado => resultado.AutorId).ToList();

            if (listadoLibro.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoLibro);
        }


        [HttpPost]
        [Route("Add")]
        public ActionResult GuardarLibro([FromBody] Libro libro)
        {
            try
            {
                _BibliotecaContexto.Libro.Add(libro);
                _BibliotecaContexto.SaveChanges();
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
