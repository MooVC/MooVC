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
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(new Symbol { Name = NewName });
        await Assert.That(result.Arguments).IsEqualTo(original.Arguments);
        await Assert.That(result.Target).IsEqualTo(original.Target);
        await Assert.That(original.Name).IsEqualTo(new Symbol { Name = AttributeTestsData.DefaultName });
    }
}