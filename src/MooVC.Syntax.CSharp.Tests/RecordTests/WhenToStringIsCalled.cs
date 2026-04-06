namespace MooVC.Syntax.CSharp.RecordTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedRecordThenReturnsEmpty()
    {
        // Arrange
        Record subject = Record.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsRecordSignature()
    {
        // Arrange
        var constructor = new Constructor();
        Record subject = RecordTestsData.Create(
            constructors: [constructor],
            extensibility: Extensibility.Abstract,
            isPartial: true,
            name: new Declaration { Name = RecordTestsData.DefaultName },
            parameters: [new Parameter { Name = new("input"), Type = typeof(int) }],
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).Contains("internal abstract partial record");
        _ = await Assert.That(result).Contains(RecordTestsData.DefaultName);
        _ = await Assert.That(result).Contains("(");
        _ = await Assert.That(result).Contains(")");
    }
}