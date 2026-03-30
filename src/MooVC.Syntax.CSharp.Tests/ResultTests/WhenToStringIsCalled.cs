namespace MooVC.Syntax.CSharp.ResultTests;

public sealed class WhenToStringIsCalled
{
    private const string ValueType = "Value";

    [Test]
    public async Task GivenModifierAndTypeThenCombinedSignatureReturned()
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
        _ = await Assert.That(representation).IsEqualTo("async ref Value");
    }

    [Test]
    public async Task GivenUndefinedResultThenReturnsEmpty()
    {
        // Arrange
        Result subject = Result.Undefined;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }
}