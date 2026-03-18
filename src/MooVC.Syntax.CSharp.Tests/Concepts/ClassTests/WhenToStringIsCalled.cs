namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenUndefinedClassThenReturnsEmpty()
    {
        // Arrange
        Class subject = Class.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenValuesThenReturnsClassSignature()
    {
        // Arrange
        var constructor = new Constructor();
        Class subject = ClassTestsData.Create(
            constructors: [constructor],
            extensibility: Extensibility.Abstract,
            isPartial: true,
            name: new Declaration { Name = ClassTestsData.DefaultName },
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        await Assert.That(result).Contains("internal abstract partial class");
        await Assert.That(result).Contains(ClassTestsData.DefaultName);
        await Assert.That(result).Contains("{");
        await Assert.That(result).Contains("}");
    }
}