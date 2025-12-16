namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithConstructorsIsCalled
{
    [Fact]
    public void GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var originalConstructor = new Constructor { Name = new Declaration { Name = new Identifier(RecordTestsData.DefaultName) } };
        var updated = new Constructor { Name = new Declaration { Name = new Identifier("Other") } };
        Record original = RecordTestsData.Create(constructors: [originalConstructor]);

        // Act
        Record result = original.WithConstructors(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes);
        result.Constructors.ShouldBe(new[] { originalConstructor, updated });
    }
}
