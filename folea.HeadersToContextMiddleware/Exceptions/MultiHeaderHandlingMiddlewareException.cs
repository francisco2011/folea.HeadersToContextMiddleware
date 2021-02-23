using System;
using System.Runtime.Serialization;


namespace folea.HeadersToContextMiddleware.Exceptions
{
    public class MultiHeaderHandlingMiddlewareException : Exception
    {
        public MultiHeaderHandlingMiddlewareException()
        {
        }

        public MultiHeaderHandlingMiddlewareException(string message) : base(message)
        {
        }

        public MultiHeaderHandlingMiddlewareException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MultiHeaderHandlingMiddlewareException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
