namespace Mu.Modelling.NonMutationalTests.KindTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string ReadStoreValue = "ReadStore";

    [Fact]
    public void GivenValueThenRoundTripsSuccessfully()
    {
        // Arrange
        string value = ReadStoreValue;

        // Act
        NonMutational.Kind subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(value);
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }
}