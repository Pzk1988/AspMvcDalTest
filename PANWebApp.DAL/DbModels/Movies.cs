using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PANWebApp.DAL.DbModels
{
    [Table("Movies")]
    internal class Movies : EntityBase
    {
        public Movies()
        {
        }

        public Movies(Guid id) : base(id)
        {
        }

        public Movies(string id) : base(id)
        {
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }
    }
}
