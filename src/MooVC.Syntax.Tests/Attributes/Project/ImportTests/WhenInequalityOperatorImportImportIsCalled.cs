namespace MooVC.Syntax.Attributes.Project.ImportTests;

using MooVC.Syntax.Elements;

public sealed class WhenInequalityOperatorImportImportIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Import? left = default;
        Import? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}