namespace Mu.Modelling;

public static partial class MutationalExtensions
{
    public static Mutational IsTransitional(this Mutational mutational)
    {
        return mutational.OfType(Mutational.Kind.Transitional);
    }
}