namespace MooVC.Syntax.CSharp.Concepts.StructTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithConstructorsIsCalled
{
    [Test]
    public async Task GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        var constructor = new Constructor { Scope = Scope.Protected };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithConstructors(constructor);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Constructors).Contains(constructor);
        _ = await Assert.That(original.Constructors).IsEmpty();
    }
}