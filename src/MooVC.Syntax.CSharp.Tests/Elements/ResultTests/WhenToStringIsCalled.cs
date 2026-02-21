namespace MooVC.Syntax.CSharp.Elements.ResultTests;

public sealed class WhenToStringIsCalled
{
    private const string ValueType = "Value";

    [Fact]
    public void GivenUndefinedResultThenReturnsEmpty()
    {
        // Arrange
        Result subject = Result.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenModifierAndTypeThenCombinedSignatureReturned()
    {
        // Arrange
        var subject = new Result
        {
            Modifier = Result.Kind.Ref,
            Mode = Result.Modality.Asynchronous,
            Type = new Symbol { Name = ValueType },
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe("async ref Value");
    }
}