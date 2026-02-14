namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string MutationalValue = "Mutational";

    [Fact]
    public void GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange
        string value = MutationalValue;

        // Act
        Feature.Kind subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(value);
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}