namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp;
using Shouldly;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly ImmutableArray<string> first = ["Alpha", "Beta"];
    private static readonly ImmutableArray<string> second = ["Gamma", "Delta"];

    [Fact]
    public void GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        var left = new Snippet(first);
        var right = new Snippet(first);

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
        var left = new Snippet(first);
        var right = new Snippet(second);

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
        var subject = new Snippet(first);

        // Act
        int firstHash = subject.GetHashCode();
        int secondHash = subject.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }
}