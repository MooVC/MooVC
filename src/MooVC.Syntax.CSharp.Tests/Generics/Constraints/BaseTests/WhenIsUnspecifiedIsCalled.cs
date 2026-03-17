namespace MooVC.Syntax.CSharp.Generics.Constraints.BaseTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenIsUnspecifiedIsCalled
{
    [Test]
    public void GivenUnspecifiedBaseThenReturnsTrue()
    {
        // Arrange
        Base subject = Base.Unspecified;

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeTrue();
    }

    [Test]
    public void GivenSpecifiedBaseThenReturnsFalse()
    {
        // Arrange
        Base subject = new Symbol { Name = "Base" };

        // Act
        bool result = subject.IsUnspecified;

        // Assert
        result.ShouldBeFalse();
    }
}