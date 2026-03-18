namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(result).IsEqualTo(string.Empty);
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
            parameters: [new Parameter { Name = new Variable("input"), Type = typeof(int) }],
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).Contains("internal abstract partial record");
        await Assert.That(result).Contains(RecordTestsData.DefaultName);
        await Assert.That(result).Contains("(");
        await Assert.That(result).Contains(")");
    }
}