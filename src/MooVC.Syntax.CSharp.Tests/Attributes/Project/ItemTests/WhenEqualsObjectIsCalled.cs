namespace MooVC.Syntax.CSharp.Attributes.Project.ItemTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Item subject = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Item subject = ItemTestsData.Create();
        object other = ItemTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}