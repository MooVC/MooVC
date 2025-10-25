namespace MooVC.Syntax.CSharp.Constructs.NamespaceTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange & Act & Assert
        _ = Should.NotThrow(() => _ = new Namespace(default));
    }

    [Fact]
    public void GivenEmptyThenInstanceIsCreated()
    {
        // Arrange
        Segment[] value = Array.Empty<Segment>();

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Namespace(value));
    }

    [Fact]
    public void GivenSingleSegmentThenInstanceIsCreated()
    {
        // Arrange
        Segment[] value = { new Segment("Alpha") };

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Namespace(value));
    }

    [Fact]
    public void GivenMultipleSegmentsThenInstanceIsCreated()
    {
        // Arrange
        Segment[] value =
        {
            new Segment("Alpha"),
            new Segment("Beta"),
            new Segment("Gamma"),
        };

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Namespace(value));
    }

    [Fact]
    public void GivenSameValueTwiceThenInstancesAreEqual()
    {
        // Arrange
        Segment[] firstValue =
        {
            new Segment("Alpha"),
            new Segment("Beta"),
        };

        Segment[] secondValue =
        {
            new Segment("Alpha"),
            new Segment("Beta"),
        };

        // Act
        var first = new Namespace(firstValue);
        var second = new Namespace(secondValue);

        // Assert
        first.Equals(second).ShouldBeTrue();
        (first == second).ShouldBeTrue();
        first.GetHashCode().ShouldBe(second.GetHashCode());
    }

    [Fact]
    public void GivenDifferentValuesTwiceThenInstancesAreNotEqual()
    {
        // Arrange
        Segment[] left =
        {
            new Segment("Alpha"),
            new Segment("Beta"),
        };

        Segment[] right =
        {
            new Segment("Alpha"),
            new Segment("Gamma"),
        };

        // Act
        var first = new Namespace(left);
        var second = new Namespace(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}
