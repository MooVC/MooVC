namespace MooVC.Syntax.CSharp.Elements.ArgumentTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    private const string Name = "Value";

    [Test]
    public async Task GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        var argument = new Argument();
        var name = new Variable(Name);

        // Act
        Argument result = argument.Named(name);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(argument);
        _ = await Assert.That(result.Name).IsEqualTo(name);
        _ = await Assert.That(argument.Name).IsNotEqualTo(name);
    }
}