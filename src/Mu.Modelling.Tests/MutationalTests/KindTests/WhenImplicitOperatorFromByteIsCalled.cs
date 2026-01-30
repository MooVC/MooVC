namespace Mu.Modelling.MutationalTests.KindTests;

public sealed class WhenImplicitOperatorFromByteIsCalled
{
    private const byte CreationalValue = 0;

    [Fact]
    public void GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange
        byte value = CreationalValue;

        // Act
        Mutational.Kind subject = value;
        byte result = subject;

        // Assert
        result.ShouldBe(value);
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}