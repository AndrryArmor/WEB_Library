using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class ReaderService : IReaderService
    {
        private IUnitOfWork unitOfWork;

        public ReaderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Reader> GetAllReaders()
        {
            return unitOfWork.ReaderRepository.GetAll();
        }

        public void AddNewReader(string name, string surname, int age, string email)
        {
            var readers = unitOfWork.ReaderRepository.GetAll();
            var readerId = readers.Select(reader => reader.Id).Max() + 1;
            var readerCardId = readers.Select(reader => reader.ReaderCard.Id).Max() + 1;

            ReaderCard newReaderCard = new ReaderCard(readerCardId, name, surname, age, email, DateTime.Now);
            unitOfWork.ReaderRepository.Create(new Reader(readerId, newReaderCard));
        }

        public void AddBookToReader(int readerId, int bookId)
        {
            var readers = new List<Reader>(unitOfWork.ReaderRepository.GetAll());
            var books = new List<Book>(unitOfWork.BookRepository.GetAll());

            var records = readers.SelectMany(reader => reader.Records);
            var recordId = records.Select(record => record.Id).Max() + 1;

            Reader reader = readers.Find(reader => reader.Id == readerId);
            Book book = books.Find(book => book.Id == bookId);

            reader.Records.Add(new Record(recordId, book, DateTime.Now, reader));
        }
    }
}
