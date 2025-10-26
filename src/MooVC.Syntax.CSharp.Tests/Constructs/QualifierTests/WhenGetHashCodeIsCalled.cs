namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly ImmutableArray<Segment> First = ImmutableArray.Create(new Segment("Alpha"), new Segment("Beta"));
    private static readonly ImmutableArray<Segment> Second = ImmutableArray.Create(new Segment("Gamma"), new Segment("Delta"));

    [Fact]
    public void GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        var left = new Qualifier(First);
        var right = new Qualifier(First);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesAreNotEqual()
    {
        // Arrange
        var left = new Qualifier(First);
        var right = new Qualifier(Second);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }

    [Fact]
    public void GivenSameInstanceWhenCalledTwiceThenHashIsStable()
    {
        // Arrange
        var subject = new Qualifier(First);

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        first.ShouldBe(second);
    }
}
