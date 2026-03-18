namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenIsRequiredIsCalled
{
    [Test]
    public void GivenRequiredValueThenReturnsTrue()
    {
        // Arrange
        New subject = New.Required;

        // Act
        bool result = subject.IsRequired;

        // Assert
        result.ShouldBeTrue();
        subject.IsNotRequired.ShouldBeFalse();
    }

    [Test]
    public void GivenNonRequiredValueThenReturnsFalse()
    {
        // Arrange
        New subject = New.NotRequired;

        // Act
        bool result = subject.IsRequired;

        // Assert
        result.ShouldBeFalse();
        subject.IsNotRequired.ShouldBeTrue();
    }
}