using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BooksStorage.Core.Interfaces.Services;
using BooksStorage.Common.Contracts;
using AutoMapper;

namespace BooksStorage.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthorsController
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IAuthorService _service;

        public AuthorsController(IMapper mapper,
            ILogger<AuthorsController> logger, IAuthorService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
        {
            _logger.LogInformation("Extracting authors...");
            return await _service.GetAuthorsAsync();

            // return _mapper.Map<Author, AuthorDto>(authors);
        }

        [HttpGet("books")]
        // Most RESTful iimplementation is "Authors/{id}/books"
        // But as we are working with names (not ids) in all methods
        // it is better to move string parameters from path
        public async Task<int> GetAuthorBooksAmountAsync([FromQuery] string name)
        {
            _logger.LogInformation($"Extracting {name}'s books...");
            return await _service.GetAuthorBooksAmountAsync(name);
        }

        [HttpPost]
        public async Task AddAuthorAsync([FromBody] AuthorCreationDto author)
        {
            _logger.LogInformation($"Adding author {author}...");
            await _service.AddAuthorAsync(author);
        }

        [HttpDelete]
        public async Task DeleteAuthorAsync([FromQuery] string name)
        {
            _logger.LogInformation($"Deleting author #{name}...");
            await _service.DeleteAuthorAsync(name);
        }
    }
}