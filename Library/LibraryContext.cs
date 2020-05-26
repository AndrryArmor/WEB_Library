using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // For migrations only
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Library;Integrated Security=True";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            //string connectionString = configuration.GetConnectionString("LibraryDatabase");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    ReaderCard readerCard1 = new ReaderCard
        //    {
        //        Id = 1,
        //        Name = "Василій",
        //        Surname = "Пупкін",
        //        Age = 17,
        //        Email = "pupkin_v@gmail.com",
        //        DateOfRegistration = new DateTime(2018, 10, 2)
        //    };
        //    ReaderCard readerCard2 = new ReaderCard
        //    {
        //        Id = 2,
        //        Name = "Анастасія",
        //        Surname = "Козаченко",
        //        Age = 19,
        //        Email = "koz_a@gmail.com",
        //        DateOfRegistration = new DateTime(2016, 3, 30)
        //    };
        //    ReaderCard readerCard3 = new ReaderCard
        //    {
        //        Id = 3,
        //        Name = "Віталій",
        //        Surname = "Дзюба",
        //        Age = 24,
        //        Email = "vitalii_dziuba@gmail.com",
        //        DateOfRegistration = new DateTime(2019, 4, 13)
        //    };

        //    object reader1 = new { Id = 1, ReaderCardId = 1 };
        //    object reader2 = new { Id = 2, ReaderCardId = 2 };
        //    object reader3 = new { Id = 3, ReaderCardId = 3 };

        //    Book book1 = new Book() { Id = 1, Name = "Том в Гренландії" };
        //    Book book2 = new Book() { Id = 2, Name = "Філософія думок" };
        //    Book book3 = new Book() { Id = 3, Name = "Останній листок" };

        //    object record1 = new
        //    {
        //        Id = 1,
        //        BookId = 3,
        //        DateOfReceiving = new DateTime(2019, 10, 24),
        //        ReaderId = 1
        //    };
        //    object record2 = new
        //    {
        //        Id = 2,
        //        BookId = 1,
        //        DateOfReceiving = new DateTime(2020, 1, 16),
        //        ReaderId = 1
        //    };
        //    object record3 = new
        //    {
        //        Id = 3,
        //        BookId = 2,
        //        DateOfReceiving = new DateTime(2019, 5, 24),
        //        ReaderId = 2
        //    };
        //    object record4 = new
        //    {
        //        Id = 4,
        //        BookId = 3,
        //        DateOfReceiving = new DateTime(2019, 9, 4),
        //        ReaderId = 2
        //    };
        //    object record5 = new
        //    {
        //        Id = 5,
        //        BookId = 1,
        //        DateOfReceiving = new DateTime(2019, 6, 24),
        //        ReaderId = 3
        //    };
        //    //reader1.Records.Add(record1);
        //    //reader1.Records.Add(record2);
        //    //reader2.Records.Add(record3);
        //    //reader2.Records.Add(record4);
        //    //reader3.Records.Add(record5);

        //    object chapter1 = new { Id = 1, Name = "Вступ", BookId = 1 };
        //    object chapter2 = new { Id = 2, Name = "Пригоди тома", BookId = 1 };
        //    object chapter3 = new { Id = 3, Name = "Завершення історії", BookId = 1 };
        //    object chapter4 = new { Id = 4, Name = "Усе починається з думки", BookId = 2 };
        //    object chapter5 = new { Id = 5, Name = "Думай серцем", BookId = 2 };
        //    object chapter6 = new { Id = 6, Name = "Холодна осінь", BookId = 3 };
        //    object chapter7 = new { Id = 7, Name = "Опале листя", BookId = 3 };
        //    //book1.Chapters.Add(chapter1);
        //    //book1.Chapters.Add(chapter2);
        //    //book1.Chapters.Add(chapter3);
        //    //book2.Chapters.Add(chapter4);
        //    //book2.Chapters.Add(chapter5);
        //    //book3.Chapters.Add(chapter6);
        //    //book3.Chapters.Add(chapter7);

        //    Author author1 = new Author() { Id = 1, Name = "Георг", Surname = "Кельвінгтон", BirthDate = new DateTime(1965, 3, 25) };
        //    Author author2 = new Author() { Id = 2, Name = "Фрідріх", Surname = "Ніцше", BirthDate = new DateTime(1873, 6, 16) };
        //    Author author3 = new Author() { Id = 3, Name = "Себастьян", Surname = "Крудз", BirthDate = new DateTime(1983, 4, 11) };
        //    Author author4 = new Author() { Id = 4, Name = "Фредеріка", Surname = "Крудз", BirthDate = new DateTime(1878, 8, 3) };

        //    object authorBook1 = new { Id = 1, AuthorId = 1, BookId = 1 };
        //    object authorBook2 = new { Id = 2, AuthorId = 2, BookId = 2 };
        //    object authorBook3 = new { Id = 3, AuthorId = 3, BookId = 2 };
        //    object authorBook4 = new { Id = 4, AuthorId = 3, BookId = 3 };
        //    object authorBook5 = new { Id = 5, AuthorId = 4, BookId = 3 };
        //    //book1.AuthorBooks.Add(authorBook1);
        //    //book2.AuthorBooks.Add(authorBook2);
        //    //book2.AuthorBooks.Add(authorBook3);
        //    //book3.AuthorBooks.Add(authorBook4);
        //    //book3.AuthorBooks.Add(authorBook5);
        //    //author1.AuthorBooks.Add(authorBook1);
        //    //author2.AuthorBooks.Add(authorBook2);
        //    //author3.AuthorBooks.Add(authorBook3);
        //    //author3.AuthorBooks.Add(authorBook4);
        //    //author4.AuthorBooks.Add(authorBook5);

        //    List<object> Readers = new List<object>() { reader1, reader2, reader3 };
        //    List<Book> Books = new List<Book>() { book1, book2, book3 };
        //    List<Author> Authors = new List<Author>() { author1, author2, author3, author4 };
        //    List<object> Records = new List<object>() { record1, record2, record3, record4, record5 };
        //    List<object> Chapters = new List<object>() { chapter1, chapter2, chapter3, chapter4, chapter5, chapter6, chapter7 };
        //    List<object> AuthorBooks = new List<object>() { authorBook1, authorBook2, authorBook3, authorBook4, authorBook5 };
        //    List<ReaderCard> ReaderCards = new List<ReaderCard>() { readerCard1, readerCard2, readerCard3};

        //    //Readers.AddRange(new List<Reader>() { reader1, reader2, reader3 });
        //    //Books.AddRange(new List<Book>() { book1, book2, book3 });
        //    //Authors.AddRange(new List<Author>() { author1, author2, author3, author4 });

        //    modelBuilder.Entity<Author>().HasData(Authors);
        //    modelBuilder.Entity<Reader>().HasData(Readers);
        //    modelBuilder.Entity<Book>().HasData(Books);
        //    modelBuilder.Entity<AuthorBook>().HasData(AuthorBooks);
        //    modelBuilder.Entity<Chapter>().HasData(Chapters);
        //    modelBuilder.Entity<ReaderCard>().HasData(ReaderCards);
        //    modelBuilder.Entity<Record>().HasData(Records);
        //}
    }
}
