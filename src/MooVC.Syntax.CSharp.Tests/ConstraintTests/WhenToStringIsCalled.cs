namespace MooVC.Syntax.CSharp.ConstraintTests;

public sealed class WhenToStringIsCalled
{
    private const string BaseName = "Result";
    private const string InterfaceName = "IExample";

    [Test]
    public async Task GivenConstraintWithValuesThenReturnsFormattedString()
    {
        // Arrange
        var constraint = new Constraint
        {
            Nature = Natures.Class,
            Base = new() { Name = BaseName },
            Interfaces = [new() { Name = InterfaceName }],
            New = New.Required,
        };

        // Act
        string result = constraint.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"class, {BaseName}, {InterfaceName}, new()");
    }

    [Test]
    public async Task GivenMultipleInterfacesThenReturnsAllInterfacesInOrder()
    {
        // Arrange
        const string AdditionalInterfaceName = "IAnother";

        var constraint = new Constraint
        {
            Nature = Natures.Struct,
            Base = new() { Name = BaseName },
            Interfaces =
            [
                new() { Name = InterfaceName },
                new() { Name = AdditionalInterfaceName },
            ],
        };

        // Act
        string result = constraint.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"struct, {BaseName}, {InterfaceName}, {AdditionalInterfaceName}");
    }

    [Test]
    public async Task GivenUnspecifiedConstraintThenReturnsEmpty()
    {
        // Arrange
        Constraint constraint = Constraint.Unspecified;

        // Act
        string result = constraint.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(string.Empty);
    }
}