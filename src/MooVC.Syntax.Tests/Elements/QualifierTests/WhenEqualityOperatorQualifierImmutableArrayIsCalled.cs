namespace MooVC.Syntax.Elements.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenEqualityOperatorQualifierImmutableArrayIsCalled
{
    private static readonly ImmutableArray<Name> different = ["Gamma"];
    private static readonly ImmutableArray<Name> same = ["Alpha", "Beta"];

    [Test]
    public void GivenLeftValueRightDefaultThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Name> right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Name> right = same;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        var left = new Qualifier(same);
        ImmutableArray<Name> right = different;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}