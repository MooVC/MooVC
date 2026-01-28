namespace MooVC.Syntax.Attributes.Project.PropertyGroupTests;

using MooVC.Syntax.Elements;

internal static class PropertyGroupTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultLabel = "Label";
    public const string DefaultPropertyCondition = "PropertyCondition";
    public const string DefaultPropertyName = "Property";
    public const string DefaultPropertyValue = "Value";

    public static PropertyGroup Create(
        Snippet? condition = default,
        Snippet? label = default,
        Property? property = default)
    {
        var values = new PropertyGroup
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Label = label ?? Snippet.From(DefaultLabel),
        };

        if (property is not null)
        {
            values = values.WithProperties(property);
        }

        return values;
    }

    public static Property CreateProperty()
    {
        return new Property
        {
            Condition = Snippet.From(DefaultPropertyCondition),
            Name = new Identifier(DefaultPropertyName),
            Value = Snippet.From(DefaultPropertyValue),
        };
    }
}