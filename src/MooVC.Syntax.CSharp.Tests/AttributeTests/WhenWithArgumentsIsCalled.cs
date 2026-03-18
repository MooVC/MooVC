namespace MooVC.Syntax.CSharp.AttributeTests;

public sealed class WhenWithArgumentsIsCalled
{
    [Test]
    public async Task GivenArgumentsThenReturnsNewInstanceWithUpdatedArguments()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create(arguments: new Argument
        {
            Name = new Identifier("Original"),
            Value = Snippet.From("alpha"),
        });

        Argument[] additional = [new Argument { Name = new Identifier("Updated"), Value = Snippet.From("beta") }];

        // Act
        Attribute result = original.WithArguments(additional);

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Arguments.Length).IsEqualTo(2);
        _ = await Assert.That(result.Arguments).IsEquivalentTo([.. original.Arguments, .. additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
        _ = await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}