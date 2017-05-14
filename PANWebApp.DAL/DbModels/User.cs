using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PANWebApp.DAL.DbModels
{
    [Table("Users")]
    public class User : EntityBase
    {
        public User()
        {
        }

        public User(Guid id) : base(id)
        {
        }

        public User(string id) : base(id)
        {
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
