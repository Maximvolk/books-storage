using System.Threading.Tasks;
using System.Collections.Generic;
using BooksStorage.Common.Contracts;

namespace BooksStorage.Core.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task AddBookAsync(BookCreationDto bookDto);
        Task UpdateBookAsync(BookUpdateDto bookDto);
        Task DeleteBookAsync(string title);
    }
}