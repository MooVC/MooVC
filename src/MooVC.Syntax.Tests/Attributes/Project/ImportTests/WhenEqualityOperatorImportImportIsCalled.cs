namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorImportImportIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Import? left = default;
        Import? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Import? left = default;
        Import right = ImportTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create(sdk: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}