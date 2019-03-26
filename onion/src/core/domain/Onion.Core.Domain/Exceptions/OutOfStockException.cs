using System;

namespace Onion.Core.Domain.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message)
        {
        }
    }
}