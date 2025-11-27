namespace MooVC.Syntax.CSharp.Members.EventTests;

public sealed class WhenGetHashCodeIsCalled
{
    private const string AlternativeHandler = "Result";
    private const string AlternativeName = "Ended";
    private const string Behaviour = "value";

    [Fact]
    public void GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create();

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create(name: AlternativeName);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentBehavioursThenHashesDiffer()
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
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentHandlersThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create(handler: AlternativeHandler);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentStaticStatesThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();

        Event second = EventTestsData.Create();
        second.IsStatic = true;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenDifferentScopesThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create(scope: Scope.Internal);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}