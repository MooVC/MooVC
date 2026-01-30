namespace Mu.Modelling;

public static partial class FeatureExtensions
{
    public static Feature IsNonMutational(this Feature feature, Func<NonMutational, NonMutational> builder)
    {
        return feature
            .OfType(Feature.Kind.NonMutational)
            .WithNonMutational(builder);
    }
}