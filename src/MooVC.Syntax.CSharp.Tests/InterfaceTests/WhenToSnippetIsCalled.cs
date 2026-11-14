namespace MooVC.Syntax.CSharp.InterfaceTests;

public sealed class WhenToSnippetIsCalled
{
    [Test]
    public async Task GivenOptionsNotProvidedThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Interface subject = InterfaceTestsData.Create();

        // Act
        Func<string> action = () => subject.ToSnippet(options: default);

        // Assert
        _ = await Assert.That(action).Throws<ArgumentNullException>();
    }

    [Test]
    public async Task GivenAttributesThenAttributesAreRendered()
    {
        // Arrange
        Snippet expected = """
            [Marker]
            public interface Sample
            {
            }
            """;

        Interface subject = InterfaceTestsData.Create(
            attributes:
            [
                new Attribute { Name = new Symbol { Name = "MarkerAttribute" } },
            ]);

        // Act
        var result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenVariantTypeParametersWithConstraintsThenRendersVarianceOnlyInTheParameterList()
    {
        // Arrange
        var referenceType = Constraint.Unspecified.WithNature(Natures.Class);
        var declaration = ((Declaration)"IVisitor").WithArguments(
            Generic.Undefined.Named("TInput").WithVariance(Generic.Variances.In).WithConstraints(referenceType),
            Generic.Undefined.Named("TOutput").WithConstraints(referenceType).WithVariance(Generic.Variances.Out),
            Generic.Undefined.Named("TContext"));
        Interface subject = InterfaceTestsData.Create(name: declaration);
        Snippet expected = """
            public interface IVisitor<in TInput, out TOutput, TContext>

                where TInput : class
                where TOutput : class
            {
            }
            """;

        // Act
        var result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }

    [Test]
    public async Task GivenValuesThenReturnsInterfaceSignature()
    {
        // Arrange
        var created = new Event { Name = "Created" };
        var execute = new Method { Name = new() { Name = "Execute" } };
        var indexer = new Indexer { Parameter = new() { Name = "item", Type = typeof(string) }, Result = typeof(int) };
        var valueA = new Property { Name = "ValueA", Type = typeof(string) };

        var valueB = new Property
        {
            Behaviours = new() { Set = new() { Mode = Property.Methods.Setter.Modes.ReadOnly } },
            Name = "ValueB",
            Type = typeof(int),
        };

        Snippet expected = """
            internal partial interface Sample
            {
                event Created;

                string ValueA { get; init; }

                int ValueB { get; }

                int this[string item] { get; }

                Task Execute();
            }
            """;

        Interface subject = InterfaceTestsData.Create(
            events: [created],
            indexers: [indexer],
            isPartial: true,
            methods: [execute],
            name: new Declaration { Name = InterfaceTestsData.DefaultName },
            properties: [valueA, valueB],
            scope: Scopes.Internal);

        // Act
        var result = subject.ToSnippet(Type.Options.Default);

        // Assert
        _ = await Assert.That(result).IsEqualTo(expected);
    }
}