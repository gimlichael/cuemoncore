﻿using System;
using Cuemon.AspNetCore.Configuration;
using Microsoft.Extensions.Options;

namespace Cuemon.AspNetCore.Razor.TagHelpers
{
    /// <summary>
    /// Provides an implementation targeting &lt;link&gt; elements that supports <see cref="ICacheBusting"/> versioning of a static resource placed on a location with a CDN role. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="LinkTagHelper{TOptions}" />
    [Obsolete("This class is deprecated and will be removed soon. Please use CdnLinkTagHelper instead.")]
    public sealed class LinkCdnTagHelper :  LinkTagHelper<CdnTagHelperOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkCdnTagHelper"/> class.
        /// </summary>
        /// <param name="setup">The <see cref="CdnTagHelperOptions" /> which need to be configured.</param>
        /// <param name="cacheBusting">An optional object implementing the <see cref="ICacheBusting" /> interface.</param>
        public LinkCdnTagHelper(IOptions<CdnTagHelperOptions> setup, ICacheBusting cacheBusting = null) : base(setup, cacheBusting)
        {
        }
    }
}
