namespace MooVC.Syntax.CSharp.ReferenceTests;

using MooVC.Syntax.CSharp;

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