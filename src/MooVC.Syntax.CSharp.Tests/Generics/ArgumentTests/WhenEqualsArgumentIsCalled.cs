namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenEqualsArgumentIsCalled
{
    private const string AlternativeName = "TOther";
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Argument? left = default;
        Argument? right = default;

        // Act
        bool result = left?.Equals(right) ?? (right is null);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Argument? left = default;
        Argument right = Create();

        // Act
        bool result = left?.Equals(right) ?? false;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Argument left = Create();
        Argument? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Argument first = Create();
        Argument second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Argument left = Create();
        Argument right = Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Argument left = Create();
        Argument right = Create(AlternativeName);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentConstraintsThenReturnsFalse()
    {
        // Arrange
        Argument left = Create();
        Argument right = Create(constraint: Constraint.Unspecified);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    private static Argument Create(string name = DefaultName, Constraint? constraint = default)
    {
        return new Argument
        {
            Name = new Name(name),
            Constraints = constraint is null
                ? [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }]
                : [constraint],
        };
    }
}