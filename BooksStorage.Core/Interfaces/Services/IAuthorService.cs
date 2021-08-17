using System.Threading.Tasks;
using System.Collections.Generic;
using BooksStorage.Common.Contracts;

namespace BooksStorage.Core.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
        Task<int> GetAuthorBooksAmountAsync(string name);
        Task AddAuthorAsync(AuthorCreationDto authorDto);
        Task DeleteAuthorAsync(string name);
    }
}