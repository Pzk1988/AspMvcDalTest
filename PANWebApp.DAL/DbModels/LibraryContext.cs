using PANWebApp.DAL.Migrations;

namespace PANWebApp.DAL.DbModels
{
    using System.Data.Entity;

    internal class LibraryContext : DbContext
    {
        // Your context has been configured to use a 'LibraryContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PANWebApp.DAL.DbModels.LibraryContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LibraryContext' 
        // connection string in the application configuration file.
        public LibraryContext()
            : base("name=LibraryContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryContext,Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Author> Authors{ get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Movies>().ToTable("Movies");

            modelBuilder.Entity<Book>().Property(_ => _.Cover).HasColumnType("image");

            
            
            modelBuilder.Entity<Book>().HasMany(_ => _.Authors).WithMany(_ => _.Books).Map(_ =>
            {
                _.MapLeftKey("BookId");
                _.MapRightKey("AuthorId");
                _.ToTable("BooksAuthors");
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}