using System.Threading.Tasks;
using System.Collections.Generic;
using BooksStorage.Core.Models;

namespace BooksStorage.Core.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByNameAsync(string name);
        Task<Author> GetAuthorByNameWithBooksAsync(string name);
        Task<int> GetAuthorsByNamesAmountAsync(IEnumerable<string> names);
        Task<IEnumerable<Author>> GetAuthorsByNamesAsync(IEnumerable<string> names);

        Task AddAuthorAsync(Author author);
        Task DeleteAuthorAsync(Author author);
    }
}