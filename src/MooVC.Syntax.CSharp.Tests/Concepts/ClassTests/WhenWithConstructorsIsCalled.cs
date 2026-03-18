namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Constructors).IsEqualTo(original.Constructors.Concat(additional));
        await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        await Assert.That(original.Constructors).IsEqualTo(existing);
    }
}