using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeBStore.Models;

namespace WeBStore.ViewModel
{
    public class MovieFormViewModel
    {
        //This is Called Purely View Model
        public IEnumerable<Genre> Genres { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        public byte? GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Range(1, 20)]
        public byte? NumberInStock { get; set; }


        public string Formheading
        {
            get
            {
                return (Id == 0) ? "New Movie" : "Edit Movie";
            }

        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    }
}