namespace MooVC.Syntax.CSharp.Elements.ResultTests;

using MooVC.Syntax.Elements;

public sealed class WhenImplicitOperatorFromTypeIsCalled
{
    [Fact]
    public void GivenNullThenThrows()
    {
        // Arrange
        Type? value = default;

        // Act
        Func<Result> result = () => value!;

        // Assert
        _ = result.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenTypeThenResultUsesSymbolType()
    {
        // Arrange
        Type value = typeof(Guid);

        // Act
        Result result = value;

        // Assert
        result.Type.Name.ShouldBe(new Symbol.Moniker(nameof(Guid)));
    }
}