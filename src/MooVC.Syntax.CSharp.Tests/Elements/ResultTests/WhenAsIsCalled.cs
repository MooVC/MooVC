namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenAsIsCalled
{
    private const string ValueType = "Value";

    [Test]
    public void GivenNullWrapperThenThrows()
    {
        // Arrange
        var subject = new Result();
        Type? wrapper = default;

        // Act
        Action action = () => _ = subject.As(wrapper!);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Test]
    public void GivenAsTaskThenResultIsWrapped()
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
        result.Type.ToString().ShouldBe("Task<Value>");
    }

    [Test]
    public void GivenAsValueTaskThenResultIsWrapped()
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
        result.Type.ToString().ShouldBe("ValueTask<Value>");
    }
}