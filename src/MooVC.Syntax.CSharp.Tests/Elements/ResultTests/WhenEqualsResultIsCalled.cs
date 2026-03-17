namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenEqualsResultIsCalled
{
    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Result subject = ResultTestsData.Create();
        Result other = ResultTestsData.Create(type: new Symbol { Name = "Other" });

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}