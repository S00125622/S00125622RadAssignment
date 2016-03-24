using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using S00125622RadAss2.Models;
using System.Threading.Tasks;

namespace S00125622RadAss2.Controllers
{
    public class MoviesController : ApiController
    {
        private MovieContext db = new MovieContext();

        // GET: api/Movies
        public IEnumerable<MovieDTO> GetMovies()
        {
            var movies = from m in db.Movies
                         select new MovieDTO()
                         {
                             Id = m.Id,
                             Title = m.Title,
                             DirectorName = m.Director.Name
                         };

            return movies;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(MovieDetailDTO))]
        public async Task<IHttpActionResult> GetMovie(int id)
        {
            var movie = await db.Movies.Include(m => m.Director).Select(m =>
            new MovieDetailDTO()
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                DirectorName = m.Director.Name,
                Genre = m.Genre
            }).SingleOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            await db.SaveChangesAsync();

            //Load Directors Name
            db.Entry(movie).Reference(x => x.Director).Load();

            var dto = new MovieDTO()
            {
                Id = movie.Id,
                Title = movie.Title,
                DirectorName = movie.Director.Name
            };

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public async Task<IHttpActionResult> DeleteMovie(int id)
        {
            Movie movie = await db.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.Id == id) > 0;
        }
    }
}