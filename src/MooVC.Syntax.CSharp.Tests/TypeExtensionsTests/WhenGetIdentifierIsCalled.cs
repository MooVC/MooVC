namespace MooVC.Syntax.CSharp.TypeExtensionsTests;

using System.Diagnostics.CodeAnalysis;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenGetIdentifierIsCalled
{
    [Fact]
    public void GivenNullTypeThenArgumentNullExceptionIsThrown()
    {
        // Arrange
        Type? type = default;

        // Act
        Action action = () => _ = type!.GetName();

        // Assert
        _ = action.ShouldThrow<ArgumentNullException>();
    }

    [Fact]
    public void GivenNonGenericTypeThenReturnsName()
    {
        // Arrange
        Type type = typeof(string);

        // Act
        string result = type.GetName();

        // Assert
        result.ShouldBe("string");
    }

    [Fact]
    public void GivenGenericTypeThenGenericSuffixIsRemoved()
    {
        // Arrange
        Type type = typeof(GenericSample<int>);

        // Act
        Variable identifier = type.GetName();
        string result = identifier.ToSnippet(Variable.Options.Pascal);

        // Assert
        result.ShouldBe("GenericSample");
    }

    [SuppressMessage("Major Code Smell", "S2326:Unused type parameters should be removed", Justification = "Not neccessary for testing purposes.")]
    private sealed class GenericSample<T>;
}