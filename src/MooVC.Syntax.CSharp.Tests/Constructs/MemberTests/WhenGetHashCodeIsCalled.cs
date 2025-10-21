namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";
    private const string Unicode = "Álpha";

    [Fact]
    public void GivenNullWhenCalledThenThrows()
    {
        // Arrange
        var subject = new Member(default);

        // Act & Assert
        _ = Should.Throw<NullReferenceException>(() => _ = subject.GetHashCode());
    }

    [Fact]
    public void GivenEmptyWhenCalledThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Member(Empty);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Empty.GetHashCode());
    }

    [Fact]
    public void GivenWhitespaceWhenCalledThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Member(Space);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Space.GetHashCode());
    }

    [Fact]
    public void GivenAsciiWhenCalledThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Member(Alpha);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Alpha.GetHashCode());
    }

    [Fact]
    public void GivenUnicodeWhenCalledThenMatchesStringHashCode()
    {
        // Arrange
        var subject = new Member(Unicode);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(Unicode.GetHashCode());
    }

    [Fact]
    public void GivenVeryLongWhenCalledThenMatchesStringHashCode()
    {
        // Arrange
        string value = new string('x', 64_000);
        var subject = new Member(value);

        // Act
        int result = subject.GetHashCode();

        // Assert
        result.ShouldBe(value.GetHashCode());
    }

    [Fact]
    public void GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        var first = new Member(Alpha);
        var second = new Member(Alpha);

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
        var subject = new Member(Alpha);

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        first.ShouldBe(second);
    }
}