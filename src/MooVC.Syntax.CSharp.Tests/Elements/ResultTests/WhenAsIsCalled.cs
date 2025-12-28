namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenAsIsCalled
{
    private const string ValueType = "Value";

    [Fact]
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

    [Fact]
    public void GivenAsTaskThenResultIsWrapped()
    {
        // Arrange
        var subject = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = new Identifier(ValueType) },
        };

        // Act
        Result result = subject.AsTask();

        // Assert
        result.Type.ToString().ShouldBe("Task<Value>");
    }

    [Fact]
    public void GivenAsValueTaskThenResultIsWrapped()
    {
        // Arrange
        var subject = new Result
        {
            Mode = Result.Modality.Synchronous,
            Type = new Symbol { Name = new Identifier(ValueType) },
        };

        // Act
        Result result = subject.AsValueTask();

        // Assert
        result.Type.ToString().ShouldBe("ValueTask<Value>");
    }
}