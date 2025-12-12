namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenToStringWithOptionsIsCalled
{
    [Fact]
    public void GivenNullOptionsThenThrows()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Snippet.Options? options = default;

        // Act
        ArgumentNullException exception = Should.Throw<ArgumentNullException>(() => _ = subject.ToString(options!));

        // Assert
        exception.ParamName.ShouldBe(nameof(options));
    }
}