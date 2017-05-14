using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PANWebApp.Models
{
    public class BookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}