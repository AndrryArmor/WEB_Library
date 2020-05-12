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
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<BookDTO, Book>().ReverseMap();
            CreateMap<ChapterDTO, Chapter>().ReverseMap();
            CreateMap<ReaderDTO, Reader>().ReverseMap();
            CreateMap<ReaderCardDTO, Author>().ReverseMap();
            CreateMap<RecordDTO, Record>().ReverseMap();
        }
    }
}
