namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.CSharp.Generics;
using MooVC.Syntax.Elements;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenToStringIsCalled
{
    private const string Name = "Result";
    private const string FirstParameterName = "TFirst";
    private const string SecondParameterName = "TSecond";

    [Test]
    public async Task GivenUnspecifiedDeclarationThenEmptyReturned()
    {
        // Arrange
        Declaration subject = Declaration.Unspecified;

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(string.Empty);
    }

    [Test]
    public async Task GivenNameThenNameReturned()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = Name,
        };

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(Name);
    }

    [Test]
    public async Task GivenParametersThenNameAndParameterListReturned()
    {
        // Arrange
        var subject = new Declaration
        {
            Name = Name,
            Parameters =
            [
                new Parameter { Name = new Name(FirstParameterName) },
                new Parameter { Name = new Name(SecondParameterName) },
            ],
        };

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo($"{Name}<{FirstParameterName}, {SecondParameterName}>");
    }
}