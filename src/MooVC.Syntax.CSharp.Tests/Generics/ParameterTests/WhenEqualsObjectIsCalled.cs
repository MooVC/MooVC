namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    private const string AlternativeName = "TOther";
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenNonParameterThenReturnsFalse()
    {
        // Arrange
        object other = new();
        Parameter subject = Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Parameter subject = Create();
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
        Parameter subject = Create();
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentParameterThenReturnsTrue()
    {
        // Arrange
        Parameter subject = Create();
        object other = Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentParameterThenReturnsFalse()
    {
        // Arrange
        Parameter subject = Create();
        object other = Create(AlternativeName);

        // Act
        bool result = subject.Equals(other);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    private static Parameter Create(string name = DefaultName)
    {
        return new Parameter
        {
            Name = new Name(name),
            Constraints = [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }],
        };
    }
}