using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<ReaderCard> ReaderCards { get; set; }
        public DbSet<Record> Records { get; set; }

        public LibraryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(DataSource.Authors.ToArray());
            modelBuilder.Entity<Reader>().HasData(DataSource.Readers.ToArray());
            modelBuilder.Entity<Book>().HasData(DataSource.Books.ToArray());
            modelBuilder.Entity<AuthorBook>().HasData(DataSource.Authors.SelectMany(author => author.AuthorBooks));
            modelBuilder.Entity<Chapter>().HasData(DataSource.Books.SelectMany(book => book.Chapters));
            modelBuilder.Entity<ReaderCard>().HasData(DataSource.Readers.Select(reader => reader.ReaderCard));
            modelBuilder.Entity<Record>().HasData(DataSource.Readers.SelectMany(reader => reader.Records));
        }
    }
}
