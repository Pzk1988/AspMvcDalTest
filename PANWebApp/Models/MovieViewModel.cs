using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PANWebApp.Models
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
    }
}