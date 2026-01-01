namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualsConstructorIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Constructor? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Constructor subject = ConstructorTestsData.Create();
        Constructor other = subject;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Constructor left = ConstructorTestsData.Create();
        Constructor right = ConstructorTestsData.Create();

        // Act
        bool resultLeftRight = left.Equals(right);
        bool resultRightLeft = right.Equals(left);

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Constructor left = ConstructorTestsData.Create();
        Constructor right = ConstructorTestsData.Create(body: Snippet.From("Shutdown();"));

        // Act
        bool result = left.Equals(right);

        // Assert
        result.ShouldBeFalse();
    }
}