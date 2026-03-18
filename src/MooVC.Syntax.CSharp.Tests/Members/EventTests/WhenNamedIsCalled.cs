namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenNamedIsCalled
{
    private const string Name = "Handled";

    [Test]
    public async Task GivenNameThenReturnsNewInstanceWithUpdatedName()
    {
        // Arrange
        Event original = EventTestsData.Create();
        Name name = Name;

        // Act
        Event result = original.Named(name);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Name).IsEqualTo(name);
        await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        await Assert.That(result.Handler).IsEqualTo(original.Handler);
    }
}