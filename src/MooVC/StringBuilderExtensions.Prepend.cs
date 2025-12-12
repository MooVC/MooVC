namespace MooVC;

using System.Text;
using Ardalis.GuardClauses;
using static MooVC.StringBuilderExtensions_Resources;

public static partial class StringBuilderExtensions
{
    public static StringBuilder Prepend(this StringBuilder builder, char value)
    {
        _ = Guard.Against.Null(builder, message: PrependBuilderRequired.Format(value));
        _ = Guard.Against.Null(value, message: PrependValueRequired);

        return builder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder builder, string value)
    {
        _ = Guard.Against.Null(builder, message: PrependBuilderRequired.Format(value));
        _ = Guard.Against.Null(value, message: PrependValueRequired);

        return builder.Insert(0, value);
    }
}