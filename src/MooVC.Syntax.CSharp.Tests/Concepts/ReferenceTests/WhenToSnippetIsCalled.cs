namespace MooVC.Syntax.CSharp.Concepts.ReferenceTests;

using MooVC.Syntax.CSharp;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;
using ElementParameter = MooVC.Syntax.CSharp.Elements.Parameter;
using GenericParameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenToSnippetIsCalled
{
    private const string ConstraintInterfaceName = "IWidget";
    private const string GenericName = "T";
    private const string ParameterName = "value";
    private const string TypeName = "Widget";

    [Fact]
    public void GivenParametersAndConstraintsThenReturnsSignatureWithClauses()
    {
        // Arrange
        var constraint = new Constraint
        {
            Interfaces =
            [
                new Declaration { Name = new Identifier(ConstraintInterfaceName) },
            ],
        };

        var genericParameter = new GenericParameter
        {
            Name = GenericName,
            Constraints =
            [
                constraint,
            ],
        };

        var subject = new TestReference
        {
            IsUndefinedValue = false,
            Name = new Declaration
            {
                Name = new Identifier(TypeName),
                Parameters =
                [
                    genericParameter,
                ],
            },
            Parameters =
            [
                new ElementParameter { Name = new Identifier(ParameterName), Type = typeof(int) },
            ],
        };

        // Act
        string result = subject.ToSnippet(Snippet.Options.Default);

        // Assert
        result.ShouldContain(TypeName);
        result.ShouldContain(ParameterName);
        result.ShouldContain("where");
        result.ShouldContain("widget");
    }
}