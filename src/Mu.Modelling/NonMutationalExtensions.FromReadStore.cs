namespace Mu.Modelling;

public static partial class MutationalExtensions
{
    public static NonMutational FromReadStore(this NonMutational nonMutational)
    {
        return nonMutational.From(NonMutational.Kind.ReadStore);
    }
}