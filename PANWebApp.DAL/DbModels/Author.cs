using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PANWebApp.DAL.DbModels
{
    [Table("Authors")]
    internal class Author : EntityBase
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public Author(Guid id) : base(id)
        {
            Books = new List<Book>();
        }

        public Author(string id) : base(id)
        {
            Books = new List<Book>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string Image { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
