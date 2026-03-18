namespace MooVC.Syntax.CSharp.FieldTests;

using MooVC.Syntax.CSharp.SymbolTests;

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
                ? Variable.Unnamed
                : new Variable(name),
            Scope = scope ?? Scope.Public,
            Type = type ?? DefaultType,
        };
    }
}