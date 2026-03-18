namespace MooVC.Syntax.CSharp.Generics.ArgumentTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenConstructorIsCalled
{
    private const string ArgumentName = "TValue";

    [Test]
    public async Task GivenDefaultsThenArgumentIsUnnamed()
    {
        // Act
        var subject = new Argument();

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        _ = await Assert.That(subject.Constraints).IsEmpty();
    }

    [Test]
    public async Task GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Base(SymbolTestsData.CreateWithArgumentNames()),
        };

        // Act
        var subject = new Argument
        {
            Name = new Name(ArgumentName),
            Constraints = [constraint],
        };

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(ArgumentName));
        _ = await Assert.That(subject.Constraints).IsEquivalentTo([constraint]);
    }
}