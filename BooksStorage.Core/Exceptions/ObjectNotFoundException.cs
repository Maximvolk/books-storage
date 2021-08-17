using System;

namespace BooksStorage.Core.Exceptions
{
    public class ObjectNotFoundException : AbstractNotFoundException
    {
        public ObjectNotFoundException(string message) : base(message) {}
    }
}