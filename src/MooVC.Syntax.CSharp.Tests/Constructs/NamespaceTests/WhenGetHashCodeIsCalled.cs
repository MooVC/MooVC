namespace MooVC.Syntax.CSharp.Constructs.NamespaceTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenNullThenThrows()
    {
        // Arrange
        var subject = new Namespace(default);

        // Act & Assert
        _ = Should.Throw<NullReferenceException>(() => _ = subject.GetHashCode());
    }

    [Fact]
    public void GivenEmptyThenHashesAreEqualAcrossInstances()
    {
        // Arrange
        var first = new Namespace(Array.Empty<Segment>());
        var second = new Namespace(new Segment[0]);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        Segment[] firstValue =
        {
            new Segment("Alpha"),
            new Segment("Beta"),
        };

        Segment[] secondValue =
        {
            new Segment("Alpha"),
            new Segment("Beta"),
        };

        var first = new Namespace(firstValue);
        var second = new Namespace(secondValue);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesAreDifferent()
    {
        // Arrange
        var first = new Namespace(new[] { new Segment("Alpha") });
        var second = new Namespace(new[] { new Segment("Beta") });

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenSameInstanceWhenCalledTwiceThenHashIsStable()
    {
        // Arrange
        var subject = new Namespace(new[] { new Segment("Alpha"), new Segment("Beta") });

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        first.ShouldBe(second);
    }
}
