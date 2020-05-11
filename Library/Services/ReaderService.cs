using Library.Models;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class ReaderService
    {
        private UnitOfWork unitOfWork;

        public ReaderService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddNewReader(string name, string surname, int age, string email)
        {
            var readers = unitOfWork.ReaderRepository.GetAll();
            var readerId = readers.Select(reader => reader.Id).Max() + 1;
            var readerCardId = readers.Select(reader => reader.ReaderCard.Id).Max() + 1;

            ReaderCard newReaderCard = new ReaderCard(readerCardId, name, surname, age, email, DateTime.Now);
            unitOfWork.ReaderRepository.Create(new Reader(readerId, newReaderCard));
        }

        public void AddBook(Reader reader, Book book)
        {
            var readers = unitOfWork.ReaderRepository.GetAll();
            var records = readers.SelectMany(reader => reader.Records);
            var recordId = records.Select(record => record.Id).Max() + 1;

            reader.Records.Add(new Record(recordId, book, DateTime.Now, reader));
        }
    }
}
