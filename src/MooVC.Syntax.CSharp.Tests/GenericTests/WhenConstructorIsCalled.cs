namespace MooVC.Syntax.CSharp.GenericTests;

using MooVC.Syntax.CSharp.SymbolTests;

public sealed class WhenConstructorIsCalled
{
    private const string ArgumentName = "TValue";

    [Test]
    public async Task GivenDefaultsThenArgumentIsUnnamed()
    {
        // Act
        var subject = new Generic();

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
            Base = SymbolTestsData.CreateWithArgumentNames(),
        };

        // Act
        var subject = new Generic
        {
            Name = new(ArgumentName),
            Constraints = [constraint],
        };

        // Assert
        _ = await Assert.That(subject.Name).IsEqualTo(new Name(ArgumentName));
        _ = await Assert.That(subject.Constraints).IsEquivalentTo([constraint]);
    }
}