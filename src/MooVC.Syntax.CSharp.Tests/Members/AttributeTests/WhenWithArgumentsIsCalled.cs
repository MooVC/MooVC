namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Arguments.Length).IsEqualTo(2);
        await Assert.That(result.Arguments).IsEqualTo(original.Arguments.Concat(additional));
        await Assert.That(result.Name).IsEqualTo(original.Name);
        await Assert.That(result.Target).IsEqualTo(original.Target);
    }
}