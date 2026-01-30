namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenEqualsResultIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result other = ResultTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result other = ResultTestsData.Create(type: new Symbol { Name = new Variable("Other") });

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}