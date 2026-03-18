namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorHeaderHeaderIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Header? left = default;
        Header? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Header? left = default;
        Header right = HeaderTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Header left = HeaderTestsData.Create();
        Header right = HeaderTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Header left = HeaderTestsData.Create();
        Header right = HeaderTestsData.Create(value: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}