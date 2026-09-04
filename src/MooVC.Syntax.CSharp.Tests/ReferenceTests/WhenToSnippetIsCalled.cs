namespace MooVC.Syntax.CSharp.ReferenceTests;

public sealed class WhenToSnippetIsCalled
{
    private const string BaseName = "BaseWidget";
    private const string ConstraintInterfaceName = "IWidget";
    private const string FirstInterfaceName = "IFirstWidget";
    private const string GenericName = "T";
    private const string ParameterName = "value";
    private const string SecondInterfaceName = "ISecondWidget";
    private const string TypeName = "Widget";

    [Test]
    public async Task GivenMultipleInterfacesAndBaseThenReturnsSignatureWithBaseBeforeInterfaces()
    {
        // Arrange
        string expected = $$"""
            public sealed partial widget {{TypeName}}
                : {{BaseName}},
                  {{FirstInterfaceName}},
                  {{SecondInterfaceName}}
            {
            }
            """;

        var subject = new TestReference
        {
            Base = new() { Name = BaseName },
            Declaration = new() { Name = TypeName },
            Interfaces =
            [
                new() { Name = FirstInterfaceName },
                new() { Name = SecondInterfaceName },
            ],
        };

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenMultipleInterfacesThenReturnsSignatureWithInterfaces()
    {
        // Arrange
        string expected = $$"""
            public sealed partial widget {{TypeName}}
                : {{FirstInterfaceName}},
                  {{SecondInterfaceName}}
            {
            }
            """;

        var subject = new TestReference
        {
            Declaration = new() { Name = TypeName },
            Interfaces =
            [
                new() { Name = FirstInterfaceName },
                new() { Name = SecondInterfaceName },
            ],
        };

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenNoInterfacesOrBaseThenReturnsSignatureWithoutBaseTypeClause()
    {
        // Arrange
        string expected = $$"""
            public sealed partial widget {{TypeName}}
            {
            }
            """;

        var subject = new TestReference
        {
            Declaration = new() { Name = TypeName },
        };

        // Act
        string result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenParametersAndConstraintsThenReturnsSignatureWithClauses()
    {
        // Arrange
        string expected = $$"""
            public sealed partial widget {{TypeName}}<T>(int value)
                where T : {{ConstraintInterfaceName}}
            {
            }
            """;

        var constraint = new Constraint
        {
            Interfaces =
            [
                new() { Name = ConstraintInterfaceName },
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
                Arguments =
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
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}