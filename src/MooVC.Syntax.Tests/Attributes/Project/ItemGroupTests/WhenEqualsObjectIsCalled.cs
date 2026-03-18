namespace MooVC.Syntax.Attributes.Project.ItemGroupTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        ItemGroup subject = ItemGroupTestsData.Create();
        object other = ItemGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}