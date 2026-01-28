namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

using System.Linq;
using Attribute = MooVC.Syntax.CSharp.Members.Attribute;

public sealed class WhenWithAttributesIsCalled
{
    [Fact]
    public void GivenAttributesThenReturnsNewInstanceWithUpdatedAttributes()
    {
        // Arrange
        Attribute[] existing =
        [
            new Attribute
            {
                Name = new Symbol { Name = new Variable("Existing") },
            },
        ];

        Attribute[] additional =
        [
            new Attribute
            {
                Name = new Symbol { Name = new Variable("Additional") },
            },
        ];

        Parameter original = ParameterTestsData.Create(attributes: existing);

        // Act
        Parameter result = original.WithAttributes(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.Length.ShouldBe(existing.Length + additional.Length);
        result.Attributes.ShouldBe(original.Attributes.Concat(additional));
        result.Default.ShouldBe(original.Default);
        result.Modifier.ShouldBe(original.Modifier);
        result.Name.ShouldBe(original.Name);
    }
}