namespace MooVC.Syntax.CSharp.Attributes.Project.PropertyGroupTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        PropertyGroup subject = PropertyGroupTestsData.Create();
        object other = PropertyGroupTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}