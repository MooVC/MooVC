namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Alias = "Alias";
    private const string AlternativeAlias = "Other";

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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
            Alias = alias,
            Qualifier = new Qualifier(["MooVC", "Syntax"]),
        };
    }
}