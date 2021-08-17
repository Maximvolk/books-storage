using System;

namespace BooksStorage.Core.Exceptions
{
    public class ObjectAlreadyExistsException : AbstractBadRequestException
    {
        public ObjectAlreadyExistsException(string message) : base(message) {}
    }
}