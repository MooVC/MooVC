namespace MooVC.Syntax.CSharp.Constructs.QualifierTests;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenNullThenInstanceIsCreated()
    {
        // Arrange & Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(default));
    }

    [Fact]
    public void GivenEmptyThenInstanceIsCreated()
    {
        // Arrange
        Segment[] value = Array.Empty<Segment>();

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(value));
    }

    [Fact]
    public void GivenSingleSegmentThenInstanceIsCreated()
    {
        // Arrange
        Segment[] value = { new Segment("Alpha") };

        // Act & Assert
        _ = Should.NotThrow(() => _ = new Qualifier(value));
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
        _ = Should.NotThrow(() => _ = new Qualifier(value));
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
        var first = new Qualifier(firstValue);
        var second = new Qualifier(secondValue);

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
        var first = new Qualifier(left);
        var second = new Qualifier(right);

        // Assert
        first.Equals(second).ShouldBeFalse();
        (first != second).ShouldBeTrue();
    }
}
