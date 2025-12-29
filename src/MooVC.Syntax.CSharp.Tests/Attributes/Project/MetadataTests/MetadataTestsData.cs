namespace MooVC.Syntax.CSharp.Attributes.Project.MetadataTests;

using MooVC.Syntax.CSharp.Elements;

internal static class MetadataTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultName = "Metadata";
    public const string DefaultValue = "Value";

    public static Metadata Create(Snippet? condition = default, Identifier? name = default, Snippet? value = default)
    {
        return new Metadata
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Name = name ?? new Identifier(DefaultName),
            Value = value ?? Snippet.From(DefaultValue),
        };
    }
}