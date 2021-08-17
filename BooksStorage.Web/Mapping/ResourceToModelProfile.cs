using BooksStorage.Core.Models;
using BooksStorage.Common.Contracts;
using AutoMapper;

namespace BooksStorage.Web.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AuthorDto, Author>();
            CreateMap<AuthorCreationDto, Author>();

            CreateMap<BookDto, Book>();
            CreateMap<BookCreationDto, Book>();
            CreateMap<BookUpdateDto, Book>();
        }
    }
}