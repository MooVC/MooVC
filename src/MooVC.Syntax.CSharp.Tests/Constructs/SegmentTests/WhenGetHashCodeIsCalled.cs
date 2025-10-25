namespace MooVC.Syntax.CSharp.Constructs.SegmentTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Fact]
    public void GivenNullThenThrows()
    {
        // Arrange
        var subject = new Segment(default);

        // Act & Assert
        _ = Should.Throw<NullReferenceException>(() => _ = subject.GetHashCode());
    }

    [Fact]
    public void GivenEmptyThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Segment(Empty);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Empty.GetHashCode());
    }

    [Fact]
    public void GivenWhitespaceThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Segment(Space);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Space.GetHashCode());
    }

    [Fact]
    public void GivenAsciiThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Segment(Alpha);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Alpha.GetHashCode());
    }

    [Fact]
    public void GivenUnicodeThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Segment(Unicode);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Unicode.GetHashCode());
    }

    [Fact]
    public void GivenVeryLongThenMatchesStringHashCode()
    {
        // Arrange
        string value = new string('x', 64_000);
        var subject = new Segment(value);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(value.GetHashCode());
    }

    [Fact]
    public void GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        var first = new Segment(Alpha);
        var second = new Segment(Alpha);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenSameInstanceWhenCalledTwiceThenHashIsStable()
    {
        // Arrange
        var subject = new Segment(Alpha);

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        first.ShouldBe(second);
    }
}
