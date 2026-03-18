namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenAsIsCalled
{
    private const string ValueType = "Value";

    [Test]
    public async Task GivenNullWrapperThenThrows()
    {
        // Arrange
        var subject = new Result();
        Type? wrapper = default;

        // Act
        Action action = () => _ = subject.As(wrapper!);

        // Assert
        await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenAsTaskThenResultIsWrapped()
    {
        // Arrange
        var subject = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = ValueType },
        };

        // Act
        Result result = subject.AsTask();

        // Assert
        await Assert.That(result.Type.ToString()).IsEqualTo("Task<Value>");
    }

    [Test]
    public async Task GivenAsValueTaskThenResultIsWrapped()
    {
        // Arrange
        var subject = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = ValueType },
        };

        // Act
        Result result = subject.AsValueTask();

        // Assert
        await Assert.That(result.Type.ToString()).IsEqualTo("ValueTask<Value>");
    }
}