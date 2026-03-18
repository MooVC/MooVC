namespace MooVC.Syntax.CSharp.Concepts.StructTests;

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
            Declaration = new Declaration
            {
                Name = StructName,
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
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).Contains($"{Struct.Kind.ReadOnly} partial struct {StructName}");
        _ = await Assert.That(result).Contains(ParameterName);
        _ = await Assert.That(result).Contains("where");
    }
}