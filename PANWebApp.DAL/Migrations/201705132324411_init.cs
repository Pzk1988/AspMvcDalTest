namespace PANWebApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Pages = c.Int(nullable: false),
                        Lent = c.Boolean(nullable: false),
                        Cover = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BooksAuthors",
                c => new
                    {
                        BookId = c.Guid(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.AuthorId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BooksAuthors", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BooksAuthors", "BookId", "dbo.Books");
            DropIndex("dbo.BooksAuthors", new[] { "AuthorId" });
            DropIndex("dbo.BooksAuthors", new[] { "BookId" });
            DropTable("dbo.BooksAuthors");
            DropTable("dbo.Users");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
