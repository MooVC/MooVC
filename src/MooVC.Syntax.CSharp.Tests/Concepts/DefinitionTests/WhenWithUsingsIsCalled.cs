namespace MooVC.Syntax.CSharp.Concepts.DefinitionTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithUsingsIsCalled
{
    [Fact]
    public void GivenUsingsThenReturnsUpdatedInstance()
    {
        // Arrange
        Directive[] existing = [new Directive { Qualifier = "System" }];
        var additional = new Directive { Qualifier = "Other" };
        Definition<TestType> original = CreateDefinition(existing.ToImmutableArray());

        // Act
        Definition<TestType> result = original.WithUsings(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Usings.ShouldBe(original.Usings.Concat([additional]));
        result.Namespace.ShouldBe(original.Namespace);
        result.Type.ShouldBe(original.Type);
    }

    private static Definition<TestType> CreateDefinition(ImmutableArray<Directive> usings)
    {
        return new Definition<TestType>
        {
            Namespace = Qualifier.Unqualified,
            Type = new TestType(),
            Usings = usings,
        };
    }

    private sealed class TestType
        : Type
    {
        public override bool IsUndefined => false;

        protected override Snippet PerformToSnippet(Snippet.Options options)
        {
            return "Definition";
        }
    }
}