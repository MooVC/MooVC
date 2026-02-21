namespace Mu.Modelling.FeatureExtensionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenIsMutationalIsCalled
{
    private const string FeatureNameValue = "Feature";
    private const string RegisteredFactValue = "Registered";

    [Fact]
    public void GivenBuilderThenFeatureIsMutational()
    {
        // Arrange
        Feature original = Feature.Undefined.Named(new Name(FeatureNameValue));

        // Act
        Feature result = original.IsMutational(mutational => mutational
            .IsCreational()
            .Yields(new Name(RegisteredFactValue)));

        // Assert
        result.Type.ShouldBe(Feature.Kind.Mutational);
        result.Mutational.Fact.ShouldBe(new Name(RegisteredFactValue));
        result.NonMutational.ShouldBe(NonMutational.Undefined);
    }
}