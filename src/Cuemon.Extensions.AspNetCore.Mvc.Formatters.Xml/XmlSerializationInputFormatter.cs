﻿using Cuemon.AspNetCore.Mvc.Formatters;
using Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml.Converters;
using Cuemon.Xml.Serialization.Formatters;
using Microsoft.Net.Http.Headers;

namespace Cuemon.Extensions.AspNetCore.Mvc.Formatters.Xml
{
    /// <summary>
    /// This class handles deserialization of XML to objects using <see cref="XmlFormatter"/>.
    /// </summary>
    public class XmlSerializationInputFormatter : StreamInputFormatter<XmlFormatter, XmlFormatterOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializationInputFormatter" /> class.
        /// </summary>
        /// <param name="options">The <see cref="XmlFormatterOptions"/> which need to be configured.</param>
        public XmlSerializationInputFormatter(XmlFormatterOptions options) : base(options)
        {
            options.Settings.Converters.AddHttpExceptionDescriptorConverter(o =>
            {
                o.IncludeEvidence = options.IncludeExceptionDescriptorEvidence;
                o.IncludeFailure = options.IncludeExceptionDescriptorFailure;
                o.IncludeStackTrace = options.IncludeExceptionStackTrace;
            });
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
        }
    }
}