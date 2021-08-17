using System;

namespace BooksStorage.Core.Exceptions
{
    public class AbstractBadRequestException : Exception
    {
        protected AbstractBadRequestException(string message) : base(message) {}
    }
}