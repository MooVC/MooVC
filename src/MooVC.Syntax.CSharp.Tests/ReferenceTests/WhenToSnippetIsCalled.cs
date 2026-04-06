namespace MooVC.Syntax.CSharp.ReferenceTests;

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

        var argument = new Generic
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
            Declaration = new()
            {
                Name = TypeName,
                Generics =
                [
                    argument,
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
        _ = await Assert.That(result).Contains(TypeName);
        _ = await Assert.That(result).Contains(ParameterName);
        _ = await Assert.That(result).Contains("where");
        _ = await Assert.That(result).Contains("widget");
    }
}