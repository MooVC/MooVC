namespace MooVC.Syntax.CSharp.SnippetTests;

using System.Collections.Immutable;
using MooVC.Syntax.CSharp;
using Shouldly;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> value = default;

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Snippet(value));
    }

    [Fact]
    public void GivenEmptyArrayThenInstanceIsCreated()
    {
        // Arrange
        ImmutableArray<string> value = [];

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Snippet(value));
    }

    [Fact]
    public void GivenSameValuesTwiceThenInstancesAreEqual()
    {
        // Arrange
        ImmutableArray<string> value = ["First", "Second"];

        // Act
        var first = new Snippet(value);
        var second = new Snippet(value);

        // Assert
        first.Equals(second).ShouldBeTrue();
        (first == second).ShouldBeTrue();
        first.GetHashCode().ShouldBe(second.GetHashCode());
    }

    [Fact]
    public void GivenDifferentValuesTwiceThenInstancesAreNotEqual()
    {
        // Arrange
        ImmutableArray<string> left = ["First"];
        ImmutableArray<string> right = ["Second"];

        // Act
        var first = new Snippet(left);
        var second = new Snippet(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}