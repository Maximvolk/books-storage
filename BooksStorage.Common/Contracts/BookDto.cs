using System.Collections.Generic;

namespace BooksStorage.Common.Contracts
{
    public record BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public IList<AuthorDto> Authors { get; set; }
    }
}