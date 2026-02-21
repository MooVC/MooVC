namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Generics;
using MooVC.Syntax.Elements;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenToStringIsCalled
{
    private const string Name = "Result";
    private const string FirstParameterName = "TFirst";
    private const string SecondParameterName = "TSecond";

    [Fact]
    public void GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Declaration subject = Declaration.Unspecified;

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenNameThenNameReturned()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = Name,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(Name);
    }

    [Fact]
    public void GivenParametersThenNameAndParameterListReturned()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = Name,
            Parameters =
            [
                new Parameter { Name = FirstParameterName },
                new Parameter { Name = SecondParameterName },
            ],
        };

        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe($"{Name}<{FirstParameterName}, {SecondParameterName}>");
    }
}