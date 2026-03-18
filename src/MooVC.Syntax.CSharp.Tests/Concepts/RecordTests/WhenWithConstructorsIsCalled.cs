namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithConstructorsIsCalled
{
    [Test]
    public async Task GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var originalConstructor = new Constructor();
        var updated = new Constructor { Scope = Scope.Protected };
        Record original = RecordTestsData.Create(constructors: [originalConstructor]);

        // Act
        Record result = original.WithConstructors(updated);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        _ = await Assert.That(result.Constructors).IsEqualTo(new[] { originalConstructor, updated });
    }
}