using folea.HeadersToContextMiddleware.Exceptions;
using folea.HeadersToContextMiddleware.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace folea.HeadersToContextMiddleware.Implementations
{
    public class MultiHeaderHandlerMiddleware
    {
        public MultiHeaderHandlerConfigurationOption[] Options { get;  }

        private readonly RequestDelegate next;

        
        public MultiHeaderHandlerMiddleware(RequestDelegate next, MultiHeaderHandlerConfigurationOption[] pams)
        {
            Options = pams;
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            ensureHeader(context);
            await next(context);
        }

        private void ensureHeader(HttpContext context)
        {
            for (int i = 0; i < Options.Length; i++)
            {
                var option = Options[i];

                if (string.IsNullOrEmpty(option.HeaderKey)) throw new MultiHeaderHandlerMiddlewareException("HeaderKey must have a value");
                if (option.CreateIfNotExists && (option.ValueCreationMethodIfNull is null)) throw new MultiHeaderHandlerMiddlewareException("if ValueCreationMethodIfNull is true then ValueCreationMethodIfNull must have a value");

                var headerValue = context.Request.Headers[option.HeaderKey].FirstOrDefault();

                if(string.IsNullOrEmpty(headerValue) && option.CreateIfNotExists)
                {
                    context.Items.Add(option.HeaderKey, option.ValueCreationMethodIfNull.Invoke());
                    if (option.Propagate) context.Response.Headers.Add(option.HeaderKey, headerValue);
                }
                else if(!string.IsNullOrEmpty(headerValue))
                {
                    context.Items.Add(option.HeaderKey, headerValue);
                    if(option.Propagate) context.Response.Headers.Add(option.HeaderKey, headerValue);
                }
            }            
        }
    }
}
