namespace MooVC.Syntax.CSharp.Concepts.DefinitionTests;

using MooVC.Syntax.CSharp.Concepts;
using MooVC.Syntax.Elements;

public sealed class WhenFromIsCalled
{
    private const string UpdatedNamespace = "Updated.Namespace";

    [Fact]
    public void GivenNamespaceThenReturnsUpdatedInstance()
    {
        // Arrange
        Definition<TestType> original = CreateDefinition();
        Qualifier updated = UpdatedNamespace;

        // Act
        Definition<TestType> result = original.From(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Namespace.ShouldBe(updated);
        result.Type.ShouldBe(original.Type);
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