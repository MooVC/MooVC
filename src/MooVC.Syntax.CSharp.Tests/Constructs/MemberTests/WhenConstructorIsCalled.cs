namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenNullWhenInstantiatedThenInstanceIsCreated()
    {
        // Arrange & Act & Assert
        _ = Should.NotThrow(() => _ = new Member(default));
    }

    [Fact]
    public void GivenEmptyWhenInstantiatedThenInstanceIsCreated()
    {
        // Arrange
        string value = string.Empty;

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Member(value));
    }

    [Fact]
    public void GivenWhitespaceWhenInstantiatedThenInstanceIsCreated()
    {
        // Arrange
        string value = "   ";

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Member(value));
    }

    [Fact]
    public void GivenAlphaNumericWhenInstantiatedThenInstanceIsCreated()
    {
        // Arrange
        string value = new Faker().Random.AlphaNumeric(32);

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Member(value));
    }

    [Fact]
    public void GivenVeryLongWhenInstantiatedThenInstanceIsCreated()
    {
        // Arrange
        string value = new string('x', 64_000);

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Member(value));
    }

    [Fact]
    public void GivenSameValueWhenInstantiatedTwiceThenInstancesAreEqual()
    {
        // Arrange
        const string value = "Value";

        // Act
        var first = new Member(value);
        var second = new Member(value);

        // Assert
        first.Equals(second).ShouldBeTrue();
        (first == second).ShouldBeTrue();
        first.GetHashCode().ShouldBe(second.GetHashCode());
    }

    [Fact]
    public void GivenDifferentValuesWhenInstantiatedTwiceThenInstancesAreNotEqual()
    {
        // Arrange
        const string left = "First";
        const string right = "Second";

        // Act
        var first = new Member(left);
        var second = new Member(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}