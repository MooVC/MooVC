namespace Mu.Modelling.NonMutationalTests.KindTests;

public sealed class WhenImplicitOperatorFromByteIsCalled
{
    private const byte ReadStoreValue = 0;

    [Fact]
    public void GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange
        byte value = ReadStoreValue;

        // Act
        NonMutational.Kind subject = value;
        byte result = subject;

        // Assert
        result.ShouldBe(value);
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}