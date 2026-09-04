namespace MooVC.Syntax.CSharp.ResultTests;

using Type = System.Type;

public sealed class WhenAsIsCalled
{
    private const string ValueType = "Value";

    [Test]
    public async Task GivenAsTaskThenResultIsWrapped()
    {
        // Arrange
        var subject = new Result
        {
            Mode = Result.Modes.Synchronous,
            Type = new() { Name = ValueType },
        };

        // Act
        Result result = subject.AsTask();

        // Assert
        _ = await Assert.That(result.Type.ToString()).IsEqualTo("Task<Value>");
    }

    [Test]
    public async Task GivenAsValueTaskThenResultIsWrapped()
    {
        // Arrange
        var subject = new Result
        {
            Mode = Result.Modes.Synchronous,
            Type = new() { Name = ValueType },
        };

        // Act
        Result result = subject.AsValueTask();

        // Assert
        _ = await Assert.That(result.Type.ToString()).IsEqualTo("ValueTask<Value>");
    }

    [Test]
    public async Task GivenNullWrapperThenThrows()
    {
        // Arrange
        var subject = new Result();
        Type? wrapper = default;

        // Act
        Action action = () => _ = subject.As(wrapper!);

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }
}