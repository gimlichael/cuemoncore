﻿using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace Cuemon.AspNetCore.Http
{
    /// <summary>
    /// The exception that is thrown when the web server, after performing server-driven content negotiation, does not find any content that conforms to the criteria given by the user agent.
    /// </summary>
    /// <seealso cref="HttpStatusCodeException" />
    [Serializable]
    public class NotAcceptableException : HttpStatusCodeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotAcceptableException"/> class.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public NotAcceptableException(Exception innerException) : this(default, innerException)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the HTTP status code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public NotAcceptableException(string message = null, Exception innerException = null) : base(StatusCodes.Status406NotAcceptable, message ?? "The resource identified by the request is only capable of generating response entities which have content characteristics not acceptable according to the accept headers sent in the request.", innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodNotAllowedException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected NotAcceptableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}