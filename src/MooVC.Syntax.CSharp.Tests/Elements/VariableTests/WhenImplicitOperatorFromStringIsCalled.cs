namespace MooVC.Syntax.CSharp.Elements.VariableTests;

public sealed class WhenImplicitOperatorFromStringIsCalled
{
    private const string Empty = "";
    private const string Space = "   ";
    private const string Alpha = "Alpha";

    [Fact]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange
        string? value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = (Variable)value);
    }

    [Fact]
    public void GivenNullWhenRoundTrippedThenResultIsEmpty()
    {
        // Arrange
        string? value = default;

        // Act
        Variable subject = value;
        string result = subject;

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenEmptyThenEqualsString()
    {
        // Arrange
        string value = Empty;

        // Act
        Variable subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueThenEqualsString()
    {
        // Arrange
        string value = Alpha;

        // Act
        Variable subject = value;

        // Assert
        (subject == value).ShouldBeTrue();
        subject.Equals(value).ShouldBeTrue();
    }

    [Fact]
    public void GivenVeryLongThenEqualsString()
    {
        // Arrange
        string value = new('x', 64_000);
        string expected = value.ToPascalCase();

        // Act
        Variable subject = value;

        // Assert
        (subject == expected).ShouldBeTrue();
        subject.Equals(expected).ShouldBeTrue();
    }

    [Fact]
    public void GivenValueWhenRoundTrippedThenMatchesOriginalInCamelCase()
    {
        // Arrange
        string value = Alpha;
        string expected = value.ToCamelCase();

        // Act
        Variable subject = value;
        string result = subject;

        // Assert
        result.ShouldBe(expected);
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqualButNotSameReference()
    {
        // Arrange
        string value = Alpha;

        // Act
        Variable first = value;
        Variable second = value;

        // Assert
        ReferenceEquals(first, second).ShouldBeFalse();
        (first == second).ShouldBeTrue();
        first.Equals(second).ShouldBeTrue();
    }
}