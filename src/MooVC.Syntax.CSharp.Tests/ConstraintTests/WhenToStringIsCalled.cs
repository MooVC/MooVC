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
            Nature = Nature.Class,
            Base = new() { Name = BaseName },
            Interfaces = [new(new() { Name = InterfaceName })],
            New = New.Required,
        };

        // Act
        string result = constraint.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"where class, {BaseName}, {InterfaceName}, new()");
    }

    [Test]
    public async Task GivenMultipleInterfacesThenReturnsAllInterfacesInOrder()
    {
        // Arrange
        const string AdditionalInterfaceName = "IAnother";

        var constraint = new Constraint
        {
            Nature = Nature.Struct,
            Base = new() { Name = BaseName },
            Interfaces =
            [
                new Implementation(new Declaration { Name = InterfaceName }),
                new Implementation(new Declaration { Name = AdditionalInterfaceName }),
            ],
        };

        // Act
        string result = constraint.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo($"where struct, {BaseName}, {InterfaceName}, {AdditionalInterfaceName}");
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