namespace MooVC.Syntax.CSharp.Members.IdentifierTests;

public sealed class WhenImplicitOperatorFromTypeIsCalled
{
    [Fact]
    public void GivenNullThenThrows()
    {
        // Arrange
        Type? value = default;

        // Act
        Func<Identifier> result = () => value!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenTypeThenIdentifierMatchesTypeName()
    {
        // Arrange
        Type value = typeof(Guid);

        // Act
        Identifier subject = value;

        // Assert
        subject.ShouldBe(new Identifier(nameof(Guid)));
    }
}
