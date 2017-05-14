using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PANWebApp.Models
{
    public class AuthorDetailsViewModel : AuthorViewModel
    {
        public byte[] Image { get; set; }
        public BookViewModel[] Books { get; set; }
    }
}