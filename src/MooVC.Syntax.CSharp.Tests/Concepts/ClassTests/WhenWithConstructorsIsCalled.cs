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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Constructors).IsEqualTo(original.Constructors.Concat(additional));
        _ = await Assert.That(result.Declaration).IsEqualTo(original.Declaration);
        _ = await Assert.That(original.Constructors).IsEqualTo(existing);
    }
}