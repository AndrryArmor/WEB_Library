using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public static class DataSource
    {
        private static bool isCalled = false;
        public static List<Reader> Readers { get; }
        public static List<Book> Books { get; }
        public static List<Author> Authors { get; }

        public static void CreateData()
        {
            if (isCalled == true)
                return;

            ReaderCard readerCard1 = new ReaderCard(1, "Василій", "Пупкін", 17, "pupkin_v@gmail.com", new DateTime(2018, 10, 2));
            ReaderCard readerCard2 = new ReaderCard(2, "Анастасія", "Козаченко", 19, "koz_a@gmail.com", new DateTime(2016, 3, 30));
            ReaderCard readerCard3 = new ReaderCard(3, "Віталій", "Дзюба", 24, "vitalii_dziuba@gmail.com", new DateTime(2019, 4, 13));

            Reader reader1 = new Reader() { Id = 1, ReaderCard = readerCard1 };
            Reader reader2 = new Reader() { Id = 2, ReaderCard = readerCard2 };
            Reader reader3 = new Reader() { Id = 3, ReaderCard = readerCard3 };

            Book book1 = new Book() { Id = 1, Name = "Том в Гренландії" };
            Book book2 = new Book() { Id = 2, Name = "Філософія думок" };
            Book book3 = new Book() { Id = 3, Name = "Останній листок" };

            Record record1 = new Record(1, book3, new DateTime(2019, 10, 24), reader1);
            Record record2 = new Record(2, book1, new DateTime(2020, 1, 16), reader1);
            Record record3 = new Record(3, book2, new DateTime(2019, 5, 24), reader2);
            Record record4 = new Record(4, book3, new DateTime(2019, 9, 4), reader2);
            Record record5 = new Record(5, book1, new DateTime(2019, 6, 24), reader3);
            reader1.Records.Add(record1);
            reader1.Records.Add(record2);
            reader2.Records.Add(record3);
            reader2.Records.Add(record4);
            reader3.Records.Add(record5);

            Chapter chapter1 = new Chapter() { Id = 1, Name = "Вступ", Book = book1 };
            Chapter chapter2 = new Chapter() { Id = 2, Name = "Пригоди тома", Book = book1 };
            Chapter chapter3 = new Chapter() { Id = 3, Name = "Завершення історії", Book = book1 };
            Chapter chapter4 = new Chapter() { Id = 4, Name = "Усе починається з думки", Book = book2 };
            Chapter chapter5 = new Chapter() { Id = 5, Name = "Думай серцем", Book = book2 };
            Chapter chapter6 = new Chapter() { Id = 6, Name = "Холодна осінь", Book = book3 };
            Chapter chapter7 = new Chapter() { Id = 7, Name = "Опале листя", Book = book3 };
            book1.Chapters.Add(chapter1);
            book1.Chapters.Add(chapter2);
            book1.Chapters.Add(chapter3);
            book2.Chapters.Add(chapter4);
            book2.Chapters.Add(chapter5);
            book3.Chapters.Add(chapter6);
            book3.Chapters.Add(chapter7);

            Author author1 = new Author() { Id = 1, Name = "Георг", Surname = "Кельвінгтон", BirthDate = new DateTime(1965, 3, 25) };
            Author author2 = new Author() { Id = 2, Name = "Фрідріх", Surname = "Ніцше", BirthDate = new DateTime(1873, 6, 16) };
            Author author3 = new Author() { Id = 3, Name = "Себастьян", Surname = "Крудз", BirthDate = new DateTime(1983, 4, 11) };
            Author author4 = new Author() { Id = 4, Name = "Фредеріка", Surname = "Крудз", BirthDate = new DateTime(1878, 8, 3) };

            AuthorBook authorBook1 = new AuthorBook() { Id = 1, Author = author1, Book = book1 };
            AuthorBook authorBook2 = new AuthorBook() { Id = 2, Author = author2, Book = book2 };
            AuthorBook authorBook3 = new AuthorBook() { Id = 3, Author = author3, Book = book2 };
            AuthorBook authorBook4 = new AuthorBook() { Id = 4, Author = author3, Book = book3 };
            AuthorBook authorBook5 = new AuthorBook() { Id = 5, Author = author4, Book = book3 };
            book1.AuthorBooks.Add(authorBook1);
            book2.AuthorBooks.Add(authorBook2);
            book2.AuthorBooks.Add(authorBook3);
            book3.AuthorBooks.Add(authorBook4);
            book3.AuthorBooks.Add(authorBook5);
            author1.AuthorBooks.Add(authorBook1);
            author2.AuthorBooks.Add(authorBook2);
            author3.AuthorBooks.Add(authorBook3);
            author3.AuthorBooks.Add(authorBook4);
            author4.AuthorBooks.Add(authorBook5);

            Readers.AddRange(new List<Reader>(){ reader1, reader2, reader3});
            Books.AddRange(new List<Book>() { book1, book2, book3 });
            Authors.AddRange(new List<Author>() { author1, author2, author3, author4 });

            isCalled = true;
        }
    }
}
