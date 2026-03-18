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
        _ = await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.Parameters).IsEmpty();
        _ = await Assert.That(subject.IsUnspecified).IsTrue();
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
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(DeclarationTestsData.DefaultName));
        _ = await Assert.That(subject.Parameters).IsEqualTo(new[] { parameter });
        _ = await Assert.That(subject.IsUnspecified).IsFalse();
    }
}