namespace MooVC.Syntax.CSharp.Members.AttributeTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashesMatch()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(target: Attribute.Specifier.Return);
        Attribute right = AttributeTestsData.Create(target: Attribute.Specifier.Return);

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Attribute left = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("left") });
        Attribute right = AttributeTestsData.Create(arguments: new Argument { Value = Snippet.From("right") });

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}