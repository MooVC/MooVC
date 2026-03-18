namespace MooVC.Syntax.CSharp.Elements.ParameterTests;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "other";

    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Parameter original = ParameterTestsData.Create(modifier: Parameter.Mode.In);

        // Act
        Parameter result = original.Named(new Variable(NewName));

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(new Variable(NewName));
        await Assert.That(result.Attributes).IsEqualTo(original.Attributes);
        await Assert.That(result.Default).IsEqualTo(original.Default);
        await Assert.That(result.Modifier).IsEqualTo(original.Modifier);
        await Assert.That(original.Name).IsEqualTo(new Variable(ParameterTestsData.DefaultName));
    }
}