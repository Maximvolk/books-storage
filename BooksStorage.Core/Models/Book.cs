using System.Collections.Generic;

namespace BooksStorage.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public IEnumerable<Author> Authors { get; set; }
    }
}