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
        [Route("GetByIdAutor/{id}")]
        public IActionResult GetAutor(int id)
        {
            var autorConLibros = (from a in _BibliotecaContexto.Autor
                                  where a.Id == id
                                  select new
                                  {
                                      a.Id,
                                      a.Nombre,
                                      a.Nacionalidad,
                                      Libros = (from l in _BibliotecaContexto.Libro
                                                where l.AutorId == a.Id
                                                select new
                                                {
                                                    l.AutorId,
                                                    l.Titulo,
                                                    l.AñoPublicación,
                                                    l.Resumen
                                                }).ToList()
                                  }).FirstOrDefault();

            if (autorConLibros == null)
            {
                return NotFound();
            }

            return Ok(autorConLibros);
        }



        [HttpPost]
        [Route("AddAutor")]
        public IActionResult GuardarAutor([FromBody] Autor Autor)
        {

            try
            {
                _BibliotecaContexto.Add(Autor);
                _BibliotecaContexto.SaveChanges();
                return Ok(Autor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
