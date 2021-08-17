using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BooksStorage.Core.Models;
using BooksStorage.Core.Exceptions;
using BooksStorage.Core.Interfaces.Repositories;
using BooksStorage.Persistence;

namespace BooksStorage.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooksStorageContext _context;

        public AuthorRepository(BooksStorageContext context) => _context = context;

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        => await _context.Authors.ToListAsync();

        public async Task<Author> GetAuthorByNameAsync(string name)
        => await _context.Authors.FirstOrDefaultAsync(a => a.Name == name);

        public async Task<Author> GetAuthorByNameWithBooksAsync(string name)
        => await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Name == name);

        public async Task<int> GetAuthorsByNamesAmountAsync(IEnumerable<string> names)
        => await _context.Authors.Where(a => names.Contains(a.Name)).CountAsync();

        public async Task<IEnumerable<Author>> GetAuthorsByNamesAsync(IEnumerable<string> names)
        => await _context.Authors.Where(a => names.Contains(a.Name)).ToListAsync();

        public async Task AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}