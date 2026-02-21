namespace MooVC.Syntax.CSharp.Members.PropertyTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

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
            Behaviours = behaviours ?? new Property.Methods { Get = "value;" },
            Default = @default ?? Snippet.Empty,
            Name = name ?? Name.Unnamed,
            Scope = scope ?? Scope.Public,
            Type = type ?? DefaultType,
        };
    }
}