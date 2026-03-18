namespace MooVC.Syntax.CSharp.Members.DeclarationTests;

using MooVC.Syntax.Elements;
using Parameter = MooVC.Syntax.CSharp.Generics.Parameter;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "T";

    [Test]
    public async Task GivenDefaultsThenDeclarationIsUnspecified()
    {
        // Act
        var subject = new Declaration();

        // Assert
        await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.Parameters).IsEmpty();
        await Assert.That(subject.IsUnspecified).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var parameter = new Parameter { Name = ParameterName };

        // Act
        var subject = new Declaration
        {
            Name = DeclarationTestsData.DefaultName,
            Parameters = [parameter],
        };

        // Assert
        await Assert.That(subject.Name).IsEqualTo(new Name(DeclarationTestsData.DefaultName));
        await Assert.That(subject.Parameters).IsEqualTo(new[] { parameter });
        await Assert.That(subject.IsUnspecified).IsFalse();
    }
}