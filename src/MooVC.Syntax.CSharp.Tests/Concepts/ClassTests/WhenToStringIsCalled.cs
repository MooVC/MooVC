namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System;
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
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Class subject = ClassTestsData.Create();

        // Act
        Func<string> action = () => subject.ToString(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
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
            name: new Declaration { Name = new Identifier(ClassTestsData.DefaultName) },
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