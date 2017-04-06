using System.Collections.Generic;
using WeBStore.Models;

namespace WeBStore.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Formheading { get; set; }
    }
}