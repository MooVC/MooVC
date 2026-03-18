namespace MooVC.Syntax.CSharp.Elements.ParameterTests.OptionsTests;

public sealed class WhenWithNamingIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Parameter.Options();
        Variable.Options value = Variable.Options.Pascal;

        // Act
        Parameter.Options result = options.WithNaming(value);

        // Assert
        await Assert.That(ReferenceEquals(result, options)).IsFalse();
        await Assert.That(result.Naming).IsEqualTo(value);
        await Assert.That(options.Naming).IsNotEqualTo(value);
    }
}