namespace MooVC.Syntax.CSharp.TypeExtensionsTests;

using System.Diagnostics.CodeAnalysis;
using MooVC.Syntax.CSharp.Members;

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
        result.ShouldBe("string");
    }

    [Fact]
    public void GivenGenericTypeThenGenericSuffixIsRemoved()
    {
        // Arrange
        Type type = typeof(GenericSample<int>);

        // Act
        Identifier identifier = type.GetIdentifier();
        string result = identifier.ToSnippet(Identifier.Options.Pascal);

        // Assert
        result.ShouldBe("GenericSample");
    }

    [SuppressMessage("Major Code Smell", "S2326:Unused type parameters should be removed", Justification = "Not neccessary for testing purposes.")]
    private sealed class GenericSample<T>;
}