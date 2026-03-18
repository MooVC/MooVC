namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly ImmutableArray<Name> _first = ["Alpha", "Beta"];
    private static readonly ImmutableArray<Name> _second = ["Gamma", "Delta"];

    [Test]
    public async Task GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        var left = new Qualifier(_first);
        var right = new Qualifier(_first);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsEqualTo(rightHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesAreNotEqual()
    {
        // Arrange
        var left = new Qualifier(_first);
        var right = new Qualifier(_second);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        _ = await Assert.That(leftHash).IsNotEqualTo(rightHash);
    }

    [Test]
    public async Task GivenSameInstanceWhenCalledTwiceThenHashIsStable()
    {
        // Arrange
        var subject = new Qualifier(WhenGetHashCodeIsCalled._first);

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        _ = await Assert.That(first).IsEqualTo(second);
    }
}