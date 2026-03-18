namespace MooVC.Syntax.CSharp.Members.MethodTests;

public sealed class WhenEqualsObjectIsCalled
{
    [Test]
    public void GivenNonMethodObjectThenReturnsFalse()
    {
        // Arrange
        Method subject = MethodTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Test]
    public void GivenMethodObjectThenReturnsResultOfMethodEquals()
    {
        // Arrange
        Method subject = MethodTestsData.Create();
        object target = MethodTestsData.Create();

        // Act
        bool result = subject.Equals(target);

        // Assert
        result.ShouldBeTrue();
    }
}