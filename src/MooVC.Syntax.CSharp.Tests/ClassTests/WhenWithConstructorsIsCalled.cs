namespace MooVC.Syntax.CSharp.ClassTests;

using System.Collections.Immutable;

public sealed class WhenWithConstructorsIsCalled
{
    [Test]
    public async Task GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        Constructor[] existing =
        [
            new Constructor { Scope = Scope.Internal },
        ];

        Constructor[] additional =
        [
            new Constructor { Scope = Scope.Protected },
        ];

        Class original = ClassTestsData.Create(constructors: existing.ToImmutableArray());

        // Act
        Class result = original.WithConstructors(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Constructors).IsEquivalentTo([.. original.Constructors, .. additional]);
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Constructors).IsEquivalentTo(existing);
    }
}