namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedStructThenReturnsEmpty()
    {
        // Arrange
        Struct subject = Struct.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsStructSignature()
    {
        // Arrange
        var constructor = new Constructor();

        Struct subject = StructTestsData.Create(
            behavior: Struct.Kind.Ref,
            constructors: [constructor],
            isPartial: true,
            name: new Declaration { Name = StructTestsData.DefaultName },
            parameters: [new Parameter { Name = new Variable("input"), Type = typeof(int) }],
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).Contains("internal ref partial struct");
        await Assert.That(result).Contains(StructTestsData.DefaultName);
        await Assert.That(result).Contains("(");
        await Assert.That(result).Contains(")");
    }
}