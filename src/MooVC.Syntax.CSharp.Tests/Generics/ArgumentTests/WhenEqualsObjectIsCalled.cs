namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenEqualsObjectIsCalled
{
    private const string AlternativeName = "TOther";
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenNonArgumentThenReturnsFalse()
    {
        // Arrange
        object other = new();
        Generic subject = Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Generic subject = Create();
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Generic subject = Create();
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentArgumentThenReturnsTrue()
    {
        // Arrange
        Generic subject = Create();
        object other = Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentArgumentThenReturnsFalse()
    {
        // Arrange
        Generic subject = Create();
        object other = Create(AlternativeName);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    private static Generic Create(string name = DefaultName)
    {
        return new Generic
        {
            Name = new Name(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}