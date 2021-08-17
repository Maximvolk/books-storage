using System.Collections.Generic;

namespace BooksStorage.Common.Contracts
{
    public record BookUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<AuthorCreationDto> Authors { get; set; }
    }
}