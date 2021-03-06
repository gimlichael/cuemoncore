﻿using System;
using System.Linq;
using Cuemon.AspNetCore.Diagnostics;
using Cuemon.AspNetCore.Mvc.Filters.Diagnostics;
using Cuemon.Collections.Generic;
using Cuemon.Extensions.IO;
using Cuemon.Extensions.Newtonsoft.Json.Formatters;
using Cuemon.Extensions.Xunit;
using Cuemon.Extensions.Xunit.Hosting.AspNetCore;
using Cuemon.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json.Converters
{
    public class JsonConverterCollectionExtensionsTest : Test
    {
        public JsonConverterCollectionExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, false)]
        public void AddHttpExceptionDescriptorConverter_ShouldAddHttpExceptionDescriptorToConverterCollection(bool includeExceptionDescriptorFailure, bool includeExceptionStackTrace, bool includeExceptionDescriptorEvidence)
        {
            OutOfMemoryException oome = null;
            try
            {
                throw new OutOfMemoryException();
            }
            catch (OutOfMemoryException e)
            {
                oome = e;
            }

            using (var middleware = MiddlewareTestFactory.CreateMiddlewareTest(app => { }, services => { services.AddFakeHttpContextAccessor(ServiceLifetime.Singleton); }))
            {
                var context = middleware.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                var correlationId = Guid.NewGuid().ToString("N");
                var requestId = Guid.NewGuid().ToString("N");

                var sut1 = new HttpExceptionDescriptor(oome, message: "Custom non-revealing message.")
                {
                    CorrelationId = correlationId,
                    RequestId = requestId,
                    HelpLink = new Uri("https://docs.microsoft.com/en-us/dotnet/api/system.outofmemoryexception")
                };

                sut1.AddEvidence("Request", context.Request, request => new HttpRequestEvidence(request));

                var sut2 = new JsonFormatterOptions()
                {
                    IncludeExceptionStackTrace = includeExceptionStackTrace,
                    IncludeExceptionDescriptorFailure = includeExceptionDescriptorFailure,
                    IncludeExceptionDescriptorEvidence = includeExceptionDescriptorEvidence
                };

                var dc = sut2.Settings.Converters.SingleOrDefault(jc => jc.CanConvert(typeof(HttpExceptionDescriptor)));
                if (dc != null) { sut2.Settings.Converters.Remove(dc); }
                sut2.Settings.Converters.AddHttpExceptionDescriptorConverter(o =>
                {
                    o.IncludeEvidence = includeExceptionDescriptorEvidence;
                    o.IncludeFailure = includeExceptionDescriptorFailure;
                });

                Assert.Collection(sut2.Settings.Converters.Where(jc => jc.CanConvert(typeof(HttpExceptionDescriptor))), jc =>
                {
                    var result = StreamFactory.Create(writer =>
                    {
                        var js = JsonSerializer.Create(sut2.Settings);
                        using (var jsonWriter = new JsonTextWriter(writer))
                        {
                            jsonWriter.CloseOutput = false;
                            js.Serialize(jsonWriter, sut1);
                        }
                    });

                    var json = result.ToEncodedString();

                    Assert.True(jc.CanWrite);
                    Assert.False(jc.CanRead);
                    Assert.True(jc.CanConvert(typeof(HttpExceptionDescriptor)));

                    Assert.Contains("\"error\":", json);
                    Assert.Contains("\"status\": 500", json);
                    Assert.Contains("\"code\": \"InternalServerError\"", json);
                    Assert.Contains("\"message\": \"Custom non-revealing message.\"", json);
                    Assert.Contains("\"helpLink\": \"https://docs.microsoft.com/en-us/dotnet/api/system.outofmemoryexception\"", json);

                    Assert.Contains($"\"correlationId\": \"{correlationId}\"", json);
                    Assert.Contains($"\"requestId\": \"{requestId}\"", json);

                    Condition.FlipFlop(includeExceptionDescriptorFailure, () =>
                    {
                        Assert.Contains("\"failure\":", json);
                        Assert.Contains("\"type\": \"System.OutOfMemoryException\"", json);
                        Assert.Contains("\"source\": \"Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json.Tests\"", json);
                        Assert.Contains("\"message\": \"Insufficient memory to continue the execution of the program.\"", json);
                    }, () =>
                    {
                        Assert.DoesNotContain("\"failure\":", json);
                        Assert.DoesNotContain("\"type\": \"System.OutOfMemoryException\"", json);
                        Assert.DoesNotContain("\"source\": \"Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json.Tests\"", json);
                        Assert.DoesNotContain("\"message\": \"Insufficient memory to continue the execution of the program.\"", json);
                    });

                    Condition.FlipFlop(includeExceptionStackTrace, () =>
                    {
                        Assert.Contains("\"stack\":", json);
                        Assert.Contains("\"at Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json.Converters.JsonConverterCollectionExtensionsTest.AddHttpExceptionDescriptorConverter_ShouldAddHttpExceptionDescriptorToConverterCollection", json);
                    }, () =>
                    {
                        Assert.DoesNotContain("\"stack\":", json);
                        Assert.DoesNotContain("\"at Cuemon.Extensions.AspNetCore.Mvc.Formatters.Newtonsoft.Json.Converters.JsonConverterCollectionExtensionsTest.AddHttpExceptionDescriptorConverter_ShouldAddHttpExceptionDescriptorToConverterCollection", json);
                    });

                    Condition.FlipFlop(includeExceptionDescriptorEvidence, () =>
                    {
                        Assert.Contains("\"evidence\":", json);
                        Assert.Contains("\"request\":", json);
                        Assert.Contains("\"location\": \"http:///\"", json);
                        Assert.Contains("\"method\": \"GET\"", json);
                        Assert.Contains("\"headers\":", json);
                        Assert.Contains("\"query\":", json);
                        Assert.Contains("\"cookies\":", json);
                        Assert.Contains("\"body\":", json);
                    }, () =>
                    {
                        Assert.DoesNotContain("\"evidence\":", json);
                    });

                    TestOutput.WriteLine(json);
                });
            }
        }

        [Fact]
        public void AddStringValuesConverter_ShouldAddStringValuesConverterToConverterCollection()
        {
            var sut1 = new StringValues(Arguments.ToArrayOf("This", "is", "a", "test", "!"));

            var sut2 = new JsonFormatterOptions();

            var dc = sut2.Settings.Converters.SingleOrDefault(jc => jc.CanConvert(typeof(StringValues)));
            if (dc != null) { sut2.Settings.Converters.Remove(dc); }
            sut2.Settings.Converters.AddStringValuesConverter();

            Assert.Collection(sut2.Settings.Converters.Where(jc => jc.CanConvert(typeof(StringValues))), jc =>
            {
                var result = StreamFactory.Create(writer =>
                {
                    var js = JsonSerializer.Create(sut2.Settings);
                    using (var jsonWriter = new JsonTextWriter(writer))
                    {
                        jsonWriter.CloseOutput = false;
                        js.Serialize(jsonWriter, sut1);
                    }
                });

                var json = result.ToEncodedString();

                Assert.True(jc.CanWrite);
                Assert.False(jc.CanRead);
                Assert.True(jc.CanConvert(typeof(StringValues)));

                Assert.Contains("[", json);
                Assert.Contains("\"This\",", json);
                Assert.Contains("\"is\"", json);
                Assert.Contains("\"a\"", json);
                Assert.Contains("\"test\"", json);
                Assert.Contains("\"!\"", json);
                Assert.Contains("]", json);

                TestOutput.WriteLine(json);
            });
        }
    }
}