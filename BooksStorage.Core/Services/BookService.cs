using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using BooksStorage.Common.Contracts;
using BooksStorage.Core.Interfaces.Services;
using BooksStorage.Core.Interfaces.Repositories;
using BooksStorage.Core.Models;
using BooksStorage.Core.Exceptions;
using AutoMapper;

namespace BooksStorage.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository,
            IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDto>>(books);
        }

        public async Task AddBookAsync(BookCreationDto bookDto)
        {
            var existingBook = await _bookRepository.GetBookByTitleAsync(bookDto.Title);

            if (existingBook != null)
                throw new ObjectAlreadyExistsException($"Book {bookDto.Title} already exists");

            if (!(await CheckAuthorsExist(bookDto.Authors)))
                throw new ObjectNotFoundException($"Some authors for new book not found");

            var authors = await _authorRepository.GetAuthorsByNamesAsync(bookDto.Authors.Select(a => a.Name));
            await _bookRepository.AddBookAsync(bookDto.Title, authors);
        }

        public async Task UpdateBookAsync(BookUpdateDto bookDto)
        {
            var existingBook = await _bookRepository.GetBookByIdWithAuthorsAsync(bookDto.Id);

            if (existingBook == null)
                throw new ObjectNotFoundException($"Book #{bookDto.Id} not found");

            string updatedTitle = existingBook.Title;
            IEnumerable<Author> updatedAuthors = existingBook.Authors;

            if (bookDto.Title != null)
                updatedTitle = bookDto.Title;

            if (bookDto.Authors.Count() > 0)
            {
                if (!(await CheckAuthorsExist(bookDto.Authors)))
                    throw new ObjectNotFoundException($"Some authors for new book not found");

                updatedAuthors = await _authorRepository.GetAuthorsByNamesAsync(bookDto.Authors.Select(a => a.Name));
            }

            await _bookRepository.UpdateBookAsync(existingBook.Id, updatedTitle, updatedAuthors);
        }

        private async Task<bool> CheckAuthorsExist(IEnumerable<AuthorCreationDto> authorDtos)
        {
            if (authorDtos.Count() == 0)
                return false;

            var existingAuthorsAmount = await _authorRepository.GetAuthorsByNamesAmountAsync(authorDtos.Select(a => a.Name));
            return existingAuthorsAmount == authorDtos.Count();
        }

        public async Task DeleteBookAsync(string title)
        {
            var existingBook = await _bookRepository.GetBookByTitleAsync(title);

            if (existingBook == null)
                throw new ObjectNotFoundException($"Book {title} not found");

            await _bookRepository.DeleteBookAsync(existingBook);
        }
    }
}