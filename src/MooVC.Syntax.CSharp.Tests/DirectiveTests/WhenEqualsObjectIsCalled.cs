namespace MooVC.Syntax.CSharp.DirectiveTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string Alias = "Alias";
    private const string AlternativeAlias = "Other";

    [Test]
    public async Task GivenDifferentDirectiveThenReturnsFalse()
    {
        // Arrange
        Directive subject = Create();
        object comparison = Create(alias: AlternativeAlias);

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEquivalentDirectiveThenReturnsTrue()
    {
        // Arrange
        Directive subject = Create();
        object comparison = Create();

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenNonDirectiveThenReturnsFalse()
    {
        // Arrange
        Directive subject = Create();
        object comparison = new object();

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Directive subject = Create();
        object? comparison = default;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Directive subject = Create();
        object comparison = subject;

        // Act
        bool result = subject.Equals(comparison);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    private static Directive Create(string alias = Alias)
    {
        return new Directive
        {
            Alias = alias,
            Qualifier = new(["MooVC", "Syntax"]),
        };
    }
}