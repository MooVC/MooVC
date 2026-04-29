namespace MooVC.Syntax.CSharp.ArgumentTests.OptionsTests;

public sealed class WhenWithNamingIsCalled
{
    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var options = new Argument.Options();
        Variable.Options value = Variable.Options.Pascal;

        // Act
        Argument.Options result = options.WithNaming(value);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(options);
        _ = await Assert.That(result.Naming).IsEqualTo(value);
        _ = await Assert.That(options.Naming).IsNotEqualTo(value);
    }
}