namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;

public sealed class WhenNamedIsCalled
{
    private const string NewName = "DebuggerStepThrough";

    [Test]
    public async Task GivenValueThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Attribute original = AttributeTestsData.Create();

        // Act
        Attribute result = original.Named(new Symbol { Name = NewName });

        // Assert
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(new Symbol { Name = NewName });
        _ = await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        _ = await Assert.That(result.Target).IsEqualTo(original.Target);
        _ = await Assert.That(original.Name).IsEqualTo(new Symbol { Name = AttributeTestsData.DefaultName });
    }
}