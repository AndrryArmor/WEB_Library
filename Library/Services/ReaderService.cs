using AutoMapper;
using Library.Entities;
using Library.Models;
using Library.Objects;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;
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
            var readers = _unitOfWork.ReaderRepository.GetAll()
                .Include(reader => reader.ReaderCard)
                .Include(reader => reader.Records);
            return readers.Select(reader => _mapper.Map<ReaderDTO>(reader));
        }

        public IEnumerable<RecordDTO> GetAllRecords()
        {
            var records = _unitOfWork.RecordRepository.GetAll();
            return records.Select(reader => _mapper.Map<RecordDTO>(reader));
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = _unitOfWork.BookRepository.GetAll();
            return books.Select(reader => _mapper.Map<BookDTO>(reader));
        }

        public void AddNewReader(string name, string surname, int age, string email)
        {
            var newReader = new Reader
            {
                ReaderCard = new ReaderCard
                {
                    Name = name,
                    Surname = surname,
                    Age = age,
                    Email = email,
                    DateOfRegistration = DateTime.Now
                },
                Records = new List<Record>()
            };
            _unitOfWork.ReaderRepository.Create(newReader);
        }

        public void AddBookToReader(int readerId, int bookId)
        {
            var newRecord = new Record
            {
                Book = _unitOfWork.BookRepository.Read(bookId),
                DateOfReceiving = DateTime.Now,
                Reader = _unitOfWork.ReaderRepository.Read(readerId)
            };
            _unitOfWork.RecordRepository.Create(newRecord);
        }
    }
}
