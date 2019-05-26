using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace RayTracer.Tests
{
    [TraitDiscoverer("RayTracer.Tests.UnitTestDiscoverer", "RayTracer.Tests")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UnitTestAttribute : Attribute, ITraitAttribute
    {
    }

    public class UnitTestDiscoverer : ITraitDiscoverer
    {
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            yield return new KeyValuePair<string, string>("Category", "UnitTest");
        }
    }
}