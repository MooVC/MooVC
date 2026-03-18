namespace MooVC.Syntax.CSharp.DeclarationTests;

using Generic = MooVC.Syntax.CSharp.Generics.Generic;

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
        _ = await Assert.That(subject.Generics).IsEmpty();
        _ = await Assert.That(subject.IsUnspecified).IsTrue();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var parameter = new Generic { Name = ParameterName };

        // Act
        var subject = new Declaration
        {
            Name = DeclarationTestsData.DefaultName,
            Generics = [parameter],
        };

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(DeclarationTestsData.DefaultName));
        _ = await Assert.That(subject.Generics).IsEquivalentTo([parameter]);
        _ = await Assert.That(subject.IsUnspecified).IsFalse();
    }
}