namespace MooVC.Syntax.Attributes.Resource.DataTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorDataDataIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Data? left = default;
        Data? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Data? left = default;
        Data right = DataTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Data left = DataTestsData.Create();
        Data right = DataTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Data left = DataTestsData.Create();
        Data right = DataTestsData.Create(name: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}