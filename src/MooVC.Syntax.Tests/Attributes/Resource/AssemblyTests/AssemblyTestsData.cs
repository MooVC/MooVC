namespace MooVC.Syntax.Attributes.Resource.AssemblyTests;

using MooVC.Syntax.Elements;

internal static class AssemblyTestsData
{
    public const string DefaultAlias = "System.Windows.Forms";
    public const string DefaultName = "System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

    public static Assembly Create(
        Snippet? alias = default,
        Snippet? name = default)
    {
        return new Assembly
        {
            Alias = alias ?? Snippet.From(DefaultAlias),
            Name = name ?? Snippet.From(DefaultName),
        };
    }
}