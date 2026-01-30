namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithConstructorsIsCalled
{
    [Fact]
    public void GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var originalConstructor = new Constructor();
        var updated = new Constructor { Scope = Scope.Protected };
        Record original = RecordTestsData.Create(constructors: [originalConstructor]);

        // Act
        Record result = original.WithConstructors(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes);
        result.Constructors.ShouldBe(new[] { originalConstructor, updated });
    }
}