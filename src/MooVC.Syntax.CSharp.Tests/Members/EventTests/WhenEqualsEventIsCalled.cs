namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenEqualsEventIsCalled
{
    private const string AlternativeHandler = "Result";
    private const string AlternativeName = "Ended";
    private const string Behaviour = "value";

    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Event? subject = default;
        Event target = EventTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = subject;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEquivalentValueThenReturnsTrue()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create();

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValueThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create(name: AlternativeName);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentBehavioursThenReturnsFalse()
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
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentHandlersThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create(handler: AlternativeHandler);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentStaticStatesThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();

        Event target = EventTestsData.Create();
        target.Extensibility = Extensibility.Static;

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentScopesThenReturnsFalse()
    {
        // Arrange
        Event subject = EventTestsData.Create();
        Event target = EventTestsData.Create(scope: Scope.Internal);

        // Act
        bool result = target.Equals(subject);

        // Assert
        result.ShouldBeFalse();
    }
}