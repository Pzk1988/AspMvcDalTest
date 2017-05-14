using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PANWebApp.DAL.DbModels
{
    [Table("Books")]
    internal class Book : EntityBase
    {
        public Book()
        {
            Authors = new List<Author>();
        }

        public Book(Guid id) : base(id)
        {
            Authors = new List<Author>();
        }

        public Book(string id) : base(id)
        {
            Authors = new List<Author>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }
        public int Pages { get; set; }
        public bool Lent { get; set; }
        public byte[] Cover { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
