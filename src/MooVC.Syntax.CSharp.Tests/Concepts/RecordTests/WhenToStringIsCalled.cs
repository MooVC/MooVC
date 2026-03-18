namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Test]
    public void GivenUndefinedRecordThenReturnsEmpty()
    {
        // Arrange
        Record subject = Record.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Test]
    public void GivenValuesThenReturnsRecordSignature()
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
        result.ShouldContain("internal abstract partial record");
        result.ShouldContain(RecordTestsData.DefaultName);
        result.ShouldContain("(");
        result.ShouldContain(")");
    }
}