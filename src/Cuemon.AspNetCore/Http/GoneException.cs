﻿using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace Cuemon.AspNetCore.Http
{
    /// <summary>
    /// The exception that is thrown when the requested content has been permanently deleted from server, with no forwarding address.
    /// </summary>
    /// <seealso cref="HttpStatusCodeException" />
    [Serializable]
    public class GoneException : HttpStatusCodeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoneException"/> class.
        /// </summary>
        public GoneException() : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoneException"/> class.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public GoneException(Exception innerException) : this(default, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoneException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the HTTP status code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public GoneException(string message, Exception innerException = null) : base(StatusCodes.Status410Gone, message ?? "The requested resource is no longer available at the server and no forwarding address is known.", innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoneException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected GoneException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}