namespace Mu.Modelling.FeatureTests.KindTests;

public sealed class WhenImplicitOperatorFromByteIsCalled
{
    private const byte MutationalValue = 0;

    [Fact]
    public void GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange
        byte value = MutationalValue;

        // Act
        Feature.Kind subject = value;
        byte result = subject;

        // Assert
        result.ShouldBe(value);
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}