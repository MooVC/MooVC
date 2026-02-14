namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedStructThenReturnsEmpty()
    {
        // Arrange
        Struct subject = Struct.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsStructSignature()
    {
        // Arrange
        var constructor = new Constructor();

        Struct subject = StructTestsData.Create(
            behavior: Struct.Kind.Ref,
            constructors: [constructor],
            isPartial: true,
            name: new Declaration { Name = new Variable(StructTestsData.DefaultName) },
            parameters: [new Parameter { Name = new Variable("input"), Type = typeof(int) }],
            scope: Scope.Internal);

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldContain("internal ref partial struct");
        result.ShouldContain(StructTestsData.DefaultName);
        result.ShouldContain("(");
        result.ShouldContain(")");
    }
}