﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cuemon.Extensions.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace Cuemon.Extensions.Resilience
{
    public class ExceptionTest : Test
    {
        public ExceptionTest(ITestOutputHelper output = null) : base(output)
        {
        }

        [Fact]
        public void LatencyException_ShouldBeSerializable()
        {
            var ex = new LatencyException(Generate.RandomString(10));

            TestOutput.WriteLine(ex.ToString());

            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, ex);
                ms.Position = 0;
                var desEx = bf.Deserialize(ms) as LatencyException;
                Assert.Equal(ex.Message, desEx.Message);
                Assert.Equal(ex.ToString(), desEx.ToString());
            }
        }

        [Fact]
        public void TransientFaultException_ShouldBeSerializable()
        {
            var ex = new TransientFaultException(Generate.RandomString(25), new TransientFaultEvidence(10, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(2), "Class1.SomeMethod()"));

            TestOutput.WriteLine(ex.ToString());

            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, ex);
                ms.Position = 0;
                var desEx = bf.Deserialize(ms) as TransientFaultException;
                Assert.Equal(ex.Evidence, desEx.Evidence);
                Assert.Equal(ex.Message, desEx.Message);
                Assert.Equal(ex.ToString(), desEx.ToString());
            }
        }
    }
}