namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        object? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        object other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        object right = DeclarationTestsData.Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Declaration left = DeclarationTestsData.Create();
        object right = DeclarationTestsData.Create("Different");

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenNonDeclarationThenReturnsFalse()
    {
        // Arrange
        Declaration subject = DeclarationTestsData.Create();
        object other = DeclarationTestsData.DefaultName;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}
