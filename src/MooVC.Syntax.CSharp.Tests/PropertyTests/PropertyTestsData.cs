namespace MooVC.Syntax.CSharp.PropertyTests;

internal static class PropertyTestsData
{
    public const string DefaultName = "Value";
    public static readonly Symbol DefaultType = typeof(string);

    public static Property Create(
        Property.Methods? behaviours = default,
        Snippet? @default = default,
        string? name = DefaultName,
        Scopes? scope = default,
        Symbol? type = default)
    {
        return new Property
        {
            Behaviours = behaviours ?? new Property.Methods { Get = Snippet.From("value;") },
            Default = @default ?? Snippet.Empty,
            Name = name ?? Name.Unnamed,
            Scope = scope ?? Scopes.Public,
            Type = type ?? DefaultType,
        };
    }
}