using APIRestNetFramework.Models;
using APIRestNetFramework.Swagger;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace APIRestNetFramework.Controllers
{
    public class BookController : ApiController
    {
        List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Name = "Elantris", Category = "Fantasía", Price = 15 },
            new Book { Id = 2, Name = "La iglesia", Category = "Terror", Price = 10 },
            new Book { Id = 3, Name = "Nigromante", Category = "Fantasía", Price = 20 }
        };

        /// <summary>
        /// Obtención de los libros de la biblioteca
        /// </summary>
        /// <returns>Listado de libros</returns>
        [SwaggerResponse(HttpStatusCode.OK, "Obtención correcta de los libros", Type = typeof(List<Book>))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(BooksExample))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(books);
        }

        /// <summary>
        /// Obtención de un libro concreto
        /// </summary>
        /// <param name="id">Identificador del libro que queremos obtener</param>
        /// <returns>Libro que coincide con la busqueda</returns>
        [SwaggerResponse(HttpStatusCode.OK, "Obtención correcta de un libro", Type = typeof(Book))]
        [SwaggerResponse(HttpStatusCode.NotFound, "Libro no encontrado")]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(BookExample))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Creación de un nuevo libro, lo añade a la biblioteca
        /// </summary>
        /// <param name="bookModel">Datos del libro a crear</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "Creación correcta de un libro")]
        [SwaggerRequestExample(typeof(Book), typeof(BookExample))]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Book bookModel)
        {
            books.Add(bookModel);

            return Ok();
        }

        /// <summary>
        /// Actualización de un libro de la biblioteca
        /// </summary>
        /// <param name="id">Identificador del libro que queremos modificar</param>
        /// <param name="bookModel">Datos del libro a modificar</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "Actualización correcta de un libro")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Parametros de entrada incorrectos")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Libro no encontrado")]
        [SwaggerRequestExample(typeof(Book), typeof(BookExample))]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Book bookModel)
        {
            if (id != bookModel.Id)
            {
                return BadRequest();
            }

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Borrado de un libro de la biblioteca
        /// </summary>
        /// <param name="id">Identificador del libro a borrar</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "Borrado correcto de un libro")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Libro no encontrado")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book is null)
            {
                return NotFound();
            }

            books.Remove(book);

            return Ok();
        }
    }
}
