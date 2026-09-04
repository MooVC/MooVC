namespace MooVC.Syntax.CSharp.StructTests;

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
                new() { Name = ConstraintInterfaceName },
            ],
        };

        var genericParameter = new Generic
        {
            Name = GenericName,
            Constraints =
            [
                constraint,
            ],
        };

        var subject = new Struct
        {
            Behavior = Struct.Kinds.ReadOnly,
            Declaration = new()
            {
                Name = StructName,
                Arguments =
                [
                    genericParameter,
                ],
            },
            Parameters =
            [
                new Parameter { Name = new(ParameterName), Type = typeof(int) },
            ],
        };

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).Contains($"{Struct.Kinds.ReadOnly} partial struct {StructName}");
        _ = await Assert.That(result).Contains(ParameterName);
        _ = await Assert.That(result).Contains("where");
    }
}