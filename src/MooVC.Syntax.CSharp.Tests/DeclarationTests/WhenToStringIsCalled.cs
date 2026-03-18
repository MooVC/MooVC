namespace MooVC.Syntax.CSharp.DeclarationTests;

using Argument = MooVC.Syntax.CSharp.Generics.Argument;

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
            Arguments =
            [
                new Argument { Name = new Name(FirstParameterName) },
                new Argument { Name = new Name(SecondParameterName) },
            ],
        };

        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo($"{Name}<{FirstParameterName}, {SecondParameterName}>");
    }
}