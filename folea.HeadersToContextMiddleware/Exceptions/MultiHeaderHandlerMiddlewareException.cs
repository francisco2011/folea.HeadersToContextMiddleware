using System;
using System.Runtime.Serialization;


namespace folea.HeadersToContextMiddleware.Exceptions
{
    public class MultiHeaderHandlerMiddlewareException : Exception
    {
        public MultiHeaderHandlerMiddlewareException()
        {
        }

        public MultiHeaderHandlerMiddlewareException(string message) : base(message)
        {
        }

        public MultiHeaderHandlerMiddlewareException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MultiHeaderHandlerMiddlewareException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
