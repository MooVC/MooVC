namespace MooVC.Syntax.CSharp.DefinitionExtensionsTests;

public sealed class WhenImportReferencesIsCalled
{
    private const string DefaultNamespace = "MooVC.Testing";
    private const string DiagnosticsNamespace = "MooVC.Testing.Diagnostics";
    private const string ModelNamespace = "MooVC.Testing.Model";
    private const string RulesNamespace = "MooVC.Testing.Rules";

    [Test]
    public async Task GivenComparisonSubjectThenReferenceIsImported()
    {
        // Arrange
        var subject = new Definition
        {
            Namespace = DefaultNamespace,
            Type = new Class
            {
                Declaration = new() { Name = "Sample" },
                Operators = new Operators
                {
                    Comparisons =
                    [
                        new Comparison
                        {
                            Body = Snippet.From("return true;"),
                            Subject = CreateSymbol("Other", ModelNamespace),
                        },
                    ],
                },
            },
        };

        // Act
        Definition result = subject.ImportReferences();

        // Assert
        _ = await Assert.That(result.ToSnippet(Options.Default).ToString()).Contains($"using {ModelNamespace};");
    }

    [Test]
    public async Task GivenMethodAttributeThenReferenceIsImported()
    {
        // Arrange
        var subject = new Definition
        {
            Namespace = DefaultNamespace,
            Type = new Class
            {
                Declaration = new() { Name = "Sample" },
                Methods =
                [
                    new Method
                    {
                        Attributes =
                        [
                            new Attribute { Name = CreateSymbol("TraceAttribute", DiagnosticsNamespace) },
                        ],
                        Body = Snippet.From("return name;"),
                        Name = new() { Name = "Create" },
                        Parameters =
                        [
                            new Parameter { Name = "name", Type = typeof(string) },
                        ],
                        Result = new Result { Mode = Result.Modes.Synchronous, Type = typeof(string) },
                    },
                ],
            },
        };

        // Act
        Definition result = subject.ImportReferences();

        // Assert
        _ = await Assert.That(result.ToSnippet(Options.Default).ToString()).Contains($"using {DiagnosticsNamespace};");
    }

    [Test]
    public async Task GivenTypeGenericConstraintThenReferenceIsImported()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Base { Name = CreateQualification("Rule", RulesNamespace) },
        };

        var generic = new Generic
        {
            Name = "T",
            Constraints = [constraint],
        };

        var subject = new Definition
        {
            Namespace = DefaultNamespace,
            Type = new Class
            {
                Declaration = new()
                {
                    Arguments = [generic],
                    Name = "Sample",
                },
            },
        };

        // Act
        Definition result = subject.ImportReferences();

        // Assert
        _ = await Assert.That(result.ToSnippet(Options.Default).ToString()).Contains($"using {RulesNamespace};");
    }

    private static Qualification CreateQualification(string name, string qualifier)
    {
        return new Qualification
        {
            Moniker = name,
            Qualifier = qualifier,
        };
    }

    private static Symbol CreateSymbol(string name, string qualifier)
    {
        return new Symbol
        {
            Name = CreateQualification(name, qualifier),
        };
    }
}