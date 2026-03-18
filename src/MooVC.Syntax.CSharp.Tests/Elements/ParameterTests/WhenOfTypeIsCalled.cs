namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenOfTypeIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedType()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(modifier: Parameter.Mode.In);

        var type = new Symbol
        {
            Name = "Foo",
            Qualifier = "Bar",
        };

        // Act
        Parameter result = original.OfType(type);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        _ = await Assert.That(result.Default).IsEqualTo(original.Default);
        _ = await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Type).IsEqualTo(type);
        _ = await Assert.That(original.Name).IsEqualTo(new Variable(ParameterTestsData.DefaultName));
    }
}