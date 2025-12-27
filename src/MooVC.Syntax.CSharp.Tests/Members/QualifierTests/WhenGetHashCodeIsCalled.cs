namespace MooVC.Syntax.CSharp.Members.QualifierTests;

using System.Collections.Immutable;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly ImmutableArray<Segment> first = ["Alpha", "Beta"];
    private static readonly ImmutableArray<Segment> second = ["Gamma", "Delta"];

    [Fact]
    public void GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        var left = new Qualifier(first);
        var right = new Qualifier(first);

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
        var left = new Qualifier(first);
        var right = new Qualifier(second);

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
        var subject = new Qualifier(WhenGetHashCodeIsCalled.first);

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        first.ShouldBe(second);
    }
}