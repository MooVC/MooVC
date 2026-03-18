namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsEventIsCalled
{
    private const string AlternativeHandler = "Result";
    private const string AlternativeName = "Ended";
    private const string Behaviour = "value";

    [Test]
    public async Task GivenNullThenReturnsFalse()
    {
        // Arrange
        Event? subject = default;
        Event target = EventTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create(name: AlternativeName);

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentBehavioursThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();

        Event target = EventTestsData.Create(
            behaviours: new Event.Methods
            {
                Add = Snippet.From(Behaviour),
            });

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentHandlersThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create(handler: AlternativeHandler);

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentStaticStatesThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();

        Event target = EventTestsData.Create();
        target.Extensibility = Extensibility.Static;

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentScopesThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = target.Equals(subject);

        // Assert
        await Assert.That(result).IsFalse();
    }
}