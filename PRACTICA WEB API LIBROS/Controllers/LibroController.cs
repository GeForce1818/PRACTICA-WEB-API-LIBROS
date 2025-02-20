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
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            Libro? Libro = (from e in _BibliotecaContexto.Libro
                            where e.Id == id
                            select new Libro
                            {
                                Id = e.Id,
                                Titulo = e.Titulo,
                                AñoPublicación = e.AñoPublicación,
                                AutorId = e.AutorId,
                                CategoriaId = e.CategoriaId,
                                Resumen = e.Resumen,
                                Autor = _BibliotecaContexto.Autor
                                .FirstOrDefault(a => a.Id == e.AutorId) // Obtener el autor directamente
                            }).FirstOrDefault();

            if (Libro == null)
            {
                return NotFound();
            }

            return Ok(Libro);
        }

        /* ESTO SE DEBE EDITAR
        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarLibro([FromBody] Libro Libro)
        {
            try
            {
                _BibliotecaContexto.Libro.Add(Libro);
                _BibliotecaContexto.SaveChanges();
                return Ok(Libro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/



    }
}
