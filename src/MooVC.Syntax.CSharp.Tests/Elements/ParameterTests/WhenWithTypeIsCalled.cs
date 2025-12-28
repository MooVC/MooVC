namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenWithTypeIsCalled
{
    [Fact]
    public void GivenValueThenReturnsNewInstanceWithUpdatedType()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(modifier: Parameter.Mode.In);

        var type = new Symbol
        {
            Name = "Foo",
            Qualifier = "Bar",
        };

        // Act
        Parameter result = original.WithType(type);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Attributes.ShouldBe(original.Attributes);
        result.Default.ShouldBe(original.Default);
        result.Modifier.ShouldBe(original.Modifier);
        result.Name.ShouldBe(original.Name);
        result.Type.ShouldBe(type);
        original.Name.ShouldBe(new Identifier(ParameterTestsData.DefaultName));
    }
}