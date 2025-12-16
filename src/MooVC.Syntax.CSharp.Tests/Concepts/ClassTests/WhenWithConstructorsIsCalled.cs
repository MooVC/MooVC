namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

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
            new Constructor { Name = new Declaration { Name = new Identifier("First") } },
        ];

        Constructor[] additional =
        [
            new Constructor { Name = new Declaration { Name = new Identifier("Second") } },
        ];

        Class original = ClassTestsData.Create(constructors: existing);

        // Act
        Class result = original.WithConstructors(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Constructors.ShouldBe(original.Constructors.Concat(additional));
        result.Name.ShouldBe(original.Name);
        original.Constructors.ShouldBe(existing);
    }
}
