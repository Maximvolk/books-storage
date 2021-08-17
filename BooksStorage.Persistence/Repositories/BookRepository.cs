using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BooksStorage.Core.Models;
using BooksStorage.Core.Interfaces.Repositories;

namespace BooksStorage.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksStorageContext _context;

        public BookRepository(BooksStorageContext context) => _context = context;

        public async Task<IEnumerable<Book>> GetBooksAsync()
        => await _context.Books.Include(b => b.Authors).ToListAsync();

        public async Task<Book> GetBookByTitleAsync(string title)
        => await _context.Books.FirstOrDefaultAsync(b => b.Title == title);

        public async Task<Book> GetBookByIdWithAuthorsAsync(int id)
        => await _context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);

        public async Task AddBookAsync(string title, IEnumerable<Author> authors)
        {
            Book book = new Book { Title = title, Authors = authors };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(int existingBookId, string title, IEnumerable<Author> authors)
        {
            _context.Books.Remove(await _context.Books.Where(b => b.Id == existingBookId).FirstOrDefaultAsync());
            await AddBookAsync(title, authors);
        }

        public async Task DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}