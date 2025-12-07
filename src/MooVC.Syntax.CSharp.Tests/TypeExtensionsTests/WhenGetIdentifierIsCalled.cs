namespace MooVC.Syntax.CSharp.TypeExtensionsTests;

public sealed class WhenGetIdentifierIsCalled
{
    [Fact]
    public void GivenNullTypeThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Type? type = default;

        // Act
        Action action = () => _ = type!.GetIdentifier();

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenNonGenericTypeThenReturnsName()
    {
        // Arrange
        Type type = typeof(string);

        // Act
        string result = type.GetIdentifier();

        // Assert
        result.ShouldBe(type.Name);
    }

    [Fact]
    public void GivenGenericTypeThenGenericSuffixIsRemoved()
    {
        // Arrange
        Type type = typeof(GenericSample<int>);

        // Act
        string result = type.GetIdentifier();

        // Assert
        result.ShouldBe("GenericSample");
    }

    private sealed class GenericSample<T>
    {
    }
}
