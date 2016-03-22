using System;

namespace Musher.EchoNest.Exceptions
{
    public class EchoNestException : Exception
    {
        public EchoNestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public EchoNestException(string message) : base(message)
        {
        }
    }
}
