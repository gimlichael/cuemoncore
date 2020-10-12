﻿using Cuemon.AspNetCore.Builder;
using Cuemon.Extensions.Xunit.Hosting.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Builder;

namespace Cuemon.Extensions.Xunit.Hosting.AspNetCore
{
    /// <summary>
    /// Extension methods for the <see cref="IApplicationBuilder"/> interface.
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds a <see cref="FakeHttpResponseMiddleware"/> to the <see cref="IApplicationBuilder"/> request execution pipeline.
        /// </summary>
        /// <param name="builder">The type that provides the mechanisms to configure an application’s request pipeline.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        /// <seealso cref="FakeHttpResponseFeature"/>
        public static IApplicationBuilder UseFakeHttpResponseTrigger(this IApplicationBuilder builder)
        {
            return MiddlewareBuilderFactory.UseMiddleware<FakeHttpResponseMiddleware>(builder);
        }
    }
}