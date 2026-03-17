namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    private const string AlternativeHandler = "Result";
    private const string AlternativeName = "Ended";
    private const string Behaviour = "value";

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
    public void GivenDifferentStaticStatesThenHashesDiffer()
    {
        // Arrange
        Event first = EventTestsData.Create();
        Event second = EventTestsData.Create();
        second.Extensibility = Extensibility.Static;

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Test]
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