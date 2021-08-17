using System;

namespace BooksStorage.Core.Exceptions
{
    public class AbstractNotFoundException : Exception
    {
        protected AbstractNotFoundException(string message) : base(message) {}
    }
}