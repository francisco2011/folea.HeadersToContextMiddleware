using folea.HeadersToContextMiddleware.Implementations;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace folea.HeadersToContextMiddleware.Extensions
{
    
        public static class HeadersToContextMiddlewareExtension
        {
            public static IApplicationBuilder UseMultiHeaderHandler(this IApplicationBuilder applicationBuilder)
            {
                return applicationBuilder.UseMiddleware<MultiHeaderHandlerMiddleware>();
            }
        }
    
}
