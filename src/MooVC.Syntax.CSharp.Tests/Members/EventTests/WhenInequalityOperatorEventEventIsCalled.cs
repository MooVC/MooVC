namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenInequalityOperatorEventEventIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Event? left = default;
        Event? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsTrue()
    {
        // Arrange
        Event? left = default;
        Event right = EventTestsData.Create();

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftValueRightNullThenReturnsTrue()
    {
        // Arrange
        Event left = EventTestsData.Create();
        Event? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsFalse()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = first;

        // Act
        bool result = first != second;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsFalse()
    {
        // Arrange
        Event left = EventTestsData.Create();
        Event right = EventTestsData.Create();

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeFalse();
        resultRightLeft.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Event left = EventTestsData.Create();
        Event right = EventTestsData.Create(name: "Ended");

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentBehavioursThenReturnsTrue()
    {
        // Arrange
        Event left = EventTestsData.Create();

        Event right = EventTestsData.Create(
            behaviours: new Event.Methods
            {
                Add = Snippet.From("value"),
            });

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentHandlersThenReturnsTrue()
    {
        // Arrange
        Event left = EventTestsData.Create();
        Event right = EventTestsData.Create(handler: "Result");

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentStaticStatesThenReturnsTrue()
    {
        // Arrange
        Event left = EventTestsData.Create();

        Event right = EventTestsData.Create();
        right.Extensibility = Extensibility.Static;

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentScopesThenReturnsTrue()
    {
        // Arrange
        Event left = EventTestsData.Create();
        Event right = EventTestsData.Create(scope: Scope.Internal);

        // Act
        bool resultLeftRight = left != right;
        bool resultRightLeft = right != left;

        // Assert
        resultLeftRight.ShouldBeTrue();
        resultRightLeft.ShouldBeTrue();
    }
}