using AutoMapper;
using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer;
using LibraryRestApi.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.BusinessLayer.Services
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

        public void Create(Reader reader)
        {
            _unitOfWork.ReaderRepository.Create(_mapper.Map<ReaderEntity>(reader));
            _unitOfWork.ReaderCardRepository.Create(_mapper.Map<ReaderCardEntity>(reader.ReaderCard));
            _unitOfWork.SaveChanges();
        }

        public Reader Read(int id)
        {
            var reader = _unitOfWork.ReaderRepository.GetAll()
                .Include(reader => reader.ReaderCard)
                .Where(reader => reader.Id == id).FirstOrDefault();
            return _mapper.Map<Reader>(reader);
        }

        public void Update(Reader reader)
        {
            _unitOfWork.ReaderRepository.Update(_mapper.Map<ReaderEntity>(reader));
            _unitOfWork.ReaderCardRepository.Update(_mapper.Map<ReaderCardEntity>(reader.ReaderCard));
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _unitOfWork.ReaderCardRepository.Delete(_unitOfWork.ReaderRepository.Read(id).ReaderCard.Id);
            _unitOfWork.ReaderRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Reader> GetAll()
        {
            var readers = _unitOfWork.ReaderRepository.GetAll()
                .Include(reader => reader.ReaderCard);
            return readers.Select(readerEntity => _mapper.Map<Reader>(readerEntity));
        }
    }
}
