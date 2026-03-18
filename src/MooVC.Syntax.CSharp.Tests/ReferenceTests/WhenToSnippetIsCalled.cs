namespace MooVC.Syntax.CSharp.ReferenceTests;

using Argument = MooVC.Syntax.CSharp.Generics.Argument;
using Constraint = MooVC.Syntax.CSharp.Generics.Constraint;
using Parameter = MooVC.Syntax.CSharp.Parameter;

public sealed class WhenToSnippetIsCalled
{
    private const string ConstraintInterfaceName = "IWidget";
    private const string GenericName = "T";
    private const string ParameterName = "value";
    private const string TypeName = "Widget";

    [Test]
    public async Task GivenParametersAndConstraintsThenReturnsSignatureWithClauses()
    {
        // Arrange
        var constraint = new Constraint
        {
            Interfaces =
            [
                new Declaration { Name = ConstraintInterfaceName },
            ],
        };

        var argument = new Argument
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
            Declaration = new Declaration
            {
                Name = TypeName,
                Arguments =
                [
                    argument,
                ],
            },
            Parameters =
            [
                new Parameter { Name = new Identifier(ParameterName), Type = typeof(int) },
            ],
        };

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).Contains(TypeName);
        _ = await Assert.That(result).Contains(ParameterName);
        _ = await Assert.That(result).Contains("where");
        _ = await Assert.That(result).Contains("widget");
    }
}