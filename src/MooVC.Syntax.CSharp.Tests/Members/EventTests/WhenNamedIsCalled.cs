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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Name).IsEqualTo(name);
        _ = await Assert.That(result.Behaviours).IsEqualTo(original.Behaviours);
        _ = await Assert.That(result.Handler).IsEqualTo(original.Handler);
    }
}