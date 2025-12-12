namespace MooVC.Syntax.CSharp.Generics.Constraints.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenImplicitOperatorFromDeclarationIsCalled
{
    [Fact]
    public void GivenDeclarationThenCreatesInterface()
    {
        // Arrange
        var value = new Declaration { Name = new Identifier("IAlpha") };

        // Act
        Interface result = value;

        // Assert
        result.ToString().ShouldBe(value.ToString());
    }

    [Fact]
    public void GivenUnspecifiedDeclarationThenCreatesInterface()
    {
        // Arrange
        Declaration value = Declaration.Unspecified;

        // Act
        Interface result = value;

        // Assert
        result.ToString().ShouldBe(value.ToString());
    }
}