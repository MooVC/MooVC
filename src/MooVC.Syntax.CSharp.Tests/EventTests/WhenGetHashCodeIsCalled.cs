namespace MooVC.Syntax.CSharp.EventTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string AlternativeHandler = "Result";
    private const string AlternativeName = "Ended";
    private const string Behaviour = "value";

    [Test]
    public async Task GivenDifferentBehavioursThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();

        Event second = EventTestsData.Create(
            behaviours: new Event.Methods
            {
                Add = Snippet.From(Behaviour),
            });

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentHandlersThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create(handler: AlternativeHandler);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentScopesThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create(scope: Scopes.Internal);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentStaticStatesThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create();
        second.Extensibility = Modifiers.Static;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create(name: AlternativeName);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}