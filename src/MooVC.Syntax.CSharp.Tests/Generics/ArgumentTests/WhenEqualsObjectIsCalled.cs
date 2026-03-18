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
        Argument subject = Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Argument subject = Create();
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
        Argument subject = Create();
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
        Argument subject = Create();
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
        Argument subject = Create();
        object other = Create(AlternativeName);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    private static Argument Create(string name = DefaultName)
    {
        return new Argument
        {
            Name = new Name(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}