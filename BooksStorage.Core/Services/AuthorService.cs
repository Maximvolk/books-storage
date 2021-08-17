using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using BooksStorage.Core.Exceptions;
using BooksStorage.Core.Interfaces.Services;
using BooksStorage.Core.Interfaces.Repositories;
using BooksStorage.Core.Models;
using BooksStorage.Common.Contracts;
using AutoMapper;

namespace BooksStorage.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _repository;

        public AuthorService(IMapper mapper, IAuthorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
        {
            var authors = await _repository.GetAuthorsAsync();
            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDto>>(authors);
        }

        public async Task<int> GetAuthorBooksAmountAsync(string name)
        {
            var author = await _repository.GetAuthorByNameWithBooksAsync(name); 

            if (author == null)
                throw new ObjectNotFoundException($"Author {name} not found");

            return author.Books.Count();
        }
        
        public async Task AddAuthorAsync(AuthorCreationDto authorDto)
        {
            var existingAuthor = await _repository.GetAuthorByNameAsync(authorDto.Name); 

            if (existingAuthor != null)
                throw new ObjectAlreadyExistsException($"Author {authorDto.Name} already exists");

            var author = _mapper.Map<AuthorCreationDto, Author>(authorDto);
            await _repository.AddAuthorAsync(author);
        }

        public async Task DeleteAuthorAsync(string name)
        {
            var author = await _repository.GetAuthorByNameAsync(name); 

            if (author == null)
                throw new ObjectNotFoundException($"Author {name} not found");

            await _repository.DeleteAuthorAsync(author);
        }
    }
}