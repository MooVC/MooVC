namespace MooVC.Syntax.CSharp.StructTests;

using Argument = MooVC.Syntax.CSharp.Generics.Argument;
using Constraint = MooVC.Syntax.CSharp.Generics.Constraint;
using Parameter = MooVC.Syntax.CSharp.Parameter;

public sealed class WhenToSnippetIsCalled
{
    private const string ConstraintInterfaceName = "IComponent";
    private const string GenericName = "T";
    private const string ParameterName = "Value";
    private const string StructName = "Payload";

    [Test]
    public async Task GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Struct subject = StructTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenReadOnlyStructWithParametersThenIncludesSignatureDetails()
    {
        // Arrange
        var constraint = new Constraint
        {
            Interfaces =
            [
                new Declaration { Name = ConstraintInterfaceName },
            ],
        };

        var genericParameter = new Argument
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
            Declaration = new Declaration
            {
                Name = StructName,
                Arguments =
                [
                    genericParameter,
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
        _ = await Assert.That(result).Contains($"{Struct.Kind.ReadOnly} partial struct {StructName}");
        _ = await Assert.That(result).Contains(ParameterName);
        _ = await Assert.That(result).Contains("where");
    }
}