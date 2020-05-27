using AutoMapper;
using LibraryRestApi.BusinessLayer.Models;
using LibraryRestApi.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryRestApi.BusinessLayer
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AuthorEntity, Author>()
                .ForMember(authorDTO => authorDTO.Books, opt => opt
                    .MapFrom(author => author.AuthorBooks
                        .Select(authorBook => authorBook.Book)));
            CreateMap<BookEntity, Book>()
                .ForMember(bookDTO => bookDTO.Authors, opt => opt
                    .MapFrom(book => book.AuthorBooks
                        .Select(authorBook => authorBook.Author)));
            CreateMap<ChapterEntity, Chapter>().ReverseMap();
            CreateMap<ReaderEntity, Reader>().ReverseMap();
            CreateMap<ReaderCardEntity, ReaderCard>().ReverseMap();
            CreateMap<RecordEntity, Record>().ReverseMap();
        }
    }
}
