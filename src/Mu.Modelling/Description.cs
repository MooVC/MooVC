namespace Mu.Modelling;

using Fluentify;
using Monify;

[AutoInitializeWith(nameof(Undescribed))]
[Monify<string>]
public sealed partial class Description
{
    public static readonly Description Undescribed = new(string.Empty);

    public bool IsUndescribed => this == Undescribed;

    public override string ToString()
    {
        return _value;
    }
}