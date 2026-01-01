namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedClassThenReturnsEmpty()
    {
        // Arrange
        Class subject = Class.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsClassSignature()
    {
        // Arrange
        var constructor = new Constructor();
        Class subject = ClassTestsData.Create(
            constructors: [constructor],
            extensibility: Extensibility.Abstract,
            isPartial: true,
            name: new Declaration { Name = new Variable(ClassTestsData.DefaultName) },
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain("internal abstract partial class");
        result.ShouldContain(ClassTestsData.DefaultName);
        result.ShouldContain("{");
        result.ShouldContain("}");
    }
}