using System;

namespace folea.HeadersToContextMiddleware.Models
{
    public class MultiHeaderHandlerConfigurationOption
    {
        /// <summary>
        /// The header we will be looking for, example: request-id
        /// </summary>
        public string HeaderKey { get; }
        /// <summary>
        /// Will be sended only if header exists and has a value
        /// </summary>
        public bool Propagate { get; }
        /// <summary>
        /// If the value is true then ValueCreationMethodIfNull must be 
        /// declared
        /// </summary>
        public bool CreateIfNotExists { get; }
        /// <summary>
        /// If the value is empty or the header is not present, 
        /// but it must be returned or created if not exists then
        /// the function will be executed!
        /// </summary>
        public Func<string> ValueCreationMethodIfNull { get; }

        /// <summary>
        /// If property is true then the value will be set on Context.TraceId
        /// </summary>
        public bool IsTraceId { get; set; }

        public MultiHeaderHandlerConfigurationOption(string headerKey,
                                                bool isTraceId = false,
                                                bool sendInResponse = false, 
                                                bool createIfNotExists = false, 
                                                Func<string> valueCreationMethodIfNull = null)
        {
            this.HeaderKey = headerKey;
            this.IsTraceId = isTraceId;
            this.Propagate = sendInResponse;
            this.CreateIfNotExists = createIfNotExists;
            this.ValueCreationMethodIfNull = valueCreationMethodIfNull;
        }
    }
}
