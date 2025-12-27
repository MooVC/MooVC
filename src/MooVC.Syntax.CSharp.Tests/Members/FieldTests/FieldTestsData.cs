namespace MooVC.Syntax.CSharp.Members.FieldTests;

using MooVC.Syntax.CSharp.Members.SymbolTests;

internal static class FieldTestsData
{
    public const string DefaultName = "Value";
    public static readonly Symbol DefaultType = SymbolTestsData.Create("Result");

    public static Field Create(
        Snippet? @default = default,
        bool? isReadOnly = default,
        bool? isStatic = default,
        string? name = DefaultName,
        Scope? scope = default,
        Symbol? type = default)
    {
        return new Field
        {
            Default = @default ?? Snippet.Empty,
            IsReadOnly = isReadOnly ?? true,
            IsStatic = isStatic ?? false,
            Name = name is null
                ? Identifier.Unnamed
                : new Identifier(name),
            Scope = scope ?? Scope.Public,
            Type = type ?? DefaultType,
        };
    }
}