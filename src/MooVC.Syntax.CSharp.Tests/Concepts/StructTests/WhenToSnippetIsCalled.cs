namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using System;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;
using ElementParameter = MooVC.Syntax.CSharp.Elements.Parameter;
using GenericParameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenToSnippetIsCalled
{
    private const string ConstraintInterfaceName = "IComponent";
    private const string GenericName = "T";
    private const string ParameterName = "value";
    private const string StructName = "Payload";

    [Fact]
    public void GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Struct subject = StructTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenReadOnlyStructWithParametersThenIncludesSignatureDetails()
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
        var subject = new Struct
        {
            Behavior = Struct.Kind.ReadOnly,
            Name = new Declaration
            {
                Name = new Identifier(StructName),
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
        result.ShouldContain($"{Struct.Kind.ReadOnly} struct {StructName}");
        result.ShouldContain(ParameterName);
        result.ShouldContain("where");
    }
}