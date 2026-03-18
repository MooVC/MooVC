namespace MooVC.Syntax.CSharp.GenericTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenEqualityOperatorArgumentArgumentIsCalled
{
    private const string AlternativeName = "TOther";
    private const string DefaultName = "TValue";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Generic? left = default;
        Generic? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Generic? left = default;
        Generic right = Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Generic left = Create();
        Generic? right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Generic first = Create();
        Generic second = first;

        // Act
        bool result = first == second;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Generic left = Create();
        Generic right = Create();

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentNamesThenReturnsFalse()
    {
        // Arrange
        Generic left = Create();
        Generic right = Create(AlternativeName);

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentConstraintsThenReturnsFalse()
    {
        // Arrange
        Generic left = Create();
        Generic right = Create(constraint: Constraint.Unspecified);

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        _ = await Assert.That(resultLeftRight).IsFalse();
        _ = await Assert.That(resultRightLeft).IsFalse();
    }

    private static Generic Create(string name = DefaultName, Constraint? constraint = default)
    {
        return new Generic
        {
            Name = new Name(name),
            Constraints = constraint is null
                ? [new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) }]
                : [constraint],
        };
    }
}