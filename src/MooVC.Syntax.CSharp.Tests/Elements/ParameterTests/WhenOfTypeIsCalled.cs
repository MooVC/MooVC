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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Type).IsEqualTo(type);
        await Assert.That(original.Name).IsEqualTo(new Variable(ParameterTestsData.DefaultName));
    }
}