using AutoMapper;
using Library.Entities;
using Library.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDTO>()
                .ForMember(authorDTO => authorDTO.Books, opt => opt
                    .MapFrom(author => author.AuthorBooks.Select(authorBook => authorBook.Book)));
            CreateMap<Book, BookDTO>()
                .ForMember(bookDTO => bookDTO.Authors, opt => opt
                    .MapFrom(book => book.AuthorBooks.Select(authorBook => authorBook.Author)));
            CreateMap<Chapter, ChapterDTO>().ReverseMap();
            CreateMap<Reader, ReaderDTO>().ReverseMap();
            CreateMap<ReaderCard, ReaderCardDTO>().ReverseMap();
            CreateMap<Record, RecordDTO>().ReverseMap();
        }
    }
}
