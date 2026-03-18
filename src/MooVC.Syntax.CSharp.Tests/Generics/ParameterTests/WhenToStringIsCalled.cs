namespace MooVC.Syntax.CSharp.Generics.ParameterTests;

using MooVC.Syntax.CSharp.Elements.SymbolTests;
using MooVC.Syntax.CSharp.Generics.Constraints;
using MooVC.Syntax.Elements;

public sealed class WhenToStringIsCalled
{
    private const string Name = "TValue";

    [Test]
    public async Task GivenValueThenReturnsFormattedString()
    {
        // Arrange
        var constraint = new Constraint { Base = new Base(SymbolTestsData.CreateWithArgumentNames()) };

        var subject = new Parameter
        {
            Name = new Name(Name),
            Constraints = [constraint],
        };

        // Act
        string result = subject.ToString();

        // Assert
        _ = await Assert.That(result).IsEqualTo(Name);
    }
}