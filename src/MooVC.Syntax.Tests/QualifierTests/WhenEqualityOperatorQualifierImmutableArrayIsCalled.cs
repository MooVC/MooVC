namespace MooVC.Syntax.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenEqualityOperatorQualifierImmutableArrayIsCalled
{
    private static readonly ImmutableArray<Name> _different = ["Gamma"];
    private static readonly ImmutableArray<Name> _same = ["Alpha", "Beta"];

    [Test]
    public async Task GivenLeftValueRightDefaultThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(_same);
        ImmutableArray<Name> right = default;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(_same);
        ImmutableArray<Name> right = _same;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(_same);
        ImmutableArray<Name> right = _different;

        // Act
        bool result = left == right;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }
}