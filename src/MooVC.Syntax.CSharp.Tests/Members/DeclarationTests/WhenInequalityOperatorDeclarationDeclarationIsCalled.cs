namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenInequalityOperatorDeclarationDeclarationIsCalled
{
    private const string AlternativeName = "Alternate";

    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Declaration? left = default;
        Declaration? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Declaration? left = default;
        Declaration right = DeclarationTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration right = DeclarationTestsData.Create();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentNamesThenReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        Declaration right = DeclarationTestsData.Create(AlternativeName);

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}
