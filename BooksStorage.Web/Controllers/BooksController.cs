using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BooksStorage.Core.Interfaces.Services;
using BooksStorage.Common.Contracts;
using AutoMapper;

namespace BooksStorage.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BooksController
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IBookService _service;

        public BooksController(IMapper mapper,
            ILogger<BooksController> logger, IBookService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            _logger.LogInformation("Extracting books");
            return await _service.GetBooksAsync();
        }

        [HttpPost]
        public async Task AddBookAsync([FromBody] BookCreationDto book)
        {
            _logger.LogInformation($"Adding book {book}...");
            await _service.AddBookAsync(book);
        }

        [HttpPut]
        public async Task UpdateBookAsync([FromBody] BookUpdateDto book)
        {
            _logger.LogInformation($"Updating book {book}...");
            await _service.UpdateBookAsync(book);
        }

        [HttpDelete]
        public async Task DeleteBookAsync([FromQuery] string title)
        {
            _logger.LogInformation($"Deleting book {title}...");
            await _service.DeleteBookAsync(title);
        }
    }
}