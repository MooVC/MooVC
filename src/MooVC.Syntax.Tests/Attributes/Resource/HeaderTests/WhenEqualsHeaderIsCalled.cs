namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsHeaderIsCalled
{
    [Test]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        Header? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        Header other = HeaderTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Header subject = HeaderTestsData.Create();
        Header other = HeaderTestsData.Create(value: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}