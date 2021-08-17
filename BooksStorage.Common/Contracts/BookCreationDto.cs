using System.Collections.Generic;

namespace BooksStorage.Common.Contracts
{
    public record BookCreationDto
    {
        public string Title { get; set; }
        public IEnumerable<AuthorCreationDto> Authors { get; set; }
    }
}