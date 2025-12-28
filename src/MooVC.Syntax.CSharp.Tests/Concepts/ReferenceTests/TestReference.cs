namespace MooVC.Syntax.CSharp.Concepts.ReferenceTests;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Elements;

internal sealed class TestReference
    : Reference
{
    public TestReference()
        : base(Parameter.Options.Camel, "widget")
    {
    }

    public bool IsUndefinedValue { get; set; }

    public override bool IsUndefined => IsUndefinedValue;
}