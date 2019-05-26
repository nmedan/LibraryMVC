namespace MyLibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyLibrary.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MyLibrary.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyLibrary.Models.LibraryContext context)
        {
            context.Authors.AddOrUpdate(x => x.Id,
                new Author() { Id = 1, FirstName = "Petar", LastName = "Petrovic" },
                new Author() { Id = 2, FirstName = "Marko", LastName = "Markovic" },
                new Author() { Id = 3, FirstName = "Jovan", LastName = "Jovanovic" }
            );

            context.Genres.AddOrUpdate(x => x.Id,
                new Genre() { Id = 1, Name = "Avanturisticki" },
                new Genre() { Id = 2, Name = "Fantastika" },
                new Genre() { Id = 3, Name = "Drama"}
            );

            context.Books.AddOrUpdate(x => x.Id,
                new Book() { Id = 1, Title = "Book1", ISBN = "3345678921112", PublishingYear = 2013, AuthorId = 1, GenreId = 1 },
                new Book() { Id = 2, Title = "Book2", ISBN = "4345678923112", PublishingYear = 2014, AuthorId = 2, GenreId = 2 },
                new Book() { Id = 3, Title = "Book3", ISBN = "5345778922112", PublishingYear = 2015, AuthorId = 3, GenreId = 3 },
                new Book() { Id = 4, Title = "Book4", ISBN = "3345678921115", PublishingYear = 2011, AuthorId = 1, GenreId = 3 },
                new Book() { Id = 5, Title = "Book5", ISBN = "4345678923116", PublishingYear = 2008, AuthorId = 2, GenreId = 2 },
                new Book() { Id = 6, Title = "Book6", ISBN = "5345778922117", PublishingYear = 2012, AuthorId = 3, GenreId = 1 }
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
