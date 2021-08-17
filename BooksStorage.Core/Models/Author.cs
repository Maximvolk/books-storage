using System.Collections.Generic;

namespace BooksStorage.Core.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}