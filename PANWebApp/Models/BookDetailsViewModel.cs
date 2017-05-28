using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PANWebApp.Models
{
    public class BookDetailsViewModel : BookViewModel
    {
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public bool Lent { get; set; }
        public byte[] Cover { get; set; }
    }
}