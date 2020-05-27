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
                .ForMember(author => author.Books, opt => opt
                    .MapFrom(authorEntity => authorEntity.AuthorBooks
                        .Select(authorBookEntity => authorBookEntity.Book)));
            CreateMap<Author, AuthorEntity>();
            CreateMap<BookEntity, Book>()
                .ForMember(book => book.Authors, opt => opt
                    .MapFrom(bookEntity => bookEntity.AuthorBooks
                        .Select(authorBookEntity => authorBookEntity.Author)));
            CreateMap<Book, BookEntity>();
            CreateMap<ChapterEntity, Chapter>().ReverseMap();
            CreateMap<ReaderEntity, Reader>().ReverseMap();
            CreateMap<ReaderCardEntity, ReaderCard>().ReverseMap();
            CreateMap<RecordEntity, Record>().ReverseMap();
        }
    }
}
