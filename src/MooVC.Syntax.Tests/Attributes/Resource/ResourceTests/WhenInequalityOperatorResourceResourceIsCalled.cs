namespace MooVC.Syntax.Attributes.Resource.ResourceTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorResourceResourceIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Resource? left = default;
        Resource? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Resource? left = default;
        Resource right = ResourceTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Resource left = ResourceTestsData.Create();
        Resource right = ResourceTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Resource left = ResourceTestsData.Create();
        Resource right = ResourceTestsData.Create(customToolNamespace: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}