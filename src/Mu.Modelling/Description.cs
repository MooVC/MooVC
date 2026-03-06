namespace Mu.Modelling;

using Ardalis.GuardClauses;
using Fluentify;
using Monify;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;

[AutoInitializeWith(nameof(Undescribed))]
[Monify<string>]
public sealed partial class Description
{
    public static readonly Description Undescribed = new(string.Empty);

    public Description(string value)
    {
        _value = value ?? string.Empty;
    }

    public bool IsUndescribed => this == Undescribed;

    public static implicit operator Snippet(Description description)
    {
        Guard.Against.Conversion<Description, Snippet>(description);

        return description._value;
    }

    public override string ToString()
    {
        return _value;
    }
}