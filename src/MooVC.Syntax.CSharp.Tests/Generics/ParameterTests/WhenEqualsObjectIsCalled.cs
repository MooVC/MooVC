namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsObjectIsCalled
{
    private const string AlternativeName = "TOther";
    private const string DefaultName = "TValue";

    [Test]
    public void GivenNonParameterThenReturnsFalse()
    {
        // Arrange
        object other = new();
        Parameter subject = Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Parameter subject = Create();
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Parameter subject = Create();
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEquivalentParameterThenReturnsTrue()
    {
        // Arrange
        Parameter subject = Create();
        object other = Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentParameterThenReturnsFalse()
    {
        // Arrange
        Parameter subject = Create();
        object other = Create(AlternativeName);

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
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