namespace Muify;

using System.Reflection;
using Microsoft.CodeAnalysis.CSharp;
using Xunit.Sdk;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class FrameworksAttribute
    : DataAttribute
{
    public LanguageVersion Language { get; set; } = LanguageVersion.CSharp8;

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
#if CI
        return Frameworks.All(Language);
#else
        return Frameworks.Supported(Language);
#endif
    }
}