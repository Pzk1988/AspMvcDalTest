﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PANWebApp.DAL.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public bool Lent { get; set; }
        public byte[] Cover { get; set; }
        public AuthorDTO[] Authors { get; set; }
    }
}
