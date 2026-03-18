namespace MooVC.Syntax.Attributes.Resource.HeaderTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorHeaderHeaderIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Header? left = default;
        Header? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Header? left = default;
        Header right = HeaderTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Header left = HeaderTestsData.Create();
        Header right = HeaderTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Header left = HeaderTestsData.Create();
        Header right = HeaderTestsData.Create(value: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}