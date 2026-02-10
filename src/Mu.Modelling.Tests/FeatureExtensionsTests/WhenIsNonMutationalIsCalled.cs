namespace Mu.Modelling.FeatureExtensionsTests;

using MooVC.Syntax.Elements;

public sealed class WhenIsNonMutationalIsCalled
{
    private const string FeatureNameValue = "Feature";
    private const string ViewNameValue = "View";

    [Fact]
    public void GivenBuilderThenFeatureIsNonMutational()
    {
        // Arrange
        Feature original = Feature.Undefined.Named(new Identifier(FeatureNameValue));

        // Act
        Feature result = original.IsNonMutational(nonMutational => nonMutational
            .FromWriteStore()
            .Using(new Identifier(ViewNameValue)));

        // Assert
        result.Type.ShouldBe(Feature.Kind.NonMutational);
        result.NonMutational.View.ShouldBe(new Identifier(ViewNameValue));
        result.Mutational.ShouldBe(Mutational.Undefined);
    }
}