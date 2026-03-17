namespace MooVC.Syntax.CSharp.Members.ConstructorTests;

using MooVC.Syntax.Elements;

public sealed class WhenEqualityOperatorConstructorConstructorIsCalled
{
    [Test]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Constructor? left = default;
        Constructor? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Constructor? left = default;
        Constructor right = ConstructorTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Constructor left = ConstructorTestsData.Create();
        Constructor? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Constructor first = ConstructorTestsData.Create();
        Constructor second = first;

        // Act
        bool result = first == second;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Constructor left = ConstructorTestsData.Create();
        Constructor right = ConstructorTestsData.Create();

        // Act
        bool resultLeftRight = left == right;
        bool resultRightLeft = right == left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Test]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Constructor left = ConstructorTestsData.Create();
        Constructor right = ConstructorTestsData.Create(body: Snippet.From("Shutdown();"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}