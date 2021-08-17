using BooksStorage.Core.Models;
using BooksStorage.Common.Contracts;
using AutoMapper;

namespace BooksStorage.Web.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
        }
    }
}