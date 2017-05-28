using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PANWebApp.DAL.DbModels;

namespace PANWebApp.DAL.Migrations
{
    class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibraryContext context)
        {
            Author umbertoEco =
                new Author("{34E95A2E-F247-444F-89DA-02E17E448C53}") { FirstName = "Umberto", LastName = "Eco", Image = "" };

            Author marioPuzo =
                new Author("{32EF4124-5584-4158-B9BD-B6E4AB0E3C90}") { FirstName = "Mario", LastName = "Puzo", Image = "" };

            Book rose = new Book("{FA09DE7A-0EE1-49A7-A150-F3AFF0D45B4F}")
            {
                Authors = new List<Author> { umbertoEco },
                Title = "Imię róży",
                Year = 1980
            };

            Book baudolino = new Book("{AE6DC65F-6335-432A-BA15-CB2E03DDFF1A}")
            {
                Authors = new List<Author> { umbertoEco },
                Title = "Baudolino",
                Year = 2000
            };

            Book godfather = new Book("{8A15118A-EB30-421B-8A08-7F4324B52EFD}")
            {
                Authors = new List<Author> { marioPuzo },
                Title = "Ojciec chrzestny",
                Year = 1969
            };

            Movies manOnFire = new Movies("8A15118A-EB30-4213-5A08-7F4324B52EFD") {Title = "Man on fire", Year = 2010, Director = "Jakis tam" };

            context.Authors.AddOrUpdate(_ => _.Id, umbertoEco, marioPuzo);

            context.Books.AddOrUpdate(_ => _.Id, rose, baudolino, godfather);

            context.Movies.AddOrUpdate(_ => _.Id, manOnFire);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
