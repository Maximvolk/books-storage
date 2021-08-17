using System.Threading.Tasks;
using System.Collections.Generic;
using BooksStorage.Core.Models;

namespace BooksStorage.Core.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByTitleAsync(string title);
        Task<Book> GetBookByIdWithAuthorsAsync(int id);

        Task AddBookAsync(string title, IEnumerable<Author> authors);
        Task UpdateBookAsync(int existingBookId, string title, IEnumerable<Author> authors);
        Task DeleteBookAsync(Book book);
    }
}