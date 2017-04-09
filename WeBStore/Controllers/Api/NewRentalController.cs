using System;
using System.Linq;
using System.Web.Http;
using WeBStore.Dto;
using WeBStore.Models;

namespace WeBStore.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No Movies Choosen");
            }
            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerID);

            if (customer == null)
            {
                return BadRequest("Invalid Customer ID");

            }

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
            {
                return BadRequest("One or More Movies are invalid");
            }

            // the EF query is equivalent to 
            // select * From Movies Where Id IN(1,2,3)


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie Not Available");
                }

                movie.NumberAvailable--;

                var RentalObj = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(RentalObj);

            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
