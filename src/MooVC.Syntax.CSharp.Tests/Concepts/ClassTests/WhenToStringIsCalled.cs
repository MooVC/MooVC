namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

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
        _ = await Assert.That(result).IsEqualTo(string.Empty);
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
        _ = await Assert.That(result).Contains("internal abstract partial class");
        _ = await Assert.That(result).Contains(ClassTestsData.DefaultName);
        _ = await Assert.That(result).Contains("{");
        _ = await Assert.That(result).Contains("}");
    }
}