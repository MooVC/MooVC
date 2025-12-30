namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;
using Identifier = MooVC.Syntax.Elements.Identifier;

internal static class PropertyTestsData
{
    public const string DefaultName = "Value";
    public static readonly Symbol DefaultType = typeof(string);

    public static Property Create(
        Property.Methods? behaviours = default,
        Snippet? @default = default,
        string? name = DefaultName,
        Scope? scope = default,
        Symbol? type = default)
    {
        return new Property
        {
            Behaviours = behaviours ?? new Property.Methods { Get = Snippet.From("value;") },
            Default = @default ?? Snippet.Empty,
            Name = name is null
                ? Identifier.Unnamed
                : new Identifier(name),
            Scope = scope ?? Scope.Public,
            Type = type ?? DefaultType,
        };
    }
}