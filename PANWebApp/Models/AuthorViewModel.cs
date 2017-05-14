using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PANWebApp.Models
{
    public class AuthorViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}