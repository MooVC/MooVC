namespace Mu.Modelling.FeatureTests;

using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string FeatureNameValue = "FeatureName";

    [Fact]
    public void GivenValuesThenContainsDetails()
    {
        // Arrange
        var name = new Name(FeatureNameValue);
        Feature subject = ModellingTestData.CreateFeature(name: name);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain(nameof(Feature));
        result.ShouldContain(FeatureNameValue);
    }
}