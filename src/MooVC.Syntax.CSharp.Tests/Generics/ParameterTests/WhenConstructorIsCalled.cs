namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenConstructorIsCalled
{
    private const string ParameterName = "TValue";

    [Fact]
    public void GivenDefaultsThenParameterIsUnnamed()
    {
        // Act
        var subject = new Parameter();

        // Assert
        subject.Name.ShouldBe(Name.Unnamed);
        subject.Constraints.ShouldBeEmpty();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        var constraint = new Constraint
        {
            Base = new Base(SymbolTestsData.CreateWithArgumentNames()),
        };

        // Act
        var subject = new Parameter
        {
            Name = ParameterName,
            Constraints = [constraint],
        };

        // Assert
        subject.Name.ShouldBe(ParameterName);
        subject.Constraints.ShouldBe(new[] { constraint });
    }
}