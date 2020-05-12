using AutoMapper;
using Library.Entities;
using Library.Models;
using Library.Objects;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class ReaderService : IReaderService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ReaderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ReaderDTO> GetAllReaders()
        {
            var foundReaders = _unitOfWork.ReaderRepository.GetAll();
            return foundReaders.Select(reader => _mapper.Map<ReaderDTO>(reader));
        }

        public void AddNewReader(string name, string surname, int age, string email)
        {
            var readers = _unitOfWork.ReaderRepository.GetAll();
            var readerId = readers.Select(reader => reader.Id).Max() + 1;
            var readerCardId = readers.Select(reader => reader.ReaderCard.Id).Max() + 1;

            var newReaderCard = new ReaderCard
            { 
                Id = readerCardId, 
                Name = name, 
                Surname = surname, 
                Age = age, 
                Email = email, 
                DateOfRegistration = DateTime.Now 
            };
            var newReader = new Reader
            {
                Id = readerId,
                ReaderCard = newReaderCard
            };
            _unitOfWork.ReaderRepository.Create(newReader);
        }

        public void AddBookToReader(int readerId, int bookId)
        {
            var readers = new List<Reader>(_unitOfWork.ReaderRepository.GetAll());
            var records = readers.SelectMany(reader => reader.Records);
            var recordId = records.Select(record => record.Id).Max() + 1;

            var books = new List<Book>(_unitOfWork.BookRepository.GetAll());
            Book book = books.Find(book => book.Id == bookId);

            Reader reader = readers.Find(reader => reader.Id == readerId);

            var newRecord = new Record
            {
                Id = recordId,
                Book = book,
                DateOfReceiving = DateTime.Now,
                Reader = reader
            };
            reader.Records.Add(newRecord);
        }
    }
}
