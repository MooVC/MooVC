namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Alias = "Alias";
    private const string AlternativeAlias = "Other";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Directive subject = Create();
        object? comparison = default;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Directive subject = Create();
        object comparison = subject;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentDirectiveThenReturnsTrue()
    {
        // Arrange
        Directive subject = Create();
        object comparison = Create();

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentDirectiveThenReturnsFalse()
    {
        // Arrange
        Directive subject = Create();
        object comparison = Create(alias: AlternativeAlias);

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonDirectiveThenReturnsFalse()
    {
        // Arrange
        Directive subject = Create();
        object comparison = new();

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        result.ShouldBeFalse();
    }

    private static Directive Create(string alias = Alias)
    {
        return new Directive
        {
            Alias = new Identifier(alias),
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };
    }
}