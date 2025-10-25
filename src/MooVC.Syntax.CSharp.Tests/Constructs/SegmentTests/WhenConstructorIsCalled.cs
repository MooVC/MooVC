namespace MooVC.Syntax.CSharp.Constructs.SegmentTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange & Act & Assert
        _ = Should.NotThrow(() => _ = new Segment(default));
    }

    [Fact]
    public void GivenEmptyThenInstanceIsCreated()
    {
        // Arrange
        string value = string.Empty;

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Segment(value));
    }

    [Fact]
    public void GivenWhitespaceThenInstanceIsCreated()
    {
        // Arrange
        string value = "   ";

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Segment(value));
    }

    [Fact]
    public void GivenAlphaNumericThenInstanceIsCreated()
    {
        // Arrange
        string value = new Faker().Random.AlphaNumeric(32);

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Segment(value));
    }

    [Fact]
    public void GivenVeryLongThenInstanceIsCreated()
    {
        // Arrange
        string value = new('x', 64_000);

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Segment(value));
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqual()
    {
        // Arrange
        const string value = "Value";

        // Act
        var first = new Segment(value);
        var second = new Segment(value);

        // Assert
        first.Equals(second).ShouldBeTrue();
        (first == second).ShouldBeTrue();
        first.GetHashCode().ShouldBe(second.GetHashCode());
    }

    [Fact]
    public void GivenDifferentValuesTwiceThenInstancesAreNotEqual()
    {
        // Arrange
        const string left = "First";
        const string right = "Second";

        // Act
        var first = new Segment(left);
        var second = new Segment(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}