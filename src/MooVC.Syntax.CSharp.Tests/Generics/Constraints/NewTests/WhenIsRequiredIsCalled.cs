namespace MooVC.Syntax.CSharp.Generics.Constraints.NewTests;

public sealed class WhenIsRequiredIsCalled
{
    [Fact]
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

    [Fact]
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
