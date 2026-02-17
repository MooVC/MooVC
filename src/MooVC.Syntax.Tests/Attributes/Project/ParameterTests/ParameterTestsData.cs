namespace MooVC.Syntax.Attributes.Project.ParameterTests;

using MooVC.Syntax.Elements;

internal static class ParameterTestsData
{
    public const string DefaultName = "Parameter";
    public const string DefaultValue = "Value";

    public static Parameter Create(Name? name = default, Snippet? value = default)
    {
        return new Parameter
        {
            Name = name ?? DefaultName,
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}