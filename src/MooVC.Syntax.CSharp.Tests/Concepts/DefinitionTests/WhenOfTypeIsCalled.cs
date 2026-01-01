namespace MooVC.Syntax.CSharp.Concepts.DefinitionTests;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.Elements;

public sealed class WhenOfTypeIsCalled
{
    [Fact]
    public void GivenTypeThenReturnsUpdatedInstance()
    {
        // Arrange
        Definition<TestType> original = CreateDefinition();
        var updated = new TestType();

        // Act
        Definition<TestType> result = original.OfType(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Type.ShouldBeSameAs(updated);
        result.Namespace.ShouldBe(original.Namespace);
        result.Usings.ShouldBe(original.Usings);
    }

    private static Definition<TestType> CreateDefinition()
    {
        return new Definition<TestType>
        {
            Namespace = Qualifier.Unqualified,
            Type = new TestType(),
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