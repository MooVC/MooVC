namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "TValue";

    [Test]
    public async Task GivenDefaultsThenParameterIsUnnamed()
    {
        // Act
        var subject = new Parameter();

        // Assert
        await Assert.That(subject.Name).IsEqualTo(Name.Unnamed);
        await Assert.That(subject.Constraints).IsEmpty();
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
        var subject = new Parameter
        {
            Name = new Name(ParameterName),
            Constraints = [constraint],
        };

        // Assert
        await Assert.That(subject.Name).IsEqualTo(new Name(ParameterName));
        await Assert.That(subject.Constraints).IsEqualTo(new[] { constraint });
    }
}