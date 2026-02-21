namespace Mu.Modelling.NonMutationalTests.KindTests;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenReadStoreValueThenReturnsName()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.ReadStore;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(nameof(NonMutational.Kind.ReadStore));
    }

    [Fact]
    public void GivenWriteStoreValueThenReturnsName()
    {
        // Arrange
        NonMutational.Kind subject = NonMutational.Kind.WriteStore;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(nameof(NonMutational.Kind.WriteStore));
    }
}