namespace MooVC.Syntax.CSharp.Members.PropertyTests;

public sealed class WhenToStringWithOptionsIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Property subject = PropertyTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToString(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }
}