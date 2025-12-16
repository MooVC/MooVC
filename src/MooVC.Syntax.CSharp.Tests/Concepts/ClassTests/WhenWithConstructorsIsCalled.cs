namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using System.Collections.Immutable;
using System.Linq;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithConstructorsIsCalled
{
    [Fact]
    public void GivenConstructorsThenReturnsUpdatedInstance()
    {
        // Arrange
        Constructor[] existing =
        [
            new Constructor(),
        ];

        Constructor[] additional =
        [
            new Constructor (),
        ];

        Class original = ClassTestsData.Create(constructors: existing.ToImmutableArray());

        // Act
        Class result = original.WithConstructors(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Constructors.ShouldBe(original.Constructors.Concat(additional));
        result.Name.ShouldBe(original.Name);
        original.Constructors.ShouldBe(existing);
    }
}